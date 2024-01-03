using System;
using System.Windows.Forms;

namespace lab71
{
    public partial class UserControl3 : UserControl
    {
        public static Form1 form;

        public UserControl3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (ToolStripItem menuItem in form.menuStrip1.Items)
            {
                menuItem.Visible = false;
            }
            LoadListBoxes();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (ToolStripItem menuItem in form.menuStrip1.Items)
            {
                menuItem.Visible = true;
            }
            LoadListBoxes();
        }

        private void LoadListBoxes()
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            foreach (ToolStripItem menuItem in form.menuStrip1.Items)
            {
                if (menuItem.Visible)
                    listBox1.Items.Add(menuItem.Text);
                else
                    listBox2.Items.Add(menuItem.Text);
            }
        }

        private void UserControl3_Click(object sender, EventArgs e)
        {
            LoadListBoxes();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex != -1)
            {
                foreach (ToolStripItem menuItem in form.menuStrip1.Items)
                {
                    if (menuItem.Text == (string)listBox1.Items[listBox1.SelectedIndex])
                    {
                        menuItem.Visible = false;
                        break;
                    }
                }
            }
            LoadListBoxes();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex != -1)
            {
                foreach (ToolStripItem menuItem in form.menuStrip1.Items)
                {
                    if (menuItem.Text == (string)listBox2.Items[listBox2.SelectedIndex])
                    {
                        menuItem.Visible = true;
                        break;
                    }
                }
            }
            LoadListBoxes();
        }
    }
}
