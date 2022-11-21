using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DesktopS1_BLL;
using DesktopS1_Helper;
using DesktopS1_Model.DisplayDto;
using static DesktopS1_BLL.ViewInventoryCheckingTaskFormBll;
using static DesktopS1_Model.DisplayDto.UserDisplayDto;

namespace DesktopS1_UI
{
    public partial class ViewInventoryCheckingTaskForm : Form
    {
        public static ViewInventoryCheckingTaskForm InstanceForm => Singleton<ViewInventoryCheckingTaskForm>.Instance;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp=base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        public ViewInventoryCheckingTaskForm()
        {
            InitializeComponent();
        }

        private async void ViewInventoryCheckingTaskForm_Load(object sender, EventArgs e)
        {
            #region 对查询条件的数据进行填充

            IEnumerable<string> warehouseNames = await InstanceBll.GetWarehouseByStaffId(InstanceUser.UserId);
            List<string> taskTypeNames = await CreateInventoryCheckingTaskBll.InstanceBll.GetTaskTypeNameAsync();
            IEnumerable<string> taskStatusNames = await InstanceBll.GetTaskStatusNames();

            foreach (var warehouseName in warehouseNames)
            {
                Warehouse_ComboBox.Items.Add(warehouseName);
            }

            foreach (var taskTypeName in taskTypeNames)
            {
                TaskType_ComboBox.Items.Add(taskTypeName);
            }

            foreach (var taskStatusName in taskStatusNames)
            {
                Status_ComboBox.Items.Add(taskStatusName);
            }

            #endregion 对查询条件的数据进行填充
        }

        /// <summary>
        /// 点击Search按钮进程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Search_Button_Click(object sender, EventArgs e)
        {
            await Search_Button_Click();
        }

        public async Task Search_Button_Click()
        {
            Inventory_DataGridView.Rows.Clear();//清除一波，以免重复添加

            SearchParameter parameter = new SearchParameter//查询条件
            {
                WarehouseString = Warehouse_ComboBox.Text.Trim(),
                TaskTypeString = TaskType_ComboBox.Text.Trim(),
                StatusString = Status_ComboBox.Text.Trim()
            };

            List<InventoryCheckingTaskDisplayDto> dtos =
                await InstanceBll.GetInventoryCheckingTaskFromSearchCondition(parameter);

            if (dtos == null || dtos.Count <= 0)
            {
                MessageBox.Show(@"错误！无数据", @"错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SuspendLayout();
            foreach (var dto in dtos)
            {
                int currentRow = Inventory_DataGridView.Rows.Add();
                for (int column = 0; column < Inventory_DataGridView.ColumnCount; column++)
                {
                    Inventory_DataGridView.Rows[currentRow].Cells[column].Value = dto[column];
                }
            }
            ResumeLayout();
        }

        /// <summary>
        /// 当点击该按钮时，将“未开始”状态的任务切换为“正在进行中”，如果是“已完成”或者“正在进行中”的任务则给予一定的提示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Start_Button_Click(object sender, EventArgs e)
        {
            await ChangeStatus(StatusEnum.Ongoing);
        }

        private void Input_Button_Click(object sender, EventArgs e)
        {
            if (Inventory_DataGridView.SelectedCells.Count == 0)
            {
                MessageBox.Show(@"您未选择任何数据", @"警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                return;
            }

            string statusName=Inventory_DataGridView.CurrentRow?.Cells[7].Value.ToString();
            if (statusName != "Ongoing")
            {
                MessageBox.Show(@"该任务并不在进行中，无法录入盘点结果", @"警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            InputImportPanelDisplayDto dto = new InputImportPanelDisplayDto
            {
                CurrentRow = Inventory_DataGridView.SelectedRows[0].Index,
                WarehouseName = Inventory_DataGridView.CurrentRow.Cells[1].Value.ToString(),
                TaskName = Inventory_DataGridView.CurrentRow.Cells[2].Value.ToString(),
                TaskType = Inventory_DataGridView.CurrentRow.Cells[3].Value.ToString(),
            };

            InstanceForm.Hide();
            new InputInventoryCheckingResultForm(dto).Show();
        }

        public async Task ChangeStatus(StatusEnum statusEnum,DateTime finishDateTime=default)
        {
            if (Inventory_DataGridView.SelectedCells.Count == 0)
            {
                MessageBox.Show(@"您未选择任何数据", @"警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                return;
            }

            if (Inventory_DataGridView.CurrentRow == null)
            {
                MessageBox.Show(@"您未选择任何数据", @"警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                return;
            }

            string status = Inventory_DataGridView.CurrentRow.Cells[7].Value.ToString();
            if (status.Equals(statusEnum.ToString()))
            {
                MessageBox.Show($@"该任务已 {status} , 请勿重复同一操作", @"提示", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);
                return;
            }

            if (statusEnum.ToString().Equals("Ongoing"))
            {
                if (status.Equals(StatusEnum.Finished.ToString()))
                {
                    MessageBox.Show(@"该任务已完成，无需再进行", @"警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            Inventory_DataGridView.CurrentRow.Cells[7].Value = statusEnum.ToString();

            if (statusEnum.ToString().Equals("Finished"))
                Inventory_DataGridView.CurrentRow.Cells[6].Value = finishDateTime;

            string taskName = Inventory_DataGridView.CurrentRow?.Cells[2].Value.ToString();

            await InstanceBll.UpdateInventoryCheckingTaskStatus(taskName,statusEnum, finishDateTime);
            await CreateInventoryCheckingTaskBll.InstanceBll.SaveChangeAsync();
        }

        private void View_Button_Click(object sender, EventArgs e)
        {
            string taskName=Inventory_DataGridView.CurrentRow?.Cells[2].Value.ToString();
            if (taskName == null)
            {
                MessageBox.Show(@"没有数据", @"提示", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                return;
            }

            string statusName = Inventory_DataGridView.CurrentRow?.Cells[7].Value.ToString();
            if (statusName != StatusEnum.Finished.ToString())
            {
                MessageBox.Show(@"该任务未完成，无法查看", @"警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            new InventoryCheckingReportForm(taskName).Show();
            InstanceForm.Hide();
        }

        /// <summary>
        /// 彻底关闭窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewInventoryCheckingTaskForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
