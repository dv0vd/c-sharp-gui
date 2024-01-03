using System;
using System.Windows.Forms;

namespace lab71
{
    public partial class AddAngioSperm : Form
    {
        bool what = false;
        Angiosperm angiosperm;

        public AddAngioSperm()
        {
            InitializeComponent();
        }
        public AddAngioSperm(Angiosperm s)
        {
            angiosperm = s;
            what = true;
            InitializeComponent();
            textBox1.Text = s.Name;
            comboBox1.Text = s.TypeOfPlant;
            numericUpDown1.Value = s.SeedsCount;
            if (s.Building)
                checkBox4.Checked = true;
            if (s.Eating)
                checkBox2.Checked = true;
            if (s.Fuel)
                checkBox5.Checked = true;
            if (s.Cosmetic)
                checkBox1.Checked = true;
            if (s.Medicine)
                checkBox6.Checked = true;
            if (s.Oxygen)
                checkBox3.Checked = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Заполните имя!");
                }
                else
                {
                    if ((!checkBox1.Checked) && (!checkBox2.Checked) && (!checkBox3.Checked) && (!checkBox4.Checked) && (!checkBox5.Checked) && (!checkBox6.Checked))
                    {
                        MessageBox.Show("Выберите вид применения!");
                    }
                    else
                    {
                        if (comboBox1.Text == "")
                        {
                            MessageBox.Show("Выберите вид растения!");
                        }
                        else
                        {

                            if(!what)
                            {
                                if (Form1.CheckingUniqueName(textBox1.Text))
                                {
                                    Form1.mas.Add(new Angiosperm(numericUpDown1.Value, textBox1.Text, "семена", "покрытосеменной", comboBox1.Text, checkBox3.Checked, checkBox4.Checked, checkBox5.Checked, checkBox6.Checked, checkBox1.Checked, checkBox2.Checked));
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
                                    if (v is Angiosperm)
                                    {
                                        Angiosperm s = (Angiosperm)v;
                                        if (s.Name == angiosperm.Name)
                                        {
                                            Form1.mas.Remove(v);
                                            Form1.mas.Add(new Angiosperm(numericUpDown1.Value, textBox1.Text, "семена", "покрытосеменной", comboBox1.Text, checkBox3.Checked, checkBox4.Checked, checkBox5.Checked, checkBox6.Checked, checkBox1.Checked, checkBox2.Checked));
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
}
