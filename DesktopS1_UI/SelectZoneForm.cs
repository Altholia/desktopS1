using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DesktopS1_Model.DisplayDto;
using DesktopS1_Model.Entities;
using static DesktopS1_BLL.WarehouseDetailsBll;
using static DesktopS1_UI.CreateInventoryCheckingTaskForm;

namespace DesktopS1_UI
{
    public partial class SelectZoneForm : Form
    {
        private readonly WarehouseDisplayDto _dto;
        private bool _isClick = true;

        public SelectZoneForm()
        {
            InitializeComponent();
        }

        public SelectZoneForm(WarehouseDisplayDto dto)
        {
            InitializeComponent();
            _dto = dto;
        }

        private async void SelectZoneForm_Load(object sender, EventArgs e)
        {
            if (_dto == null)
            {
                MessageBox.Show(@"SelectZoneForm仓库分区错误", @"错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<Zone> zones = await InstanceBll.GetZonesAsync(_dto.Id);
            Random random = new Random();
            foreach (Zone zone in zones)
            {
                Panel panel = new Panel
                {
                    Tag = zone.Id,
                    Location = new Point(zone.UpperLeftX / 3, zone.UpperLeftY / 5),
                    Size = new Size(zone.Width / 3, zone.Height / 5),
                    BackColor = Color.FromArgb(random.Next(255), random.Next(255), random.Next(255)),
                    Name=zone.Name
                };

                Label label = new Label
                {
                    Text = zone.Name,
                    Location = new Point(panel.Width / 2 - 15, panel.Height / 2 - 15),
                    Font = new Font("宋体", 20, FontStyle.Bold),
                    Enabled = false
                };
                panel.Controls.Add(label);
                panel.Click += ZonePanel_Click;

                WarehouseLayout_Panel.Controls.Add(panel);
            }
        }

        private void ZonePanel_Click(object sender,EventArgs e)
        {
            if (!(sender is Panel panel))
            {
                MessageBox.Show(@"所选仓库分区出错", @"错误", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                return;
            }

            if (_isClick)
            {
                panel.BorderStyle = BorderStyle.Fixed3D;
                _selectZone.Add(panel.Name);
                _isClick=false;
            }
            else
            {
                panel.BorderStyle = BorderStyle.FixedSingle;
                _selectZone.Remove(panel.Name);
                _isClick = true;
            }
        }
    }
}
