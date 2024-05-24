using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WindowsFormsApp1.Form1;

namespace WindowsFormsApp1
{
    public partial class Delete : Form
    {
        bool drag = false;
        Point start_point = new Point(0, 0);
        //________________________________
        //Чтение из файла
        public void readFromFile(string text)
        {
            string[] massive = File.ReadAllLines(text);

            for (int i = 0; i < massive.Length; i++)
            {
                string[] masiveDivaded = new string[100];
                masiveDivaded = massive[i].Split(' ');
                listOfAll.Rows.Add(masiveDivaded);

            }

        }
        public Delete()
        {
            InitializeComponent();
            readFromFile(@"tyrue.txt");
            this.KeyDown += new KeyEventHandler(Delete_KeyDown);
        }

        private void Delete_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        void Delete_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Escape)
            {
                backDelete_Click(backDelete, null);
            }
        }
        //__________________________
        //Удаление элемента из файла
        private void deletebutton_Click(object sender, EventArgs e)
        {
            try
            {
                Tovar tovar = new Tovar();
                
                
                    tovar.deleteFromFile(Convert.ToInt32(idtext.Text));

                    idtext.Text = "";
                    listOfAll.Rows.Clear();
                    readFromFile(@"tyrue.txt");

                
                
            }
            //__________________________
            //Проверка формата ввода
            catch
            {
                if (idtext.Text == "")
                {
                    MessageBox.Show("Не введен объект удаления", "Ошибка удаления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                string allPossibleLet = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM !@#$%^&*(){}[]_+-=:;/?<>|,.йцукенгшщзхъфывапролджэячсмитьбюЙЦУКЕНГШЩЗХЪФЫВАРПОЛДЖЭЯЧСМИТЬБЮ";
                bool checker = false;
                for(int i = 0; i < idtext.Text.Length; i++)
                {
                    for(int j = 0; j < allPossibleLet.Length; j++)
                    {
                        if (idtext.Text[i] == allPossibleLet[j])
                        {
                            checker = true; break;
                        }
                        if (idtext.Text[i] == '"')
                        {
                            checker = true; break;
                        }
                        if (idtext.Text[i] == '`')
                        {
                            checker = true; break;
                        }
                        if (idtext.Text[i] == '~')
                        {
                            checker = true; break;
                        }
                        
                    }
                }
                if (idtext.Text.Contains("'"))
                {
                    checker = true;
                }
                if (checker == true)
                {
                    MessageBox.Show("Некорректный ввод ID", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                idtext.Text = "";
            }
        }

        private void crest_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void backDelete_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
            
        }

        

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Addprod_Click(object sender, EventArgs e)
        {
            this.Hide();
            Add add = new Add();
            add.Show();
        }

        private void changeprod_Click(object sender, EventArgs e)
        {
            this.Hide();
            Changer changer = new Changer();
            changer.Show();
        }

        private void listOfAll_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите выйти?", "Уведомление системы", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void minimalizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Delete_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            start_point = new Point(e.X, e.Y);
        }

        private void Delete_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - start_point.X, p.Y - start_point.Y);
            }
        }

        private void Delete_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            start_point = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - start_point.X, p.Y - start_point.Y);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }
    }
}
