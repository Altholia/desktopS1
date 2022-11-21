namespace DesktopS1_UI
{
    partial class SelectZoneForm
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
            this.WarehouseLayout_Panel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // WarehouseLayout_Panel
            // 
            this.WarehouseLayout_Panel.AutoScroll = true;
            this.WarehouseLayout_Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.WarehouseLayout_Panel.Location = new System.Drawing.Point(0, 0);
            this.WarehouseLayout_Panel.Margin = new System.Windows.Forms.Padding(0);
            this.WarehouseLayout_Panel.Name = "WarehouseLayout_Panel";
            this.WarehouseLayout_Panel.Size = new System.Drawing.Size(459, 394);
            this.WarehouseLayout_Panel.TabIndex = 6;
            // 
            // SelectZoneForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 394);
            this.Controls.Add(this.WarehouseLayout_Panel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "SelectZoneForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SelectZoneForm";
            this.Load += new System.EventHandler(this.SelectZoneForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel WarehouseLayout_Panel;
    }
}