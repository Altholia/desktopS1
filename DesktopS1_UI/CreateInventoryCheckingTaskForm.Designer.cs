namespace DesktopS1_UI
{
    partial class CreateInventoryCheckingTaskForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Warehouse_ComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TaskName_TextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TaskType_ComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.StartDate_DateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label13 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.Checked_TableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Submit_Button = new System.Windows.Forms.Button();
            this.SelectZone_Button = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(248, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(462, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Create Inventory Checking Task";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(12, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Warehouse:";
            // 
            // Warehouse_ComboBox
            // 
            this.Warehouse_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Warehouse_ComboBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Warehouse_ComboBox.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Warehouse_ComboBox.FormattingEnabled = true;
            this.Warehouse_ComboBox.Location = new System.Drawing.Point(127, 95);
            this.Warehouse_ComboBox.Name = "Warehouse_ComboBox";
            this.Warehouse_ComboBox.Size = new System.Drawing.Size(214, 28);
            this.Warehouse_ComboBox.TabIndex = 2;
            this.Warehouse_ComboBox.TextChanged += new System.EventHandler(this.Warehouse_ComboBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(12, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Task Name:";
            // 
            // TaskName_TextBox
            // 
            this.TaskName_TextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TaskName_TextBox.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TaskName_TextBox.Location = new System.Drawing.Point(127, 135);
            this.TaskName_TextBox.Name = "TaskName_TextBox";
            this.TaskName_TextBox.Size = new System.Drawing.Size(713, 30);
            this.TaskName_TextBox.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(12, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Task Type:";
            // 
            // TaskType_ComboBox
            // 
            this.TaskType_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TaskType_ComboBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.TaskType_ComboBox.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TaskType_ComboBox.FormattingEnabled = true;
            this.TaskType_ComboBox.Location = new System.Drawing.Point(127, 177);
            this.TaskType_ComboBox.Name = "TaskType_ComboBox";
            this.TaskType_ComboBox.Size = new System.Drawing.Size(214, 28);
            this.TaskType_ComboBox.TabIndex = 2;
            this.TaskType_ComboBox.TextChanged += new System.EventHandler(this.TaskType_ComboBox_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(442, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "Start Date:";
            // 
            // StartDate_DateTimePicker
            // 
            this.StartDate_DateTimePicker.CustomFormat = "yyyy/MM/dd";
            this.StartDate_DateTimePicker.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.StartDate_DateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.StartDate_DateTimePicker.Location = new System.Drawing.Point(567, 177);
            this.StartDate_DateTimePicker.Name = "StartDate_DateTimePicker";
            this.StartDate_DateTimePicker.Size = new System.Drawing.Size(143, 30);
            this.StartDate_DateTimePicker.TabIndex = 4;
            this.StartDate_DateTimePicker.ValueChanged += new System.EventHandler(this.StartDate_DateTimePicker_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(13, 234);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(248, 18);
            this.label6.TabIndex = 1;
            this.label6.Text = "Parts to be checked(80):";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 79F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 198F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 151F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 144F));
            this.tableLayoutPanel1.Controls.Add(this.label13, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label12, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.label8, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label11, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label9, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label10, 3, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(16, 255);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(824, 33);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(687, 1);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(138, 31);
            this.label13.TabIndex = 1;
            this.label13.Text = "StockAmount";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(4, 1);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 31);
            this.label7.TabIndex = 1;
            this.label7.Text = "Seq.";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(535, 1);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(145, 31);
            this.label12.TabIndex = 1;
            this.label12.Text = "Specification";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(80, 1);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 31);
            this.label8.TabIndex = 1;
            this.label8.Text = "Zone";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(454, 1);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 31);
            this.label11.TabIndex = 1;
            this.label11.Text = "Unit";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(160, 1);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 31);
            this.label9.TabIndex = 1;
            this.label9.Text = "PartId";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(255, 1);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(192, 31);
            this.label10.TabIndex = 1;
            this.label10.Text = "PartName";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Checked_TableLayoutPanel
            // 
            this.Checked_TableLayoutPanel.AutoSize = true;
            this.Checked_TableLayoutPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.Checked_TableLayoutPanel.ColumnCount = 7;
            this.Checked_TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.Checked_TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 79F));
            this.Checked_TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.Checked_TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 198F));
            this.Checked_TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.Checked_TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 151F));
            this.Checked_TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.Checked_TableLayoutPanel.Location = new System.Drawing.Point(0, 3);
            this.Checked_TableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.Checked_TableLayoutPanel.Name = "Checked_TableLayoutPanel";
            this.Checked_TableLayoutPanel.RowCount = 6;
            this.Checked_TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.Checked_TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.Checked_TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.Checked_TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.Checked_TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.Checked_TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.Checked_TableLayoutPanel.Size = new System.Drawing.Size(825, 307);
            this.Checked_TableLayoutPanel.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.Checked_TableLayoutPanel);
            this.panel1.Location = new System.Drawing.Point(16, 284);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(842, 313);
            this.panel1.TabIndex = 5;
            // 
            // Submit_Button
            // 
            this.Submit_Button.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Submit_Button.Location = new System.Drawing.Point(744, 616);
            this.Submit_Button.Name = "Submit_Button";
            this.Submit_Button.Size = new System.Drawing.Size(95, 35);
            this.Submit_Button.TabIndex = 6;
            this.Submit_Button.Text = "Submit";
            this.Submit_Button.UseVisualStyleBackColor = true;
            this.Submit_Button.Click += new System.EventHandler(this.Submit_Button_Click);
            // 
            // SelectZone_Button
            // 
            this.SelectZone_Button.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SelectZone_Button.Location = new System.Drawing.Point(567, 616);
            this.SelectZone_Button.Name = "SelectZone_Button";
            this.SelectZone_Button.Size = new System.Drawing.Size(157, 35);
            this.SelectZone_Button.TabIndex = 6;
            this.SelectZone_Button.Text = "Select Zone";
            this.SelectZone_Button.UseVisualStyleBackColor = true;
            this.SelectZone_Button.Click += new System.EventHandler(this.SelectZone_Button_Click);
            // 
            // CreateInventoryCheckingTaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 670);
            this.Controls.Add(this.SelectZone_Button);
            this.Controls.Add(this.Submit_Button);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.StartDate_DateTimePicker);
            this.Controls.Add(this.TaskName_TextBox);
            this.Controls.Add(this.TaskType_ComboBox);
            this.Controls.Add(this.Warehouse_ComboBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "CreateInventoryCheckingTaskForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Skyward Company Management System";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CreateInventoryCheckingTaskForm_FormClosed);
            this.Load += new System.EventHandler(this.CreateInventoryCheckingTaskForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox Warehouse_ComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TaskName_TextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox TaskType_ComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker StartDate_DateTimePicker;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TableLayoutPanel Checked_TableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Submit_Button;
        private System.Windows.Forms.Button SelectZone_Button;
    }
}