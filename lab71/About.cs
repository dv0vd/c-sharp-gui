using System;
using System.Windows.Forms;

namespace lab71
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e)
        {
            textBox1.Text = "Курсовая работа по ВП\r\n Выполнил Давыдов В.О.\r\n Группа ИТ - 32\r\n Год 2019\r\n @Все права защищены";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
