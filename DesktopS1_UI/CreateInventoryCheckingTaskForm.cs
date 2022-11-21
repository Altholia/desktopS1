using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DesktopS1_BLL;
using DesktopS1_Model.DisplayDto;
using DesktopS1_Model.Entities;
using static DesktopS1_BLL.CreateInventoryCheckingTaskBll;

namespace DesktopS1_UI
{
    public partial class CreateInventoryCheckingTaskForm : Form
    {
        private readonly WarehouseDisplayDto _dto;
        public static List<string> _selectZone = new List<string>();//存储用户选择的分区名称

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        public CreateInventoryCheckingTaskForm()
        {
            InitializeComponent();
        }

        public CreateInventoryCheckingTaskForm(WarehouseDisplayDto dto)
        {
            InitializeComponent();
            _dto = dto;
        }

        private async void CreateInventoryCheckingTaskForm_Load(object sender, EventArgs e)
        {
            Warehouse_ComboBox.Items.Clear();
            TaskType_ComboBox.Items.Clear();

            //初始化Warehouse_ComboBox.Items数据
            List<WarehouseDisplayDto> warehouses = 
                await WarehouseDetailsBll.InstanceBll.GetWarehouseAsync();
            foreach (var warehouse in warehouses)
            {
                Warehouse_ComboBox.Items.Add(warehouse.Name);
            }

            //初始化TaskType_ComboBox.Items数据
            List<string> taskTypeNames = await InstanceBll.GetTaskTypeNameAsync();
            foreach (string taskTypeName in taskTypeNames)
            {
                TaskType_ComboBox.Items.Add(taskTypeName);
            }
        }

        /// <summary>
        /// 当StartDate_DateTimePicker的Value发生变化时查看是否大于等于DateTime.Now，如果小于则报错
        /// 因为任务的创建只能向前创建不能向后创建
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartDate_DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            string dateNow = DateTime.Now.ToString("yyyy/MM/dd");
            string date = StartDate_DateTimePicker.Value.ToString("yyyy/MM/dd");

            if (Convert.ToDateTime(date)< Convert.ToDateTime(dateNow))
            {
                MessageBox.Show(@"您只能选择今天及以后的日期", @"警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                StartDate_DateTimePicker.Value = DateTime.Now;
            }
        }

        /// <summary>
        /// 当任务类型更改时根据类型决定是否显示PartsToBeChecked里的内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TaskType_ComboBox_TextChanged(object sender, EventArgs e)
        {
            FillChecked_TableLayoutPanel();
        }

        /// <summary>
        /// 如果TaskType.Text为空，则不进行内容填充。否则进行数据填充
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Warehouse_ComboBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TaskType_ComboBox.Text.Trim()))
                return;

            FillChecked_TableLayoutPanel();
        }

        /// <summary>
        /// 单机该按钮进行保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Submit_Button_Click(object sender, EventArgs e)
        {
            string warehouseString=Warehouse_ComboBox.Text.Trim();
            string taskNameString=TaskType_ComboBox.Text.Trim();
            string taskTypeString=TaskType_ComboBox.Text.Trim();
            string startDate = StartDate_DateTimePicker.Value.ToString("yyyy/MM/dd");

            if (string.IsNullOrWhiteSpace(warehouseString) || string.IsNullOrWhiteSpace(taskNameString) ||
                string.IsNullOrWhiteSpace(taskTypeString) || string.IsNullOrWhiteSpace(startDate))
            {
                MessageBox.Show(@"有数据为空", @"警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            InventoryCheckingTask entity = new InventoryCheckingTask
            {
                TaskName = TaskName_TextBox.Text.Trim(),
                WarehouseId = await InstanceBll.GetWarehouseIdAsync(Warehouse_ComboBox.Text.Trim()),
                TaskTypeId = await InstanceBll.GetTaskTypeIdAsync(TaskType_ComboBox.Text.Trim()),
                StartDate = StartDate_DateTimePicker.Value,
                CreateTime = StartDate_DateTimePicker.Value,
                StatusId = 1
            };

            if (taskTypeString.ToLower() == "portion warehouse")
            {
                if (_selectZone.Count == 0)
                {
                    MessageBox.Show(@"您未选择分区", @"警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }
            }
            else if (taskTypeString.ToLower() == "whole warehouse")
            {
                //如果用户选择的TaskType是"Whole Warehouse"类型，那么将该仓库下的所有分区都添加进去

                _selectZone.Clear();//清除一波
                _selectZone = await InstanceBll.GetZoneIdsAsync(entity.WarehouseId);
            }

            InstanceBll.AddInventoryCheckingTask(entity);
            if (await InstanceBll.SaveChangeAsync())
                MessageBox.Show(@"添加InventoryCheckingTask成功！", @"成功", MessageBoxButtons.OK, MessageBoxIcon.None);
            else
            {
                MessageBox.Show(@"添加InventoryCheckingTask失败！", @"错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<int> zoneIds = await InstanceBll.GetZoneIdAsync(entity.WarehouseId, _selectZone);
            if (await InstanceBll.AddTaskDetail(zoneIds, entity.Id))
                MessageBox.Show(@"添加TaskDetail成功！", @"成功", MessageBoxButtons.OK, MessageBoxIcon.None);
            else
                MessageBox.Show(@"添加TaskDetail失败！", @"错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        /// <summary>
        /// 如果用户选择的TaskType类型为"Portion Warehouse"则利用该方法添加仓库中对应的仓库分区名称
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectZone_Button_Click(object sender, EventArgs e)
        {
            _selectZone.Clear();//每当用户选择分区的时候都需要先清楚一遍，以防重复添加

            if (string.IsNullOrWhiteSpace(TaskType_ComboBox.Text.Trim()))
            {
                MessageBox.Show(@"您未选择TaskType", @"警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }

            if (TaskType_ComboBox.Text.Trim().ToLower() == "whole warehouse")
            {
                MessageBox.Show(@"您的TaskType类型为：Whole Warehouse，无需选择分区", @"提示", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            new SelectZoneForm(_dto).Show();
        }

        /// <summary>
        /// 自定义方法
        /// 填充Checked_TableLayoutPanel
        /// </summary>
        private async void FillChecked_TableLayoutPanel()
        {
            Checked_TableLayoutPanel.Controls.Clear();

            if (string.IsNullOrWhiteSpace(Warehouse_ComboBox.Text.Trim()))
                return;

            IEnumerable<PartsToBeCheckedDisplayDto> dtos =
                await InstanceBll.GetPartsToBeCheckedAsync(Warehouse_ComboBox.Text.Trim());
            if (dtos == null)
            {
                MessageBox.Show(@"数据出错！", @"错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int totalRow = Checked_TableLayoutPanel.RowCount;
            int currentRow = 0;

            SuspendLayout();
            foreach (var dto in dtos)
            {
                if (currentRow >= totalRow)
                {
                    Checked_TableLayoutPanel.RowCount++;
                    Checked_TableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50f));
                }

                for (int i = 0; i < Checked_TableLayoutPanel.ColumnCount; i++)
                {
                    Label label = new Label
                    {
                        Text = dto[i].ToString(),
                        Font = new Font("宋体", 15f),
                        Dock = DockStyle.Fill,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Margin = new Padding(0),
                    };

                    Checked_TableLayoutPanel.Controls.Add(label, i, currentRow);
                }
                currentRow++;
            }
            ResumeLayout();
        }

        private void CreateInventoryCheckingTaskForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
