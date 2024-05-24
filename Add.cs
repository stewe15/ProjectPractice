using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WindowsFormsApp1.Form1;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Add : Form
    {
        bool drag = false;
        Point start_point = new Point(0, 0);
        int Cheker = 0;
        int CounterOne = 0;
        int RememberedID = 0;

        static string[] mas = File.ReadAllLines(@"tyrue.txt");
        

        public void setCounter()
        {
            CounterOne = mas.Length;

        }
        //______________________________________
        //Нахождение и задание максимального ID
        public void listofIndex()
        {
            string[] masNew = File.ReadAllLines(@"tyrue.txt");
            
            int[] indexes = new int[masNew.Length];
            for (int i = 0; i < masNew.Length; i++)
            {
                string[] masLn = masNew[i].Split(' ');
                indexes[i] = Convert.ToInt32(masLn[0]);
            }
            try
            {
                CounterOne = indexes.Max();
                CounterOne++;
            }
            catch
            {
                CounterOne = 0;
            }

        }

        public void addItemsToCombobox()
        {
            materialBox.Items.AddRange(new object[] { "Алюминий", "Пластик", "Древесина", "Сталь", "Чугун","Резина","Стекло","Керамика"});
            categoryBox.Items.AddRange(new object[] { "Мебель", "Стройматериалы", "Товары_для_дома", "Садовая_техника", "Декор", "Инструменты", "Крепежные_изделия" });
        }

        public Add()
        {
            InitializeComponent();
            addItemsToCombobox();
            this.KeyDown += new KeyEventHandler(Add_KeyDown);
        }

        

        void Add_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Escape)
            {
                backAdd_Click(exit, null);
            }
        }
        private void valuetext_TextChanged(object sender, EventArgs e)
        {

        }

        private void Delprod_Click(object sender, EventArgs e)
        {
            this.Hide();
            Delete deleteForm = new Delete();
            deleteForm.Show();
        }

        private void changeprod_Click(object sender, EventArgs e)
        {
            this.Hide();
            Changer changerForm = new Changer();
            changerForm.Show();

        }
        //______________________________________
        //Обработка события нажатия кнопки "Добавить"
        private void addbutton_Click(object sender, EventArgs e)
        {
            listofIndex();
            Tovar tovar = new Tovar();
            bool tryCatchTovar = true;
            if (Cheker == 0)
            {
                tovar.SettterId(CounterOne++);

            }
            if (Cheker == 1)
            {
                tovar.SettterId(RememberedID);
                Cheker = 0;
            }

            bool textNameFlag = true;
            for (int i = 0; i < nametext.Text.Length; i++)
            {
                if (nametext.Text[i] == ' ')
                {
                    textNameFlag = false; break;
                }
            }
            if (textNameFlag == false)
            {
                MessageBox.Show("Некорректный ввод наименования", "Ошибка добавления", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            if (nametext.Text != "")
            {
                tovar.SetterName(nametext.Text);
            }
            else
            {
                MessageBox.Show("Наименование не введено", "Ошибка добавления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tryCatchTovar = false;
            }


            try
            {
                if(valuetext.Text == "")
                {
                    MessageBox.Show("Количество не введено", "Ошибка добавления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tryCatchTovar = false;
                }
                else if(Convert.ToInt32(valuetext.Text) >= 1) 
                {
                    tovar.SetValue(Convert.ToInt32(valuetext.Text));
                }
                else
                {
                    MessageBox.Show("Количество не может быть отрицательным", "Ошибка добавления", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    tryCatchTovar = false;
                }
                

            }
            catch
            {
                MessageBox.Show("Некорректный ввод количества", "Ошибка добавления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tryCatchTovar = false;
            }

            try
            {
                if(cashtext.Text == "")
                {
                    MessageBox.Show("Цена не введена", "Ошибка добавления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tryCatchTovar = false;
                }
                else if (Convert.ToInt32(cashtext.Text) >= 1)
                {
                    tovar.SetPrice(Convert.ToInt32(cashtext.Text));
                }
                else
                {
                    MessageBox.Show("Цена не может быть отрицательной", "Ошибка добавления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                    tryCatchTovar = false;
                }
                

            }
            catch
            {
                MessageBox.Show("Некорректный ввод цены", "Ошибка добавления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tryCatchTovar = false;
            }

            try
            {
                if(massText.Text == "")
                {
                    MessageBox.Show("Масса не введена", "Ошибка добавления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tryCatchTovar = false;
                }
                else if (Convert.ToDouble(massText.Text) >= 0.00001)
                {
                    tovar.SetMasa(Convert.ToDouble(massText.Text));
                }
                else
                {
                    MessageBox.Show("Масса не может быть отрицательной", "Ошибка добавления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                    tryCatchTovar = false;
                }

            }
            catch
            {
                MessageBox.Show("Некорректный ввод массы", "Ошибка добавления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tryCatchTovar = false;
            }

            bool textMaterialFlag = true;
            for (int i = 0; i < materialBox.Text.Length; i++)
            {
                if (materialBox.Text[i] == ' ')
                {
                    textMaterialFlag = false; break;
                }
            }

            if (textMaterialFlag == false)
            {
                MessageBox.Show("Некорректный ввод материала", "Ошибка добавления", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            if (materialBox.Text != "")
            {
                tovar.SetMatrial(materialBox.Text);
            }
            else
            {
                MessageBox.Show("Материал не введен", "Ошибка добавления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tryCatchTovar = false;
            }
            bool tryCatchDirectory = true;
            if (categoryBox.Text != "")
            {
                tovar.SetDesk(categoryBox.Text);
            }
            
            else
            {
                MessageBox.Show("Материал не введен", "Ошибка добавления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tryCatchDirectory = false;
            }

            if (tryCatchTovar == true && textNameFlag == true && textMaterialFlag == true && tryCatchDirectory == true)
            {
                tovar.addToFile();

                nametext.Text = "";
                valuetext.Text = "";
                cashtext.Text = "";
                massText.Text = "";
                materialBox.Text = "";
                categoryBox.Text = "";
            }
        }
        //_____________________________________________________
        //Обработка нажатия кнопки назад и выхода из приложения

        private void backAdd_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void crest_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите выйти?", "Уведомление системы", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void materialBox_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void minimalizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //_____________________________________________________
        //Обработка движения формы

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            start_point = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if(drag)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X-start_point.X, p.Y-start_point.Y);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void Add_Load(object sender, EventArgs e)
        {

        }

        private void Add_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            start_point = new Point(e.X, e.Y);
        }

        private void Add_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - start_point.X, p.Y - start_point.Y);
            }
        }

        private void Add_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void categoryBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
