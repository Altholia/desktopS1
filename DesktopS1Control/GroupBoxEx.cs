using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopS1Control
{
    public partial class GroupBoxEx : GroupBox
    {
        private Color _borderColor = Color.Black;

        [Browsable(true), Description("边框颜色"), Category("自定义分组")]
        public Color BorderColor
        {
            get => _borderColor;
            set
            {
                _borderColor = value;
                this.Invalidate();
            }
        }

        public GroupBoxEx()
        {
            InitializeComponent();
        }

        public GroupBoxEx(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var vSize = e.Graphics.MeasureString(this.Text, this.Font);

            e.Graphics.Clear(this.BackColor);
            e.Graphics.DrawString(this.Text,this.Font,new SolidBrush(this.ForeColor),10,1);

            Pen vPen = new Pen(this._borderColor);
            e.Graphics.DrawLine(vPen, 1,vSize.Height / 2, 8, vSize.Height / 2);
            e.Graphics.DrawLine(vPen, vSize.Width + 8, vSize.Height / 2, this.Width - 2, vSize.Height / 2);
            e.Graphics.DrawLine(vPen, 1, vSize.Height / 2, 1, this.Height - 2);
            e.Graphics.DrawLine(vPen, 1, this.Height - 2, this.Width - 2, this.Height - 2);
            e.Graphics.DrawLine(vPen, this.Width - 2, vSize.Height / 2, this.Width - 2, this.Height - 2);

        }
    }
}
