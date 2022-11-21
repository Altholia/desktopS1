using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DesktopS1_Helper;
using DesktopS1_Model.DisplayDto;
using static DesktopS1_BLL.InputInventoryCheckingResultFormBll;

namespace DesktopS1_UI
{
    public partial class InputInventoryCheckingResultForm : Form
    {
        private readonly InputImportPanelDisplayDto _dto;
        private IEnumerable<InformationDataGridViewDisplayDto> _dtos;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        public InputInventoryCheckingResultForm()
        {
            InitializeComponent();
        }

        public InputInventoryCheckingResultForm(InputImportPanelDisplayDto dto)
        {
            InitializeComponent();
            _dto = dto;
        }

        private async void InputInventoryCheckingResult_Load(object sender, EventArgs e)
        {
            AutoSave_RadioButton1.Checked = true;

            WarehouseName_Label.Text = _dto.WarehouseName;
            TaskName_Label.Text = _dto.TaskName;
            TaskType_Label.Text = _dto.TaskType;

            int taskId = await InstanceBll.GetTaskIdByTaskNameAsync(TaskName_Label.Text.Trim());

            _dtos = await InstanceBll.GetInformationDataGridViewDtoAsync(WarehouseName_Label.Text.Trim(), taskId);

            if (_dtos == null)
            {
                MessageBox.Show(@"没有任何数据", @"警告", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning);
                return;
            }

            int stockAmountSum = _dtos.Sum(r => r.StockAmount);
            int checkAmountSum = (int)_dtos.Sum(r => r.CheckAmount);


            float check = checkAmountSum / (float)stockAmountSum * 100f;
            float stock = 100f - check;

            Progress_TableLayoutPanel.ColumnStyles[0] = new ColumnStyle(SizeType.Percent, check);
            Progress_TableLayoutPanel.ColumnStyles[1] = new ColumnStyle(SizeType.Percent, stock);

            Label checkLabel = new Label
            {
                Text = $@"{checkAmountSum}",
                Font = new Font(@"宋体", 15f),
                BackColor = Color.LawnGreen,
                Dock = DockStyle.Fill,
                Margin = new Padding(0),
                TextAlign = ContentAlignment.MiddleCenter
            };

            Label stockLabel = new Label
            {
                Text = $@"{stockAmountSum- checkAmountSum}",
                Font = new Font(@"宋体", 15f),
                BackColor = Color.Red,
                Dock = DockStyle.Fill,
                Margin = new Padding(0),
                TextAlign = ContentAlignment.MiddleCenter
            };

            Progress_TableLayoutPanel.Controls.Add(checkLabel, 0, 0);
            Progress_TableLayoutPanel.Controls.Add(stockLabel, 1, 0);

            foreach (var dto in _dtos)
            {
                int row = Information_DataGridView.Rows.Add();
                for (int column = 0; column < Information_DataGridView.ColumnCount; column++)
                {
                    Information_DataGridView.Rows[row].Cells[column].Value = dto[column];
                }
            }
        }

        private void AutoSaveRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!(sender is RadioButton radioButton))
            {
                MessageBox.Show(@"未选择自动保存时间间隔", @"警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int interval = int.Parse(radioButton.Text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1]);

            //添加自动保存事件
            AutoSave autoSave = new AutoSave(interval);
            var thread = new Thread(autoSave.MonitorAutoSave)
            {
                IsBackground = true
            };
            thread.Start();
            autoSave.AutoSaveEvent += OnAutoSave;
        }

        /// <summary>
        /// 是否显示未盘点数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnlyShow_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Information_DataGridView.Rows.Clear();

            if (OnlyShow_CheckBox.Checked)
            {
                foreach (var dto in _dtos)
                {
                    if (dto.CheckAmount == null)
                        continue;

                    int row = Information_DataGridView.Rows.Add();
                    for (int column = 0; column < Information_DataGridView.ColumnCount; column++)
                    {
                        Information_DataGridView.Rows[row].Cells[column].Value = dto[column];
                    }
                }
                return;
            }

            foreach (var dto in _dtos)
            {
                int row = Information_DataGridView.Rows.Add();
                for (int column = 0; column < Information_DataGridView.ColumnCount; column++)
                {
                    Information_DataGridView.Rows[row].Cells[column].Value = dto[column];
                }
            }
        }

        /// <summary>
        /// 将数据网格中的数据导出为xlsx
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Download_Button_Click(object sender, EventArgs e)
        {
            string fileName = @"D:\test.xlsx";
            FileStream fs = new FileStream(fileName, FileMode.Create);

            StreamWriter sw = new StreamWriter(fs);

            StringBuilder sb = new StringBuilder();
            for (int column = 0; column < Information_DataGridView.Columns.Count-1; column++)
            {
                sb.Append(Information_DataGridView.Columns[column].Name);//获取列表头的值，并将每个值都用逗号隔开
                if (column < Information_DataGridView.ColumnCount - 2)
                    sb.Append(",");
            }
            sb.Append(Environment.NewLine);//在末尾添加一个换行符

            for (int row = 0; row < Information_DataGridView.RowCount; row++)
            {
                DataGridViewRow dataRow = Information_DataGridView.Rows[row];//获取行数据
                for (int column = 0; column < Information_DataGridView.Columns.Count-1; column++)
                {
                    sb.Append(dataRow.Cells[column].Value);//将每行的每列数据追加到末尾，并以逗号分割
                    if (column < Information_DataGridView.ColumnCount - 2)
                        sb.Append(",");
                }
                sb.Append(Environment.NewLine);
            }

            var items = sb.ToString().Split(new[] { ',' });

            Thread thread = new Thread(async () =>
            {

                foreach (var item in items)
                {
                    await sw.WriteAsync($"{item}\t");
                }

                await sw.FlushAsync();
                sw.Close();
                sw.Dispose();
            })
            {
                IsBackground = true
            };

            await Task.Run(() =>
            {
                thread.Start();
                while (true)
                {
                    if (!thread.IsAlive)
                    {
                        MessageBox.Show(@"下载完毕", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            });
        }

        private async void Save_Button_Click(object sender, EventArgs e)
        {
            if (Information_DataGridView.Rows.Count == 0)//如果数据为空，则不进行下面的操作，并给予用户一定的提示
            {
                MessageBox.Show(@"没有数据需要保存", @"提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                return;
            }

            //获取保存的参数，用来查询TaskDetail
            List<InputInventorySaveParameter> parameters = new List<InputInventorySaveParameter>();
            for (int row = 0; row < Information_DataGridView.RowCount; row++)
            {
                InputInventorySaveParameter dto = new InputInventorySaveParameter
                {
                    TaskName = TaskName_Label.Text.Trim(),
                    PartName = Information_DataGridView.Rows[row].Cells[3].Value.ToString(),
                    CheckAmount = Convert.ToInt32(Information_DataGridView.Rows[row].Cells[7].Value)
                };
                parameters.Add(dto);
            }

            if (await InstanceBll.SaveTaskDetailAsync(parameters))
                MessageBox.Show(@"保存成功", @"成功", MessageBoxButtons.OK, MessageBoxIcon.None);
            else
                MessageBox.Show(@"保存失败", @"失败", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
        }

        /// <summary>
        /// 自动保存事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void OnAutoSave(object sender, EventArgs e)
        {
            if (Information_DataGridView.Rows.Count == 0)
                return;

            List<InputInventorySaveParameter> parameters = new List<InputInventorySaveParameter>();
            for (int row = 0; row < Information_DataGridView.RowCount; row++)
            {
                InputInventorySaveParameter dto = new InputInventorySaveParameter
                {
                    TaskName = TaskName_Label.Text.Trim(),
                    PartName = Information_DataGridView.Rows[row].Cells[3].Value.ToString(),
                    CheckAmount = Convert.ToInt32(Information_DataGridView.Rows[row].Cells[7].Value)
                };
                parameters.Add(dto);
            }

            await InstanceBll.SaveTaskDetailAsync(parameters);
        }

        private async void Submit_Button_Click(object sender, EventArgs e)
        {
            for (int row = 0; row < Information_DataGridView.RowCount; row++)
            {
                var checkAmount = Information_DataGridView.Rows[row].Cells[7].Value;
                if (checkAmount == null)
                {
                    MessageBox.Show(@"您还有任务未盘点完成，无法更改状态为“Finished”", @"警告", MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Warning);
                    return;
                }
            }

            Thread thread = new Thread(async () =>
            {
                await ViewInventoryCheckingTaskForm.InstanceForm.ChangeStatus(StatusEnum.Finished, DateTime.Now);
            })
            {
                IsBackground = true
            };

            await Task.Run(() =>
            {
                thread.Start();
                while (true)
                {
                    if (!thread.IsAlive)
                    {
                        MessageBox.Show(@"保存成功，点击Ok跳转至InventoryCheckingReport窗口", @"成功", MessageBoxButtons.OK, MessageBoxIcon.None);
                        Action action = () =>
                        {
                            string taskName = TaskName_Label.Text.Trim();
                            new InventoryCheckingReportForm(taskName).Show();
                            Hide();
                        };
                        Invoke(action);
                        return;
                    }
                }
            });
        }

        private async void InputInventoryCheckingResultForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            await ViewInventoryCheckingTaskForm.InstanceForm.Search_Button_Click();
            ViewInventoryCheckingTaskForm.InstanceForm.Show();
        }
    }
}
