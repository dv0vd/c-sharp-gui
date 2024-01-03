using System;
using System.Windows.Forms;

namespace lab71
{
    public partial class RemovingConfirmation : Form
    {
        public RemovingConfirmation()
        {
            InitializeComponent();
        }

        public bool button;

        private void button2_Click(object sender, EventArgs e)
        {
            button = false;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button = true;
            Close();
        }
    }
}
