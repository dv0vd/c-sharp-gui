using System;
using System.Windows.Forms;

namespace lab71
{
    public partial class AddSeaweed : Form
    {
        bool what = false;
        Seaweed seaweed;

        public AddSeaweed()
        {
            InitializeComponent();
        }

        public AddSeaweed(Seaweed s)
        {
            seaweed = s;
            what = true;
            InitializeComponent();
            textBox1.Text = s.Name;
            comboBox1.Text = s.Habitat;
            if (s.Eating)
                checkBox2.Checked = true;
            if (s.Oxygen)
                checkBox1.Checked = true;
            if (s.Fertilizer)
                checkBox3.Checked = true;
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
                if((!checkBox1.Checked) && (!checkBox2.Checked) && (!checkBox3.Checked))
                {
                    MessageBox.Show("Выберите вид применения!");
                }
                else
                {
                    if(comboBox1.Text == "")
                    {
                        MessageBox.Show("Выберите среду обитания!");
                    }
                    else
                    {
                        if(!what)
                        {
                            if (Form1.CheckingUniqueName(textBox1.Text))
                            {
                                Form1.mas.Add(new Seaweed(textBox1.Text, comboBox1.Text, checkBox2.Checked, checkBox1.Checked, checkBox3.Checked));
                                Close();
                            }
                            else
                            {
                                MessageBox.Show("Имя не уникальное!");
                            }
                        }
                        else
                        {
                            foreach(var v in Form1.mas)
                            {
                                if(v is Seaweed)
                                {
                                    Seaweed s = (Seaweed)v;
                                    if(s.Name == seaweed.Name)
                                    {
                                        Form1.mas.Remove(v);
                                        Form1.mas.Add(new Seaweed(textBox1.Text, comboBox1.Text, checkBox2.Checked, checkBox1.Checked, checkBox3.Checked));
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
