using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace lab71
{
    public partial class Form1 : Form
    {
        private static TreeNode root = new TreeNode("Растения");
        public static ArrayList mas = new ArrayList();
        ToolStripLabel timeStartLabel, dateLabel ,timeLabel;
        private static ulong timeSec = 0;

        private void TreeRoots()
        {
            root.Nodes.Add(new TreeNode("Высшие"));
            root.Nodes[0].Nodes.Add(new TreeNode("Споровые"));
            root.Nodes[0].Nodes[0].Nodes.Add(new TreeNode("Моховидные"));
            root.Nodes[0].Nodes[0].Nodes.Add(new TreeNode("Плауновидные"));
            root.Nodes[0].Nodes[0].Nodes.Add(new TreeNode("Хвощевидные"));
            root.Nodes[0].Nodes[0].Nodes.Add(new TreeNode("Папоротниковидные"));
            root.Nodes[0].Nodes.Add(new TreeNode("Семенные"));
            root.Nodes[0].Nodes[1].Nodes.Add(new TreeNode("Покрытосеменные"));
            root.Nodes[0].Nodes[1].Nodes.Add(new TreeNode("Голосеменные"));
            root.Nodes.Add(new TreeNode("Низшие"));
            root.Nodes[1].Nodes.Add(new TreeNode("Водоросли"));
        }

        private void Clear()
        {
            root.Nodes[0].Nodes[0].Nodes[0].Nodes.Clear();
            root.Nodes[0].Nodes[0].Nodes[1].Nodes.Clear();
            root.Nodes[0].Nodes[0].Nodes[2].Nodes.Clear();
            root.Nodes[0].Nodes[0].Nodes[3].Nodes.Clear();
            root.Nodes[0].Nodes[1].Nodes[0].Nodes.Clear();
            root.Nodes[0].Nodes[1].Nodes[1].Nodes.Clear();
            root.Nodes[1].Nodes[0].Nodes.Clear();
            ClearInformation();
        }

        private void Output()
        {
            Clear();
            foreach (var f in mas)
            {
                if (f is Seaweed)
                {
                    Seaweed temp = (Seaweed)f;
                    root.Nodes[1].Nodes[0].Nodes.Add(temp.Name);
                }
                else
                {
                    if (f is Angiosperm)
                    {
                        Angiosperm temp = (Angiosperm)f;
                        root.Nodes[0].Nodes[1].Nodes[0].Nodes.Add(temp.Name);
                    }
                    else
                    {
                        if (f is GymnoSperm)
                        {
                            GymnoSperm temp = (GymnoSperm)f;
                            root.Nodes[0].Nodes[1].Nodes[1].Nodes.Add(temp.Name);
                        }
                        else
                        {
                            if (f is Sporal)
                            {
                                Sporal temp = (Sporal)f;
                                switch (temp.Type)
                                {
                                    case "моховидный":
                                        {
                                            root.Nodes[0].Nodes[0].Nodes[0].Nodes.Add(temp.Name);
                                            break;
                                        }
                                    case "плауновидный":
                                        {
                                            root.Nodes[0].Nodes[0].Nodes[1].Nodes.Add(temp.Name);
                                            break;
                                        }
                                    case "хвощевидный":
                                        {
                                            root.Nodes[0].Nodes[0].Nodes[2].Nodes.Add(temp.Name);
                                            break;
                                        }
                                    case "папоротниковидный":
                                        {
                                            root.Nodes[0].Nodes[0].Nodes[3].Nodes.Add(temp.Name);
                                            break;
                                        }
                                }
                            }
                        }
                    }
                }
            }
            root.ExpandAll();
        }

        private void ClearInformation()
        {
            label1.Enabled = true;
            label3.Enabled = true;
            label4.Enabled = true;
            label5.Enabled = true;
            label6.Enabled = true;
            label7.Enabled = true;
            label13.Enabled = true;
            label2.Text = "";
            label8.Text = "";
            label9.Text = "";
            label10.Text = "";
            label11.Text = "";
            label12.Text = "";
            label14.Text = "";
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
            checkBox8.Checked = false;
            checkBox9.Checked = false;
        }

        private void MakeInactive()
        {
            label3.Enabled = false;
            label4.Enabled = false;
            label5.Enabled = false;
            label6.Enabled = false;
            label7.Enabled = false;
        }

        private void FindInformation(TreeNode treenode)
        {
            MakeInactive();
            ClearInformation();
            foreach (var f in mas)
            {
                if (f is Seaweed)
                {
                    Seaweed s = (Seaweed)f;
                    if (treenode.Text == s.Name)
                    {
                        label2.Enabled = true;
                        label2.Text = s.Name;
                        label3.Enabled = true;
                        label8.Text = s.Habitat;
                        if (s.Eating)
                            checkBox2.Checked = true;
                        if (s.Fertilizer)
                            checkBox9.Checked = true;
                        if (s.Oxygen)
                            checkBox3.Checked = true;
                        return;
                    }
                }
                else
                {
                    if (f is GymnoSperm)
                    {
                        GymnoSperm s = (GymnoSperm)f;
                        if (treenode.Text == s.Name)
                        {
                            label2.Text = s.Name;
                            label5.Enabled = true;
                            label10.Text = s.TypeOfPlant;
                            label13.Enabled = true;
                            label14.Text = s.SeedsCount.ToString();
                            label7.Enabled = true;
                            label12.Text = "голосеменные";
                            label4.Enabled = true;
                            label9.Text = "семена";
                            if (s.Building)
                                checkBox4.Checked = true;
                            if (s.Eating)
                                checkBox2.Checked = true;
                            if (s.Fuel)
                                checkBox5.Checked = true;
                            if (s.Furniture)
                                checkBox8.Checked = true;
                            if (s.Medicine)
                                checkBox7.Checked = true;
                            if (s.Oxygen)
                                checkBox3.Checked = true;
                            if (s.ShipBuilding)
                                checkBox6.Checked = true;
                            return;
                        }
                    }
                    else
                    {
                        if (f is Angiosperm)
                        {
                            Angiosperm s = (Angiosperm)f;
                            if (treenode.Text == s.Name)
                            {
                                label2.Text = s.Name;
                                label5.Enabled = true;
                                label10.Text = s.TypeOfPlant;
                                label13.Enabled = true;
                                label14.Text = s.SeedsCount.ToString();
                                label7.Enabled = true;
                                label12.Text = "покрытосеменные";
                                label4.Enabled = true;
                                label9.Text = "семена";
                                if (s.Building)
                                    checkBox4.Checked = true;
                                if (s.Eating)
                                    checkBox2.Checked = true;
                                if (s.Fuel)
                                    checkBox5.Checked = true;
                                if (s.Medicine)
                                    checkBox7.Checked = true;
                                if (s.Oxygen)
                                    checkBox3.Checked = true;
                                if (s.Cosmetic)
                                    checkBox1.Checked = true;
                                return;
                            }
                        }
                        else
                        {
                            if (f is Sporal)
                            {
                                Sporal s = (Sporal)f;
                                if (treenode.Text == s.Name)
                                {
                                    label2.Text = s.Name;
                                    label3.Enabled = true;
                                    label8.Text = s.Habitat;
                                    label4.Enabled = true;
                                    label9.Text = "споры";
                                    label5.Enabled = true;
                                    label10.Text = s.Type;
                                    label6.Enabled = true;
                                    label11.Text = s.TypeOfSpores;
                                    return;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if ((treeView1.SelectedNode.Text == "Растения") || (treeView1.SelectedNode.Text == "Высшие") || (treeView1.SelectedNode.Text == "Споровые") || (treeView1.SelectedNode.Text == "Моховидные") || (treeView1.SelectedNode.Text == "Плауновидные") || (treeView1.SelectedNode.Text == "Хвощевидные") || (treeView1.SelectedNode.Text == "Папоротниковидные") || (treeView1.SelectedNode.Text == "Семенные") || (treeView1.SelectedNode.Text == "Покрытосеменные") || (treeView1.SelectedNode.Text == "Голосеменные") || (treeView1.SelectedNode.Text == "Низшие") || (treeView1.SelectedNode.Text == "Водоросли"))
            {
                ClearInformation();
            }
            else
            {
                FindInformation(treeView1.SelectedNode);
            }
        }

        private void SaveToFile()
        {
            Type[] Types = new Type[8];
            Types[0] = typeof(Sporal);
            Types[1] = typeof(Seaweed);
            Types[2] = typeof(Angiosperm);
            Types[3] = typeof(GymnoSperm);
            Types[4] = typeof(Lower);
            Types[5] = typeof(Plant);
            Types[6] = typeof(Seminal);
            Types[7] = typeof(Upper);
            XmlSerializer serializer = new XmlSerializer(typeof(ArrayList), Types);
            SaveFileDialog SPF = new SaveFileDialog();
            SPF.Filter = "Файлы|*.xml";
            SPF.AddExtension = true;
            SPF.DefaultExt = "xml";
            SPF.OverwritePrompt = true;
            if (SPF.ShowDialog() == DialogResult.OK)
            {
                string checking = SPF.FileName;
                int len = checking.Length;
                if (len > 4)
                {
                    if ((checking[len - 1] == 'l') && (checking[len - 2] == 'm') && (checking[len - 3] == 'x'))
                    {
                        using (FileStream file = new FileStream(SPF.FileName, FileMode.Create))
                        {
                            serializer.Serialize(file, mas);
                        }
                        MessageBox.Show("Данные успешно сохранены!");
                    }
                    else
                    {
                        MessageBox.Show("Неверное расширение файла!");
                    }
                }
                else
                {
                    MessageBox.Show("Неверное расширение файла!");
                }
            }
        }

        private void LoadFromFile()
        {
            Type[] Types = new Type[8];
            Types[0] = typeof(Sporal);
            Types[1] = typeof(Seaweed);
            Types[2] = typeof(Angiosperm);
            Types[3] = typeof(GymnoSperm);
            Types[4] = typeof(Lower);
            Types[5] = typeof(Plant);
            Types[6] = typeof(Seminal);
            Types[7] = typeof(Upper);
            XmlSerializer deserializer = new XmlSerializer(typeof(ArrayList), Types);
            OpenFileDialog OPF = new OpenFileDialog();
            OPF.Filter = "Файлы|*.xml";
            if (OPF.ShowDialog() == DialogResult.OK)
            {
                using (FileStream file = new FileStream(OPF.FileName, FileMode.OpenOrCreate))
                {
                    mas = (ArrayList)deserializer.Deserialize(file);
                }
                MessageBox.Show("Данные успешно загружены");
                Output();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveToFile();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadFromFile();
        }

        private void RemovingElement()
        {
            if ((treeView1.SelectedNode.Text == "Растения") || (treeView1.SelectedNode.Text == "Высшие") || (treeView1.SelectedNode.Text == "Споровые") || (treeView1.SelectedNode.Text == "Моховидные") || (treeView1.SelectedNode.Text == "Плауновидные") || (treeView1.SelectedNode.Text == "Хвощевидные") || (treeView1.SelectedNode.Text == "Папоротниковидные") || (treeView1.SelectedNode.Text == "Семенные") || (treeView1.SelectedNode.Text == "Покрытосеменные") || (treeView1.SelectedNode.Text == "Голосеменные") || (treeView1.SelectedNode.Text == "Низшие") || (treeView1.SelectedNode.Text == "Водоросли"))
            {
                MessageBox.Show("Осуществлять какие-либо действия с категориями нельзя!");
            }
            else
            {
                RemovingConfirmation form = new RemovingConfirmation();
                form.ShowDialog();
                if (form.button)
                {
                    foreach (var v in mas)
                    {
                        if (v is Seaweed)
                        {
                            Seaweed s = (Seaweed)v;
                            if (s.Name == treeView1.SelectedNode.Text)
                            {
                                mas.Remove(v);
                                MessageBox.Show("Объект успешно удалён");
                                Output();
                                break;
                            }
                        }
                        else
                        {
                            if (v is Sporal)
                            {
                                Sporal s = (Sporal)v;
                                if (s.Name == treeView1.SelectedNode.Text)
                                {
                                    mas.Remove(v);
                                    MessageBox.Show("Объект успешно удалён");
                                    Output();
                                    break;
                                }
                            }
                            else
                            {
                                if (v is GymnoSperm)
                                {
                                    GymnoSperm s = (GymnoSperm)v;
                                    if (s.Name == treeView1.SelectedNode.Text)
                                    {
                                        mas.Remove(v);
                                        MessageBox.Show("Объект успешно удалён");
                                        Output();
                                        break;
                                    }
                                }
                                else
                                {
                                    if (v is Angiosperm)
                                    {
                                        Angiosperm s = (Angiosperm)v;
                                        if (s.Name == treeView1.SelectedNode.Text)
                                        {
                                            mas.Remove(v);
                                            MessageBox.Show("Объект успешно удалён");
                                            Output();
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

        private void pictureBox1_DragDrop(object sender, DragEventArgs e)
        {
            RemovingElement();
        }

        private void pictureBox1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void treeView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if ((treeView1.SelectedNode.Text == "Растения") || (treeView1.SelectedNode.Text == "Высшие") || (treeView1.SelectedNode.Text == "Споровые") || (treeView1.SelectedNode.Text == "Моховидные") || (treeView1.SelectedNode.Text == "Плауновидные") || (treeView1.SelectedNode.Text == "Хвощевидные") || (treeView1.SelectedNode.Text == "Папоротниковидные") || (treeView1.SelectedNode.Text == "Семенные") || (treeView1.SelectedNode.Text == "Покрытосеменные") || (treeView1.SelectedNode.Text == "Голосеменные") || (treeView1.SelectedNode.Text == "Низшие") || (treeView1.SelectedNode.Text == "Водоросли"))
            {
                MessageBox.Show("Осуществлять какие-либо действия с категориями нельзя!");
            }
            else
            {
                treeView1.DoDragDrop(treeView1.SelectedNode, DragDropEffects.Move);
            }
        }

        private void EditElement()
        {
            if ((treeView1.SelectedNode.Text == "Растения") || (treeView1.SelectedNode.Text == "Высшие") || (treeView1.SelectedNode.Text == "Споровые") || (treeView1.SelectedNode.Text == "Моховидные") || (treeView1.SelectedNode.Text == "Плауновидные") || (treeView1.SelectedNode.Text == "Хвощевидные") || (treeView1.SelectedNode.Text == "Папоротниковидные") || (treeView1.SelectedNode.Text == "Семенные") || (treeView1.SelectedNode.Text == "Покрытосеменные") || (treeView1.SelectedNode.Text == "Голосеменные") || (treeView1.SelectedNode.Text == "Низшие") || (treeView1.SelectedNode.Text == "Водоросли"))
            {
                MessageBox.Show("Осуществлять какие-либо действия с категориями нельзя!");
            }
            else
            {
                foreach (var v in mas)
                {
                    if (v is Seaweed)
                    {
                        Seaweed s = (Seaweed)v;
                        if (s.Name == treeView1.SelectedNode.Text)
                        {
                            AddSeaweed newRoot = new AddSeaweed(s);
                            newRoot.ShowDialog();
                            Output();
                            break;
                        }
                    }
                    else
                    {
                        if (v is Sporal)
                        {
                            Sporal s = (Sporal)v;
                            if (s.Name == treeView1.SelectedNode.Text)
                            {
                                AddSporal newRoot = new AddSporal(s, s.Type);
                                newRoot.ShowDialog();
                                Output();
                                break;
                            }
                        }
                        else
                        {
                            if (v is GymnoSperm)
                            {
                                GymnoSperm s = (GymnoSperm)v;
                                if (s.Name == treeView1.SelectedNode.Text)
                                {
                                    AddGymnoSperm newRoot = new AddGymnoSperm(s);
                                    newRoot.ShowDialog();
                                    Output();
                                    break;
                                }
                            }
                            else
                            {
                                if (v is Angiosperm)
                                {
                                    Angiosperm s = (Angiosperm)v;
                                    if (s.Name == treeView1.SelectedNode.Text)
                                    {
                                        AddAngioSperm newRoot = new AddAngioSperm(s);
                                        newRoot.ShowDialog();
                                        Output();
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
       
        private void AddElement()
        {
            if ((treeView1.SelectedNode.Text == "Моховидные") || (treeView1.SelectedNode.Text == "Плауновидные") || (treeView1.SelectedNode.Text == "Хвощевидные") || (treeView1.SelectedNode.Text == "Папоротниковидные") || (treeView1.SelectedNode.Text == "Покрытосеменные") || (treeView1.SelectedNode.Text == "Голосеменные") || (treeView1.SelectedNode.Text == "Водоросли"))
            {
                switch (treeView1.SelectedNode.Text)
                {
                    case "Водоросли":
                        {
                            AddSeaweed newRoot = new AddSeaweed();
                            newRoot.ShowDialog();
                            break;
                        }
                    case "Моховидные":
                        {
                            AddSporal newRoot = new AddSporal("моховидный");
                            newRoot.ShowDialog();
                            break;
                        }
                    case "Плауновидные":
                        {
                            AddSporal newRoot = new AddSporal("плауновидный");
                            newRoot.ShowDialog();
                            break;
                        }
                    case "Хвощевидные":
                        {
                            AddSporal newRoot = new AddSporal("хвощевидный");
                            newRoot.ShowDialog();
                            break;
                        }
                    case "Папоротниковидные":
                        {
                            AddSporal newRoot = new AddSporal("папоротниковидный");
                            newRoot.ShowDialog();
                            break;
                        }
                    case "Покрытосеменные":
                        {
                            AddAngioSperm newRoot = new AddAngioSperm();
                            newRoot.ShowDialog();
                            break;
                        }
                    case "Голосеменные":
                        {
                            AddGymnoSperm newRoot = new AddGymnoSperm();
                            newRoot.ShowDialog();
                            break;
                        }
                }
                Output();
            }
            else
            {
                MessageBox.Show("Дабвить объект в это место невозможно!");
            }
        }

        void editMenuItem_Click(object sender, EventArgs e)
        {
            EditElement();
        }

        void addMenuItem_Click(object sender, EventArgs e)
        {
            AddElement();
        }

        void removeMenuItem_Click(object sender, EventArgs e)
        {
            RemovingElement();
        }

        void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
                SaveToFile();
            if (e.Control && e.KeyCode == Keys.L)
                LoadFromFile();
            if (e.Control && e.KeyCode == Keys.P)
                AddElement();
            if (e.Control && e.KeyCode == Keys.E)
                EditElement();
            if (e.KeyCode == Keys.Delete)
                RemovingElement();
            if (e.Control && e.KeyCode == Keys.I)
            {
                About a = new About();
                a.ShowDialog();
            }
            if (e.KeyCode == Keys.F1)
            {
                Help a = new Help();
                a.ShowDialog();
            }
        }

        void timer_Tick(object sender, EventArgs e)
        {
            dateLabel.Text = DateTime.Now.ToLongDateString();
            timeLabel.Text = DateTime.Now.ToLongTimeString();
        }

        void timer_Tick2(object sender, EventArgs e)
        {
            timeSec += 1;
            timeStartLabel.Text = timeSec.ToString();
        }

        private void DroppingInitialization()
        {
            AllowDrop = true;
            pictureBox1.AllowDrop = true;
        }

        private void TreeViewInitialization()
        {
            TreeRoots();
            treeView1.Nodes.Add(root);
            Output();
        }

        private void ContextMenuInitizlization()
        {
            treeView1.ContextMenuStrip = contextMenuStrip1;
            ToolStripMenuItem editMenuItem = new ToolStripMenuItem("Изменить");
            ToolStripMenuItem removeMenuItem = new ToolStripMenuItem("Удалить");
            ToolStripMenuItem addMenuItem = new ToolStripMenuItem("Добавить");
            contextMenuStrip1.Items.AddRange(new[] { addMenuItem, editMenuItem, removeMenuItem });
            editMenuItem.Click += editMenuItem_Click;
            addMenuItem.Click += addMenuItem_Click;
            removeMenuItem.Click += removeMenuItem_Click;
        }

        private void StatusStrip1Initizlization()
        {
            ToolStripLabel infoLabel = new ToolStripLabel();
            infoLabel.Text = "Текущие дата и время:";
            dateLabel = new ToolStripLabel();
            timeLabel = new ToolStripLabel();
            statusStrip1.Items.Add(infoLabel);
            statusStrip1.Items.Add(dateLabel);
            statusStrip1.Items.Add(timeLabel);
            Timer timer = new Timer() { Interval = 1000 };
            timer.Tick += timer_Tick;
            Timer timer2 = new Timer() { Interval = 1000 };
            timer2.Tick += timer_Tick2;
            timer.Start();
            timer2.Start();
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            LoadFromFile();
        }

        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            SaveToFile();
        }

        private void ToolStripButton4_Click(object sender, EventArgs e)
        {
            EditElement();
        }

        private void ToolStripButton3_Click(object sender, EventArgs e)
        {
            RemovingElement();
        }

        private void ToolStripButton5_Click(object sender, EventArgs e)
        {
            AddElement();
        }

        private void ЗагрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadFromFile();
        }

        private void СохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveToFile();
        }

        private void ВыходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddElement();
        }

        private void ИзменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditElement();
        }

        private void УдалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemovingElement();
        }

        private void ОПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About a = new About();
            a.ShowDialog();
        }

        private void СправкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help a = new Help();
            a.ShowDialog();
        }

        bool Find(TreeNodeCollection Nodes, string str)
        {
            foreach (TreeNode tn in Nodes)
            {
                if (tn.Text.ToLower() == str)
                {
                    treeView1.Focus();
                    tn.EnsureVisible();
                    treeView1.SelectedNode = tn;
                    return true;
                }
                if (Find(tn.Nodes, str))
                    return true;
            }
            return false;
        }

        private void Search()
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Запрос не может быть пустым!");
            }
            else
            {
                string search = textBox1.Text;
                search = search.ToLower();
                if (!Find(root.Nodes, search))
                {
                    MessageBox.Show("Упс... Такого элемента не существует");
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Search();
        }

        private void Count()
        {
            int seaweed = Seaweed.Count(mas);
            int upper = Upper.Count(mas);
            int lower = Lower.Count(mas);
            int seminal = Seminal.Count(mas);
            int angiosperm = Angiosperm.Count(mas);
            int gymnosperm = GymnoSperm.Count(mas);
            int моховидный = 0, плауновидный = 0, хвощевидный = 0, папоротниковидный = 0;
            int sporal = Sporal.Count(mas, ref моховидный,ref плауновидный,ref хвощевидный, ref папоротниковидный);
            label27.Text = mas.Count.ToString();
            label28.Text = upper.ToString();
            label29.Text = lower.ToString();
            label30.Text = sporal.ToString();
            label31.Text = seminal.ToString();
            label32.Text = моховидный.ToString();
            label33.Text = плауновидный.ToString();
            label34.Text = хвощевидный.ToString();
            label35.Text = папоротниковидный.ToString();
            label36.Text = angiosperm.ToString();
            label37.Text = gymnosperm.ToString();
            label38.Text = seaweed.ToString();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Count();
        }

        private void SortMas()
        {
            List<Seaweed> masSeaweed = new List<Seaweed>();
            List<Sporal> masSporal = new List<Sporal>();
            List<GymnoSperm> masGymnosperm = new List<GymnoSperm>();
            List<Angiosperm> masAngioSperm = new List<Angiosperm>();
            foreach (var v in mas)
            {
                if (v is Seaweed)
                {
                    masSeaweed.Add((Seaweed)v);
                }
                else
                {
                    if (v is Sporal)
                    {
                        masSporal.Add((Sporal)v);
                    }
                    else
                    {
                        if (v is GymnoSperm)
                        {
                            masGymnosperm.Add((GymnoSperm)v);
                        }
                        else
                        {
                            if (v is Angiosperm)
                            {
                                masAngioSperm.Add((Angiosperm)v);
                            }
                        }
                    }
                }
            }
            masSeaweed.Sort();
            masAngioSperm.Sort();
            masGymnosperm.Sort();
            masSporal.Sort();
            mas.Clear();
            foreach (var v in masSeaweed)
                mas.Add(v);
            foreach (var v in masAngioSperm)
                mas.Add(v);
            foreach (var v in masGymnosperm)
                mas.Add(v);
            foreach (var v in masSporal)
                mas.Add(v);
            Output();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SortMas();
            Output();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SortMas();
            mas.Reverse();
            Output();
        }

        private void StatusStrip2Initizlization()
        {
            ToolStripLabel infoLabel = new ToolStripLabel();
            infoLabel.Text = "Время работы программы (с) :";
            timeStartLabel = new ToolStripLabel();
            statusStrip2.Items.Add(infoLabel);
            statusStrip2.Items.Add(timeStartLabel);
            Timer timer = new Timer() { Interval = 1000 };
            timer.Tick += timer_Tick;
            timer.Start();
        }

        private void userControl31_Load(object sender, EventArgs e)
        {
            UserControl3.form = this;
        }

        public static bool CheckingUniqueName(string search)
        {
            foreach (var v in Form1.mas)
            {
                Plant p = (Plant)v;
                if (search == p.Name)
                {
                    return false;
                }
            }
            return true;
        }

        public Form1()
        {
            InitializeComponent();
            DroppingInitialization();
            TreeViewInitialization();
            ContextMenuInitizlization();
            StatusStrip1Initizlization();
            StatusStrip2Initizlization();
        }
    }
}
