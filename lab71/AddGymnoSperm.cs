using System;
using System.Windows.Forms;

namespace lab71
{
    public partial class AddGymnoSperm : Form
    {
        bool what = false;
        GymnoSperm gymnosperm;

        public AddGymnoSperm()
        {
            InitializeComponent();
        }
        public AddGymnoSperm(GymnoSperm s)
        {
            gymnosperm = s;
            what = true;
            InitializeComponent();
            textBox1.Text = s.Name;
            comboBox1.Text = s.TypeOfPlant;
            numericUpDown1.Value = s.SeedsCount;
            if(s.Building)
                checkBox2.Checked = true;
            if (s.Eating)
                checkBox6.Checked = true;
            if (s.Fuel)
                checkBox1.Checked = true;
            if (s.Furniture)
                checkBox4.Checked = true;
            if (s.Medicine)
                checkBox5.Checked = true;
            if (s.Oxygen)
                checkBox7.Checked = true;
            if (s.ShipBuilding)
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
                if ((!checkBox1.Checked) && (!checkBox2.Checked) && (!checkBox3.Checked) && (!checkBox4.Checked) && (!checkBox5.Checked) && (!checkBox6.Checked) &&(!checkBox7.Checked))
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
                                Form1.mas.Add(new GymnoSperm(numericUpDown1.Value, textBox1.Text, "семена", "голосеменной", comboBox1.Text, checkBox3.Checked, checkBox7.Checked, checkBox2.Checked, checkBox1.Checked, checkBox5.Checked, checkBox4.Checked, checkBox6.Checked));
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
                                if (v is GymnoSperm)
                                {
                                    GymnoSperm s = (GymnoSperm)v;
                                    if (s.Name == gymnosperm.Name)
                                    {
                                        Form1.mas.Remove(v);
                                        Form1.mas.Add(new GymnoSperm(numericUpDown1.Value, textBox1.Text, "семена", "голосеменной", comboBox1.Text, checkBox3.Checked, checkBox7.Checked, checkBox2.Checked, checkBox1.Checked, checkBox5.Checked, checkBox4.Checked, checkBox6.Checked));
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
