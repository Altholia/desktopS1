namespace DesktopS1_UI
{
    partial class ViewInventoryCheckingTaskForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Warehouse_ComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TaskType_ComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Status_ComboBox = new System.Windows.Forms.ComboBox();
            this.Search_Button = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.Start_Button = new System.Windows.Forms.Button();
            this.Input_Button = new System.Windows.Forms.Button();
            this.View_Button = new System.Windows.Forms.Button();
            this.Inventory_DataGridView = new System.Windows.Forms.DataGridView();
            this.Seq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WarehouseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InventoryCheckingTaskName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaskType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FinishDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Inventory_DataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(516, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(432, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "View Inventory Checking Task";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(81, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Warehouse:";
            // 
            // Warehouse_ComboBox
            // 
            this.Warehouse_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Warehouse_ComboBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Warehouse_ComboBox.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Warehouse_ComboBox.FormattingEnabled = true;
            this.Warehouse_ComboBox.Items.AddRange(new object[] {
            "All"});
            this.Warehouse_ComboBox.Location = new System.Drawing.Point(206, 78);
            this.Warehouse_ComboBox.Name = "Warehouse_ComboBox";
            this.Warehouse_ComboBox.Size = new System.Drawing.Size(275, 28);
            this.Warehouse_ComboBox.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(521, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Task Type:";
            // 
            // TaskType_ComboBox
            // 
            this.TaskType_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TaskType_ComboBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.TaskType_ComboBox.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TaskType_ComboBox.FormattingEnabled = true;
            this.TaskType_ComboBox.Items.AddRange(new object[] {
            "All"});
            this.TaskType_ComboBox.Location = new System.Drawing.Point(646, 78);
            this.TaskType_ComboBox.Name = "TaskType_ComboBox";
            this.TaskType_ComboBox.Size = new System.Drawing.Size(229, 28);
            this.TaskType_ComboBox.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(915, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Status:";
            // 
            // Status_ComboBox
            // 
            this.Status_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Status_ComboBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Status_ComboBox.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Status_ComboBox.FormattingEnabled = true;
            this.Status_ComboBox.Items.AddRange(new object[] {
            "All"});
            this.Status_ComboBox.Location = new System.Drawing.Point(1007, 78);
            this.Status_ComboBox.Name = "Status_ComboBox";
            this.Status_ComboBox.Size = new System.Drawing.Size(180, 28);
            this.Status_ComboBox.TabIndex = 2;
            // 
            // Search_Button
            // 
            this.Search_Button.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Search_Button.Location = new System.Drawing.Point(1240, 75);
            this.Search_Button.Name = "Search_Button";
            this.Search_Button.Size = new System.Drawing.Size(106, 33);
            this.Search_Button.TabIndex = 3;
            this.Search_Button.Text = "search";
            this.Search_Button.UseVisualStyleBackColor = true;
            this.Search_Button.Click += new System.EventHandler(this.Search_Button_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Location = new System.Drawing.Point(21, 131);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(11, 47);
            this.panel1.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(38, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(262, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "Inventory Checking Task";
            // 
            // Start_Button
            // 
            this.Start_Button.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Start_Button.Location = new System.Drawing.Point(756, 810);
            this.Start_Button.Name = "Start_Button";
            this.Start_Button.Size = new System.Drawing.Size(86, 36);
            this.Start_Button.TabIndex = 8;
            this.Start_Button.Text = "Start";
            this.Start_Button.UseVisualStyleBackColor = true;
            this.Start_Button.Click += new System.EventHandler(this.Start_Button_Click);
            // 
            // Input_Button
            // 
            this.Input_Button.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Input_Button.Location = new System.Drawing.Point(848, 810);
            this.Input_Button.Name = "Input_Button";
            this.Input_Button.Size = new System.Drawing.Size(214, 36);
            this.Input_Button.TabIndex = 8;
            this.Input_Button.Text = "Input Inventory Result";
            this.Input_Button.UseVisualStyleBackColor = true;
            this.Input_Button.Click += new System.EventHandler(this.Input_Button_Click);
            // 
            // View_Button
            // 
            this.View_Button.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.View_Button.Location = new System.Drawing.Point(1068, 810);
            this.View_Button.Name = "View_Button";
            this.View_Button.Size = new System.Drawing.Size(288, 36);
            this.View_Button.TabIndex = 8;
            this.View_Button.Text = "View Inventory Checking Report";
            this.View_Button.UseVisualStyleBackColor = true;
            this.View_Button.Click += new System.EventHandler(this.View_Button_Click);
            // 
            // Inventory_DataGridView
            // 
            this.Inventory_DataGridView.AllowUserToAddRows = false;
            this.Inventory_DataGridView.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Inventory_DataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Inventory_DataGridView.ColumnHeadersHeight = 40;
            this.Inventory_DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.Inventory_DataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seq,
            this.WarehouseName,
            this.InventoryCheckingTaskName,
            this.TaskType,
            this.CreateTime,
            this.StartDate,
            this.FinishDate,
            this.Status});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Inventory_DataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.Inventory_DataGridView.Location = new System.Drawing.Point(21, 184);
            this.Inventory_DataGridView.MultiSelect = false;
            this.Inventory_DataGridView.Name = "Inventory_DataGridView";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Inventory_DataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.Inventory_DataGridView.RowHeadersWidth = 50;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 12F);
            this.Inventory_DataGridView.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.Inventory_DataGridView.RowTemplate.Height = 50;
            this.Inventory_DataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Inventory_DataGridView.Size = new System.Drawing.Size(1335, 620);
            this.Inventory_DataGridView.TabIndex = 0;
            // 
            // Seq
            // 
            this.Seq.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Seq.HeaderText = "Seq.";
            this.Seq.Name = "Seq";
            this.Seq.ReadOnly = true;
            this.Seq.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Seq.Width = 50;
            // 
            // WarehouseName
            // 
            this.WarehouseName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.WarehouseName.HeaderText = "WarehouseName";
            this.WarehouseName.Name = "WarehouseName";
            this.WarehouseName.ReadOnly = true;
            this.WarehouseName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.WarehouseName.Width = 200;
            // 
            // InventoryCheckingTaskName
            // 
            this.InventoryCheckingTaskName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.InventoryCheckingTaskName.HeaderText = "InventoryCheckingTaskName";
            this.InventoryCheckingTaskName.Name = "InventoryCheckingTaskName";
            this.InventoryCheckingTaskName.ReadOnly = true;
            this.InventoryCheckingTaskName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.InventoryCheckingTaskName.Width = 250;
            // 
            // TaskType
            // 
            this.TaskType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TaskType.HeaderText = "TaskType";
            this.TaskType.Name = "TaskType";
            this.TaskType.ReadOnly = true;
            this.TaskType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TaskType.Width = 150;
            // 
            // CreateTime
            // 
            this.CreateTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CreateTime.HeaderText = "CreateTime";
            this.CreateTime.Name = "CreateTime";
            this.CreateTime.ReadOnly = true;
            this.CreateTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CreateTime.Width = 200;
            // 
            // StartDate
            // 
            this.StartDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.StartDate.HeaderText = "StartDate";
            this.StartDate.Name = "StartDate";
            this.StartDate.ReadOnly = true;
            this.StartDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.StartDate.Width = 150;
            // 
            // FinishDate
            // 
            this.FinishDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.FinishDate.HeaderText = "FinishDate";
            this.FinishDate.Name = "FinishDate";
            this.FinishDate.ReadOnly = true;
            this.FinishDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FinishDate.Width = 150;
            // 
            // Status
            // 
            this.Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ViewInventoryCheckingTaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1368, 868);
            this.Controls.Add(this.Inventory_DataGridView);
            this.Controls.Add(this.View_Button);
            this.Controls.Add(this.Input_Button);
            this.Controls.Add(this.Start_Button);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Search_Button);
            this.Controls.Add(this.Status_ComboBox);
            this.Controls.Add(this.TaskType_ComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Warehouse_ComboBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ViewInventoryCheckingTaskForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Skyward Company Management System";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ViewInventoryCheckingTaskForm_FormClosed);
            this.Load += new System.EventHandler(this.ViewInventoryCheckingTaskForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Inventory_DataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox Warehouse_ComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox TaskType_ComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox Status_ComboBox;
        private System.Windows.Forms.Button Search_Button;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Start_Button;
        private System.Windows.Forms.Button Input_Button;
        private System.Windows.Forms.Button View_Button;
        private System.Windows.Forms.DataGridViewTextBoxColumn Seq;
        private System.Windows.Forms.DataGridViewTextBoxColumn WarehouseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn InventoryCheckingTaskName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaskType;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn FinishDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        public System.Windows.Forms.DataGridView Inventory_DataGridView;
    }
}