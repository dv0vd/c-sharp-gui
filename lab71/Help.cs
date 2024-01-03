using System;
using System.Windows.Forms;

namespace lab71
{
    public partial class Help : Form
    {
        public Help()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Help_Load(object sender, EventArgs e)
        {
            textBox1.Text = "\tКобинации клавиш: \r\n F1 - справка\r\n Delete - удалить элемент\r\n CTRL + \r\n     L - загрузить из файла\r\n     S - сохранить в файл\r\n     P - добавить элемент\r\n     E - изменить элемент\r\n     I - информация о программе";
        }
    }
}
