using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Changer : Form
    {
        bool drag = false;
        Point start_point = new Point(0, 0);
        public void addItemsToCombobox()
        {
            fieldForRedaction.Items.AddRange(new object[] { "Наименование", "Количество", "Цена", "Материал", "Масса" });
        }
        public Changer()
        {
            InitializeComponent();
            addItemsToCombobox();
            this.KeyDown += new KeyEventHandler(Change_KeyDown);
        }

        void Change_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Escape)
            {
                backReductButton_Click(backReductButton, null);
            }
        }



        private void crest_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите выйти?", "Уведомление системы", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите выйти?", "Уведомление системы", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void idEditText_TextChanged(object sender, EventArgs e)
        {
           
        }
        int CountertV11 = 0;

        //__________________________
        //Проверка на наличие ID в списке
        bool idIn(int id)
        {
            try
            {

                bool isIn = false;
                string[] mas = File.ReadAllLines(@"tyrue.txt");
                for (int i = 0; i < mas.Length; i++)
                {
                    string[] masLn = mas[i].Split(' ');
                    if (Convert.ToInt32(masLn[0]) == id)
                    {
                        isIn = true;
                    }
                }
                return isIn;
            }
            catch 
            {
                MessageBox.Show("Список товаров пуст", "Ошибка редактирования", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bool isIn = false;
                return isIn;
            
            }

        }
        //______________________________________________________
        //Добавление соответствующего текста в поле для редакции
        private void fieldForRedaction_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] mas =  File.ReadAllLines(@"tyrue.txt");
            for(int i = 0; i < mas.Length; i++)
            {
                string line = mas[i];
                string[] masln = line.Split(' ');
                if(masln[0] == idEditText.Text)
                {
                    CountertV11 = Convert.ToInt32(masln[0]); 
                    
                    
                    switch (fieldForRedaction.Text)
                    {
                        case "Наименование":
                            fieldRedaction.Text = masln[1];
                        
                            break;
                        case "Количество":
                            fieldRedaction.Text = masln[2];
 
                            break;
                        case "Цена":
                            fieldRedaction.Text = masln[3];
                            
                            break;
                        case "Материал":
                            fieldRedaction.Text= masln[4];
                            break;
                        case "Масса":
                            fieldRedaction.Text = masln[5];
                            break;
                        default:
                            fieldRedaction.Text = "Введите значения";
                            break;

                            

                    }
                    
                }
               
            }
            
        }
        //_____________________________________
        //Удаление строки из файла
        public void deleteFromFile(int id)
        {

            var Log = id.ToString();
            string path = @"tyrue.txt";
            string[] delUser = File.ReadAllLines(path);
            StreamWriter sw = new StreamWriter(path, false);
            for (int i = 0; i < delUser.Length; i++)
            {
                string[] splited = delUser[i].Split(' ');
                if (Convert.ToInt32(splited[0]) == id)
                {
                    delUser[i] = " ";
                }
            }
            for (int i = 0; i < delUser.Length; i++)
            {
                if (delUser[i] != " ")
                {
                    sw.WriteLine(delUser[i]);
                }
            }
            sw.Close();
        }
        //_________________________________________________
        //Обработка события нажатия кнопки редакции
        private void redactionButton_Click(object sender, EventArgs e)
        {
            string[] mas = File.ReadAllLines(@"tyrue.txt");
            string path = @"tyrue.txt";
            FileInfo file = new FileInfo(path);

            for (int i = 0; i < mas.Length; i++)
            {
                string[] masln = mas[i].Split(' ');
                int counter11 = Convert.ToInt32(masln[0]);
                
                if (counter11 == CountertV11)
                {
                    switch (fieldForRedaction.Text)
                    {
                        case "Наименование":
                            masln[1] = fieldRedaction.Text;
                            deleteFromFile(CountertV11);
                            string buff = masln[0] + " " + masln[1] + " " + masln[2] + " " + masln[3] + " " + masln[4] + " " + masln[5] + " " + masln[6] + " \n";
                            if (file.Exists)
                            {
                                File.AppendAllText(path, buff);
                            }
                            break;
                        case "Количество":
                            masln[2] = fieldRedaction.Text;
                            deleteFromFile(CountertV11);
                            string buff1 = masln[0] + " " + masln[1] + " " + masln[2] + " " + masln[3] + " " + masln[4] + " " + masln[5] + " " + masln[6] + " \n";
                            if (file.Exists)
                            {
                                File.AppendAllText(path, buff1);
                            }

                            break;
                        case "Цена":
                            masln[3] = fieldRedaction.Text;
                            deleteFromFile(CountertV11);
                            string buff2 = masln[0] + " " + masln[1] + " " + masln[2] + " " + masln[3] + " " + masln[4] + " " + masln[5] + " " + masln[6] + " \n";
                            if (file.Exists)
                            {
                                File.AppendAllText(path, buff2);
                            }
                            break;
                        case "Материал":
                            masln[4] = fieldRedaction.Text;
                            deleteFromFile(CountertV11);
                            string buff3 = masln[0] + " " + masln[1] + " " + masln[2] + " " + masln[3] + " " + masln[4] + " " + masln[5] + " " + masln[6] + " \n";
                            if (file.Exists)
                            {
                                File.AppendAllText(path, buff3);
                            }
                            break;
                        case "Масса":
                            masln[5] = fieldRedaction.Text;
                            deleteFromFile(CountertV11);
                            string buff4 = masln[0] + " " + masln[1] + " " + masln[2] + " " + masln[3] + " " + masln[4] + " " + masln[5] + " " + masln[6] + " \n";
                            if (file.Exists)
                            {
                                File.AppendAllText(path, buff4);
                            }
                            break;
                        default:
                            fieldRedaction.Text = "Введите значения";
                            break;

                    }
                    
                }

            }
            //________________________________
            //Обработка ошибок
            bool changeController = true; 
            try
            {
                if (idEditText.Text == "")
                {
                    MessageBox.Show("Не введен ID для редактирования", "Ошибка редактирования", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    changeController = false;

                }
                else if (idIn(Convert.ToInt32(idEditText.Text)) == false)
                {
                    MessageBox.Show("Такого товара не существует", "Ошибка редактирования", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    changeController = false;
                }
            }
            catch
            {
                MessageBox.Show("Некорректный ввод ID", "Ошибка редактирования", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            
            
            if (fieldForRedaction.Text == "")
            {
                MessageBox.Show("Не введено поле редактирования", "Ошибка редактирования", MessageBoxButtons.OK, MessageBoxIcon.Error);
                changeController = false;
            }
            if (fieldRedaction.Text == "")
            {
                MessageBox.Show("Не введено изменение", "Ошибка редактирования", MessageBoxButtons.OK, MessageBoxIcon.Error);
                changeController = false;
            }
            
            

            if (changeController == true)
            {
                fieldRedaction.Text = "";
                fieldForRedaction.Text = "";
                idEditText.Text = "";
            }
            

        }
        
        private void backReductButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        //________________________________________
        //Обработка возможности перемещения формы

        private void Changer_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            start_point = new Point(e.X, e.Y);
        }

        private void Changer_MouseMove(object sender, MouseEventArgs e)
        {
            if(drag)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - start_point.X, p.Y - start_point.Y);
            }
        }

        private void Changer_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void crest_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите выйти?", "Уведомление системы", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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
