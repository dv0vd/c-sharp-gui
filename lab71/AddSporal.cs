using System;
using System.Windows.Forms;

namespace lab71
{
    public partial class AddSporal : Form
    {
        private string what;
        bool w = false;
        Sporal sporal;

        public AddSporal(string add)
        {
            InitializeComponent();
            what = add;
        }
        public AddSporal(Sporal s,string add)
        {
            sporal = s;
            w = true;
            InitializeComponent();
            textBox1.Text = s.Name;
            comboBox1.Text = s.TypeOfSpores;
            comboBox2.Text = s.Habitat;
            what = add;
        }

        private void AddSporal_Load(object sender, EventArgs e)
        {
            switch(what)
            {
                case "моховидный":
                {
                    this.Text = "Добавление/изменение моховидного";
                    break;
                }
                case "плауновидный":
                {
                    this.Text = "Добавление/изменение плауновидного";
                    break;
                }
                case "хвощевидный":
                {
                    this.Text = "Добавление/изменение хвощевидного";
                    break;
                }
                case "папоротниковидный":
                {
                    this.Text = "Добавление/изменение папоротниковидного";
                    break;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Заполните имя!");
            }
            else
            {
                if (comboBox1.Text == "")
                {
                    MessageBox.Show("Выберите вид растения!");
                }
                else
                {
                    if(comboBox2.Text == "")
                    {
                        MessageBox.Show("Выберите среду обитания!");
                    }
                    else
                    {
                        if(!w)
                        {
                            if (Form1.CheckingUniqueName(textBox1.Text))
                            {
                                Form1.mas.Add(new Sporal(textBox1.Text, what, "споры", comboBox1.Text, comboBox2.Text));
                                Close();
                            }
                            else
                            {
                                MessageBox.Show("Имя не уникальное!");
                            }
                        }
                        else
                        {
                            foreach (var v in Form1.mas)
                            {
                                if (v is Sporal)
                                {
                                    Sporal s = (Sporal)v;
                                    if (s.Name == sporal.Name)
                                    {
                                        Form1.mas.Remove(v);
                                        Form1.mas.Add(new Sporal(textBox1.Text, what, "споры", comboBox1.Text, comboBox2.Text));
                                        Close();
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
