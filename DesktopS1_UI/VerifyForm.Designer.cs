namespace DesktopS1_UI
{
    partial class VerifyForm
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
            this.VerifyControl = new DesktopS1Control.VerifyControl();
            this.SuspendLayout();
            // 
            // VerifyControl
            // 
            this.VerifyControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VerifyControl.Location = new System.Drawing.Point(0, 0);
            this.VerifyControl.Name = "VerifyControl";
            this.VerifyControl.Size = new System.Drawing.Size(453, 357);
            this.VerifyControl.TabIndex = 0;
            // 
            // VerifyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 357);
            this.Controls.Add(this.VerifyControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VerifyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VerifyForm";
            this.Load += new System.EventHandler(this.VerifyForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DesktopS1Control.VerifyControl VerifyControl;
    }
}