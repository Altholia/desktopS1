using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopS1_UI
{
    public partial class VerifyForm : Form
    {

        private Point _location;//记录A_PictureBox的初始位置
        private int _y;

        public VerifyForm()
        {
            InitializeComponent();
        }

        private void VerifyForm_Load(object sender, EventArgs e)
        {
            VerifyControl.VerifyScrollBar.MouseLeave += VerifyScrollBar_MouseLeave;//添加滑块移动验证事件
            VerifyControl.VerifyScrollBar.Scroll += VerifyScrollBar_Scroll;
            VerifyControl.PictureBox.Click += PictureBox_Click;

            _location = VerifyControl.A_PictureBox.Location;
            _y = VerifyControl.A_PictureBox.Location.Y;
        }

        /// <summary>
        /// 滑块移动验证
        /// 验证图片是否移动到合适的位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VerifyScrollBar_MouseLeave(object sender, EventArgs e)
        {
            int x = VerifyControl.B_PictureBox.Location.X;

            if ((VerifyControl.A_PictureBox.Location.X >= x - 3) && (VerifyControl.A_PictureBox.Location.X <= x + 3))
            {
                MessageBox.Show(@"验证成功，点击OK返回登录界面！", @"成功", MessageBoxButtons.OK, MessageBoxIcon.None);
                this.Close();
            }
            else
            {
                VerifyControl.A_PictureBox.Location = _location;
                VerifyControl.VerifyScrollBar.Value = _location.X;
            }
        }

        private void VerifyScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            int x = VerifyControl.VerifyScrollBar.Value;
            VerifyControl.A_PictureBox.Location = new Point(x, _location.Y);
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int x1 = random.Next(24, 150);
            int y1 = random.Next(0, 130);

            int x2 = random.Next(180, 300);

            VerifyControl.A_PictureBox.Location = new Point(x1, y1);
            VerifyControl.B_PictureBox.Location = new Point(x2, y1);

            VerifyControl.VerifyScrollBar.Minimum = x1;
            VerifyControl.VerifyScrollBar.Value = x1;

            _location = VerifyControl.A_PictureBox.Location;
        }
    }
}
