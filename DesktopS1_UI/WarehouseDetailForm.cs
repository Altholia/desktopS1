using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DesktopS1_Model.DisplayDto;
using DesktopS1_Model.Entities;
using static DesktopS1_BLL.WarehouseDetailsBll;

namespace DesktopS1_UI
{
    public partial class WarehouseDetailForm : Form
    {
        private List<WarehouseDisplayDto> _dtos=new List<WarehouseDisplayDto>();
        private WarehouseDisplayDto _dto;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        public WarehouseDetailForm()
        {
            InitializeComponent();
        }

        private async void WarehouseDetail_Load(object sender, EventArgs e)
        {
            Warehouse_ComboBox.Items.Clear();//在添加信息之前先清楚一遍，以免重复添加
            _dtos = await InstanceBll.GetWarehouseAsync();//获取所有的仓库信息
            foreach (var dto in _dtos)
            {
                Warehouse_ComboBox.Items.Add(dto.Name);//将所有的仓库名称添加进去
            }

            Warehouse_ComboBox.Text = Warehouse_ComboBox.Items[0].ToString();//默认获取第一个仓库的信息
        }

        /// <summary>
        /// 当Name_Label的Text值发生变化时，该仓库对应的信息也要随之改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private  async void Warehouse_ComboBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Warehouse_ComboBox.Text))
                return;

            WarehouseLayout_Panel.Controls.Clear();//先清楚一波
            _dto=_dtos.FirstOrDefault(r => r.Name==Warehouse_ComboBox.Text);//获取当前的仓库
            if (_dto == null)
            {
                MessageBox.Show(@"数据出错", @"错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Name_Label.Text = _dto.Name;
            Area_Label.Text = $@"{_dto.Area} m^2";
            WarehouseKeeper_Label.Text = _dto.WarehouseKeeper;
            Phone_Label.Text= _dto.Phone;
            Address_Label.Text = _dto.Address;
            LastCheckingDate_Label.Text = $@"{_dto.LastCheckingDate:yyyy/MM/dd}";

            List<Zone> zones = await InstanceBll.GetZonesAsync(_dto.Id);
            Random random = new Random();
            foreach (Zone zone in zones)
            {
                Panel panel = new Panel
                {
                    Tag=zone.Id,
                    Location = new Point(zone.UpperLeftX/3, zone.UpperLeftY/5),
                    Size = new Size(zone.Width/3, zone.Height/5),
                    BackColor = Color.FromArgb(random.Next(255),random.Next(255),random.Next(255))
                };

                Label label = new Label
                {
                    Text = zone.Name,
                    Location = new Point(panel.Width / 2-15, panel.Height / 2-15),
                    Font = new Font("宋体", 20, FontStyle.Bold),
                    Enabled=false
                };
                panel.Controls.Add(label);
                panel.Click += ZonePanel_Click;

                WarehouseLayout_Panel.Controls.Add(panel);
            }
        }

        private async void ZonePanel_Click(object sender, EventArgs e)
        {
            PartsInWarehouse_TableLayoutPanel.Controls.Clear();//先清楚一波，以免重复添加

            int row = PartsInWarehouse_TableLayoutPanel.RowCount;//获取现在有多少行
            int column=PartsInWarehouse_TableLayoutPanel.ColumnCount;//获取现在有多少列

            if (!(sender is Panel panel))
            {
                MessageBox.Show(@"数据错误！！！", @"错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int i = 0;
            List<PartDisplayDto> dtos = await InstanceBll.GetParInformationByZoneId((int)panel.Tag);
            foreach (var dto in dtos)
            {
                if (i >= row)
                {
                    PartsInWarehouse_TableLayoutPanel.RowCount++;
                    PartsInWarehouse_TableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50f));
                }

                for (int j = 0; j < column; j++)
                {
                    Label label = new Label
                    {
                        Text = dto[j].ToString(),
                        Font = new Font("宋体", 10f),
                        Dock = DockStyle.Fill,
                        TextAlign=ContentAlignment.MiddleCenter
                    };
                    PartsInWarehouse_TableLayoutPanel.Controls.Add(label, j, i);
                }

                i++;
            }
        }

        private void CreateInventoryTask_Click(object sender, EventArgs e)
        {
            Close();
            new CreateInventoryCheckingTaskForm(_dto).Show();
        }
    }
}
