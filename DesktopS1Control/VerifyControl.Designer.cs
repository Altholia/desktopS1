namespace DesktopS1Control
{
    partial class VerifyControl
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VerifyControl));
            this.panel1 = new System.Windows.Forms.Panel();
            this.VerifyScrollBar = new System.Windows.Forms.HScrollBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.A_PictureBox = new System.Windows.Forms.PictureBox();
            this.B_PictureBox = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PictureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.A_PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.B_PictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.VerifyScrollBar);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.PictureBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(19, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(427, 336);
            this.panel1.TabIndex = 0;
            // 
            // VerifyScrollBar
            // 
            this.VerifyScrollBar.Location = new System.Drawing.Point(0, 281);
            this.VerifyScrollBar.Maximum = 310;
            this.VerifyScrollBar.Minimum = 24;
            this.VerifyScrollBar.Name = "VerifyScrollBar";
            this.VerifyScrollBar.Size = new System.Drawing.Size(425, 53);
            this.VerifyScrollBar.TabIndex = 4;
            this.VerifyScrollBar.Value = 24;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightBlue;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.A_PictureBox);
            this.panel2.Controls.Add(this.B_PictureBox);
            this.panel2.Location = new System.Drawing.Point(17, 92);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(392, 186);
            this.panel2.TabIndex = 3;
            // 
            // A_PictureBox
            // 
            this.A_PictureBox.ErrorImage = ((System.Drawing.Image)(resources.GetObject("A_PictureBox.ErrorImage")));
            this.A_PictureBox.Image = ((System.Drawing.Image)(resources.GetObject("A_PictureBox.Image")));
            this.A_PictureBox.Location = new System.Drawing.Point(24, 24);
            this.A_PictureBox.Name = "A_PictureBox";
            this.A_PictureBox.Size = new System.Drawing.Size(66, 61);
            this.A_PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.A_PictureBox.TabIndex = 0;
            this.A_PictureBox.TabStop = false;
            // 
            // B_PictureBox
            // 
            this.B_PictureBox.ErrorImage = ((System.Drawing.Image)(resources.GetObject("B_PictureBox.ErrorImage")));
            this.B_PictureBox.Image = ((System.Drawing.Image)(resources.GetObject("B_PictureBox.Image")));
            this.B_PictureBox.Location = new System.Drawing.Point(292, 24);
            this.B_PictureBox.Name = "B_PictureBox";
            this.B_PictureBox.Size = new System.Drawing.Size(66, 61);
            this.B_PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.B_PictureBox.TabIndex = 0;
            this.B_PictureBox.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(14, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(386, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Please drag the slider to fit the vacancy.";
            // 
            // PictureBox
            // 
            this.PictureBox.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox.Image")));
            this.PictureBox.Location = new System.Drawing.Point(338, 6);
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.Size = new System.Drawing.Size(84, 44);
            this.PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBox.TabIndex = 1;
            this.PictureBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(14, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Security Verification";
            // 
            // VerifyControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "VerifyControl";
            this.Size = new System.Drawing.Size(464, 361);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.A_PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.B_PictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.HScrollBar VerifyScrollBar;
        public System.Windows.Forms.PictureBox A_PictureBox;
        public System.Windows.Forms.PictureBox B_PictureBox;
        public System.Windows.Forms.PictureBox PictureBox;
    }
}
