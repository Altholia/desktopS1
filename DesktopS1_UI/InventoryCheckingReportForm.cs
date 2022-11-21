using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DesktopS1_BLL;
using DesktopS1_Helper;
using DesktopS1_Model.DisplayDto;
using static DesktopS1_BLL.InventoryCheckingReportFormBll;
using ItextSharpHelper;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace DesktopS1_UI
{
    public partial class InventoryCheckingReportForm : Form
    {
        private readonly string _taskName;

        public InventoryCheckingReportForm()
        {
            InitializeComponent();
        }

        public InventoryCheckingReportForm(string taskName)
        {
            InitializeComponent();
            _taskName = taskName;
        }

        private async void InventoryCheckingReportForm_Load(object sender, EventArgs e)
        {
            //另开线程查询数据和对UI界面赋值，防止UI界面出现假死状态
            await Task.Run(async () =>
            {
                (InventoryCheckingTaskDisplayDto informationDto, int taskId) =
                    await InstanceBll.GetInventoryCheckingTaskByTaskNameAsync(_taskName);

                (List<CheckExceptionDisplayDto> checkExceptions, List<ReplenishedDisplayDto> replenishedDtos) =
                    await InstanceBll.GetCheckExceptionsAsync(taskId);

                Invoke(new Action(() =>
                {
                    int index = 1;
                    for (int row = 0; row < Information_TableLayoutPanel.RowCount; row++)
                    {
                        for (int column = 1; column < Information_TableLayoutPanel.ColumnCount; column += 2)
                        {
                            if (index == 8)
                                break;

                            Label label = new Label
                            {
                                Text = informationDto[index].ToString(),
                                Font = new System.Drawing.Font(@"宋体", 12f),
                                Margin = new Padding(0),
                                TextAlign = ContentAlignment.MiddleLeft,
                                Dock = DockStyle.Fill,
                                BackColor = Color.White
                            };
                            Information_TableLayoutPanel.Controls.Add(label, column, row);
                            index++;
                        }
                    }

                    CheckAmount_DataGridView.Rows.Clear();
                    foreach (var checkException in checkExceptions)
                    {
                        int row = CheckAmount_DataGridView.Rows.Add();
                        for (int column = 0; column < CheckAmount_DataGridView.ColumnCount; column++)
                        {
                            CheckAmount_DataGridView.Rows[row].Cells[column].Value = checkException[column];
                        }
                    }

                    Replenishment_DataGridView.Rows.Clear();
                    foreach (var replenishedDto in replenishedDtos)
                    {
                        int row = Replenishment_DataGridView.Rows.Add();
                        for (int column = 0; column < Replenishment_DataGridView.ColumnCount; column++)
                        {
                            Replenishment_DataGridView.Rows[row].Cells[column].Value = replenishedDto[column];
                        }
                    }
                }));
            });
        }

        private void InventoryCheckingReportForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Print_Button_Click(object sender, EventArgs e)
        {
            StringBuilder headerBuilder=new StringBuilder();
            headerBuilder.Append(label1.Text);
            headerBuilder.Append(",");
            headerBuilder.Append(label2.Text);
            headerBuilder.Append(",");
            headerBuilder.Append(label10.Text);
            headerBuilder.Append(",");
            headerBuilder.Append(label11.Text);

            int currentCell = 0;
            int informationCellTotal = Information_TableLayoutPanel.RowCount * Information_TableLayoutPanel.ColumnCount;
            StringBuilder informationBuilder = new StringBuilder();
            for (int row = 0; row < Information_TableLayoutPanel.RowCount; row++)
            {
                for (int column = 0; column < Information_TableLayoutPanel.ColumnCount; column++)
                {
                    Control control = Information_TableLayoutPanel.GetControlFromPosition(column, row);
                    var _ = control != null
                        ? informationBuilder.Append(control.Text)
                        : informationBuilder.Append(default(string));

                    if (currentCell < informationCellTotal - 1)
                        informationBuilder.Append(",");

                    currentCell++;
                }
            }

            StringBuilder checkAmountBuilder = new StringBuilder();
            for (int column = 0; column < CheckAmount_DataGridView.Columns.Count; column++)
            {
                checkAmountBuilder.Append(CheckAmount_DataGridView.Columns[column].Name);
                checkAmountBuilder.Append(",");
            }

            for (int row = 0; row < CheckAmount_DataGridView.Rows.Count; row++)
            {
                DataGridViewRow dataRow=CheckAmount_DataGridView.Rows[row];
                for (int column = 0; column < CheckAmount_DataGridView.ColumnCount; column++)
                {
                    checkAmountBuilder.Append(dataRow.Cells[column].Value);
                    checkAmountBuilder.Append(",");
                }
            }

            StringBuilder partBuilder = new StringBuilder();
            for (int column = 0; column < Replenishment_DataGridView.ColumnCount; column++)
            {
                partBuilder.Append(Replenishment_DataGridView.Columns[column].Name);
                partBuilder.Append(",");
            }

            for (int row = 0; row < Replenishment_DataGridView.Rows.Count; row++)
            {
                DataGridViewRow dataRow = Replenishment_DataGridView.Rows[row];
                for (int column = 0; column < Replenishment_DataGridView.ColumnCount; column++)
                {
                    partBuilder.Append(dataRow.Cells[column].Value);
                    partBuilder.Append(",");
                }
            }

            GeneratePdf generate = new GeneratePdf();
            generate.CreatePdf(headerBuilder, informationBuilder, checkAmountBuilder, partBuilder);
            FileStream fs = new FileStream("D:/Inventory.pdf", FileMode.Create);
            fs.Write(generate.DocumentBytes, 0, generate.DocumentBytes.Length);
            fs.Close();
        }
    }
}
