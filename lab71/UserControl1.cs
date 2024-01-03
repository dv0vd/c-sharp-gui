using System;
using System.Drawing;
using System.Windows.Forms;

namespace lab71
{
    public partial class UserControl1 : UserControl
    {
        int y;

        void timer_Tick(object sender, EventArgs e)
        {
            Random r = new Random();
            this.BackColor = Color.FromArgb(r.Next(255), r.Next(255), r.Next(255), r.Next(255));
        }

        public UserControl1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Location = new Point(0, y);
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            y = this.Top;
            Timer timer = new Timer() { Interval = 1000 };
            timer.Tick += timer_Tick;
            timer.Start();
            ToolTip t = new ToolTip();
            t.SetToolTip(this, "Выравание(лево, центр, право) и отображение цвета");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int sizeParent = this.Parent.Width;
            int sizeChild = this.Width;
            this.Location = new Point((sizeParent - sizeChild)/2, y);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int sizeParent = this.Parent.Width;
            int sizeChild = this.Width;
            this.Location = new Point(sizeParent - sizeChild, y);
        }
    }
}
