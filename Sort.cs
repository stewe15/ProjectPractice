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
using static WindowsFormsApp1.Form1;
using System.Diagnostics;

namespace WindowsFormsApp1
{
    public partial class Sort : Form
    {
        bool drag = false;
        Point start_point = new Point(0, 0);
        bool isUpper = false;
        int isUpperValueController = 0;
        int isUpperMassController = 0;
        int isUpperNameController = 0;
        int isUpperPriceController = 0;
        int isUpperMaterialController = 0;


        string[] mas = File.ReadAllLines(@"tyrue.txt");
        //________________________________________
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

       
        
        public Sort()
        {
            InitializeComponent();
            readFromFile(@"tyrue.txt");
            SetAll();
            this.KeyDown += new KeyEventHandler(Sort_KeyDown);
        }

        void Sort_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Escape)
            {
                backSort_Click(backSort, null);
            }
        }
        //________________________________________
        //Сортировка по количеству
        private void valuesort_Click(object sender, EventArgs e)
        {
            upName.Hide();
            upMaterial.Hide();
            upPrice.Hide();
            upMassa.Hide();
            downMassa.Hide();
            downMaterial.Hide();
            downPrice.Hide();
            downName.Hide();
            isUpperValueController++;
            if (isUpperValueController%2 ==0)
            {
                isUpper = true;
                upValue.Show();
                downValue.Hide();
            }
            if(isUpperValueController%2 != 0)
            {
                isUpper = false;
                upValue.Hide();
                downValue.Show();
            }

            string[] massive = File.ReadAllLines(@"tyrue.txt");
            Tovar[] tovars = new Tovar[massive.Length];
            int CountGoods = massive.Length;
            for (int i = 0; i < massive.Length; i++)
            {
                string[] masiveDivaded = new string[100];
                masiveDivaded = massive[i].Split(' ');
                Tovar tovar = new Tovar();
                tovar.SettterId(Convert.ToInt32(masiveDivaded[0]));
                tovar.SetterName(masiveDivaded[1]);
                tovar.SetValue(Convert.ToInt32(masiveDivaded[2].ToString()));
                tovar.SetPrice(Convert.ToInt32(masiveDivaded[3].ToString()));
                tovar.SetMatrial(masiveDivaded[4]);
                tovar.SetMasa(Convert.ToDouble(masiveDivaded[5]));
                tovar.SetDesk(masiveDivaded[6]);
                tovars[i] = tovar;
                

            }
            if (isUpper == false)
            {
                for (int i = 0; i < tovars.Length; i++)
                {
                    for (int j = 0; j < tovars.Length; j++)
                    {
                        int n1 = tovars[i].GetterValue();
                        int n2 = tovars[j].GetterValue();

                        if (n1 < n2)
                        {
                            Tovar temp = new Tovar();
                            temp = tovars[i];
                            tovars[i] = tovars[j];
                            tovars[j] = temp;
                        }

                    }
                }
            }
            else
            {
                for (int i = 0; i < tovars.Length; i++)
                {
                    for (int j = 0; j < tovars.Length; j++)
                    {
                        int n1 = tovars[i].GetterValue();
                        int n2 = tovars[j].GetterValue();

                        if (n1 > n2)
                        {
                            Tovar temp = new Tovar();
                            temp = tovars[i];
                            tovars[i] = tovars[j];
                            tovars[j] = temp;
                        }

                    }
                }
            }
            string[] mass = new string[tovars.Length];
            for (int i = 0; i < tovars.Length; i++)
            {
                string line = tovars[i].GetterId().ToString() + " " + tovars[i].GetterName().ToString() + " " + tovars[i].GetterValue().ToString() + " " + tovars[i].GetterPrice() + " " + tovars[i].GetterMaterial().ToString() + " " + tovars[i].GetterMasa().ToString() + " " + tovars[i].GetterDesk().ToString();
                if (line != null)
                {
                    mass[i] = line;
                }


            }
            File.WriteAllLines(@"tyrue1.txt", mass);
            listOfAll.Rows.Clear();
            readFromFile(@"tyrue1.txt");
           
        }
        //________________________________________
        //Сортировка по массе
        private void massort_Click(object sender, EventArgs e)
        {
            upName.Hide();
            upMaterial.Hide();
            upPrice.Hide();
            upValue.Hide();
            downValue.Hide();
            downMaterial.Hide();
            downPrice.Hide();
            downName.Hide();
            isUpperMassController++;
            if (isUpperMassController % 2 == 0)
            {
                isUpper = true;
                upMassa.Show();
                downMassa.Hide();
            }
            if (isUpperMassController % 2 != 0)
            {
                isUpper = false;
                upMassa.Hide();
                downMassa.Show();
            }

            string[] massive = File.ReadAllLines(@"tyrue.txt");
            Tovar[] tovars = new Tovar[massive.Length];
            int CountGoods = massive.Length;
            for (int i = 0; i < massive.Length; i++)
            {
                string[] masiveDivaded = new string[100];
                masiveDivaded = massive[i].Split(' ');
                Tovar tovar = new Tovar();
                tovar.SettterId(Convert.ToInt32(masiveDivaded[0]));
                tovar.SetterName(masiveDivaded[1]);
                tovar.SetValue(Convert.ToInt32(masiveDivaded[2].ToString()));
                tovar.SetPrice(Convert.ToInt32(masiveDivaded[3].ToString()));
                tovar.SetMatrial(masiveDivaded[4]);
                tovar.SetMasa(Convert.ToDouble(masiveDivaded[5]));
                tovar.SetDesk(masiveDivaded[6]);
                tovars[i] = tovar;

            }
            if (isUpper == false)
            {
                for (int i = 0; i < tovars.Length; i++)
                {
                    for (int j = 0; j < tovars.Length; j++)
                    {
                        double n1 = tovars[i].GetterMasa();
                        double n2 = tovars[j].GetterMasa();

                        if (n1 < n2)
                        {
                            Tovar temp = new Tovar();
                            temp = tovars[i];
                            tovars[i] = tovars[j];
                            tovars[j] = temp;
                        }

                    }
                }
            }
            else
            {
                for (int i = 0; i < tovars.Length; i++)
                {
                    for (int j = 0; j < tovars.Length; j++)
                    {
                        double n1 = tovars[i].GetterMasa();
                        double n2 = tovars[j].GetterMasa();

                        if (n1 > n2)
                        {
                            Tovar temp = new Tovar();
                            temp = tovars[i];
                            tovars[i] = tovars[j];
                            tovars[j] = temp;
                        }

                    }
                }
            }
            string[] mass = new string[tovars.Length];
            for (int i = 0; i < tovars.Length; i++)
            {
                string line = tovars[i].GetterId().ToString() + " " + tovars[i].GetterName().ToString() + " " + tovars[i].GetterValue().ToString() + " " + tovars[i].GetterPrice() + " " + tovars[i].GetterMaterial().ToString() + " " + tovars[i].GetterMasa().ToString() + " " + tovars[i].GetterDesk().ToString();
                if (line != null)
                {
                    mass[i] = line;
                }


            }
            File.WriteAllLines(@"tyrue1.txt", mass);
            listOfAll.Rows.Clear();
            readFromFile(@"tyrue1.txt");
        }
        //________________________________________
        //Расчёт общей массы/цены/колличеств
        private void SetAll()
        {
            string[] massive = File.ReadAllLines(@"tyrue.txt");
            Tovar[] tovars = new Tovar[massive.Length];
            int CountGoods = massive.Length;
            for (int i = 0; i < massive.Length; i++)
            {
                string[] masiveDivaded = new string[100];
                masiveDivaded = massive[i].Split(' ');
                Tovar tovar = new Tovar();
                tovar.SettterId(Convert.ToInt32(masiveDivaded[0]));
                tovar.SetterName(masiveDivaded[1]);
                tovar.SetValue(Convert.ToInt32(masiveDivaded[2].ToString()));
                tovar.SetPrice(Convert.ToInt32(masiveDivaded[3].ToString()));
                tovar.SetMatrial(masiveDivaded[4]);
                tovar.SetMasa(Convert.ToDouble(masiveDivaded[5]));
                
                
                tovars[i] = tovar;

            }
            int AllVal = 0;
            double allMas = 0;
            int allCash = 0;
            for (int i = 0; i < tovars.Length; i++)
            {
                AllVal += tovars[i].GetterValue();
                allMas += tovars[i].GetterMasa() * tovars[i].GetterValue();
                allCash += tovars[i].GetterPrice();
            }

            AllValueText.Text = AllVal.ToString();
            AllMassText.Text = allMas.ToString();
            AllCashText.Text = allCash.ToString();
        }


        
        private void crest_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите выйти?", "Уведомление системы", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void backSort_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 =new Form1();
            form1.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Sort_Load(object sender, EventArgs e)
        {

        }

        private void listOfAll_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите выйти?", "Уведомление системы", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Sort_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            start_point = new Point(e.X, e.Y);
        }

        private void Sort_MouseMove(object sender, MouseEventArgs e)
        {
            if(drag)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - start_point.X, p.Y - start_point.Y);
            }
            
        }

        private void Sort_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            start_point = new Point(e.X, e.Y);
        }

        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {
            if(drag)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - start_point.X, p.Y - start_point.Y);
            }
            
        }

        private void panel3_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }




        //________________________________________
        //Сортировка по имени
        private void namesort_Click_1(object sender, EventArgs e)
        {
            upMaterial.Hide();
            upPrice.Hide();
            upValue.Hide();
            upMassa.Hide();
            downValue.Hide();
            downMassa.Hide();
            downMaterial.Hide();
            downPrice.Hide();
            isUpperNameController++;
            if (isUpperNameController % 2 == 0)
            {
                isUpper = true;
                upName.Show();
                downName.Hide();
            }
            if (isUpperNameController % 2 != 0)
            {
                isUpper = false;
                upName.Hide();
                downName.Show();
            }

            string[] massive = File.ReadAllLines(@"tyrue.txt");
            Tovar[] tovars = new Tovar[massive.Length];
            int CountGoods = massive.Length;
            for (int i = 0; i < massive.Length; i++)
            {
                string[] masiveDivaded = new string[100];
                masiveDivaded = massive[i].Split(' ');
                Tovar tovar = new Tovar();
                tovar.SettterId(Convert.ToInt32(masiveDivaded[0]));
                tovar.SetterName(masiveDivaded[1]);
                tovar.SetValue(Convert.ToInt32(masiveDivaded[2].ToString()));
                tovar.SetPrice(Convert.ToInt32(masiveDivaded[3].ToString()));
                tovar.SetMatrial(masiveDivaded[4]);
                tovar.SetMasa(Convert.ToDouble(masiveDivaded[5]));
                tovar.SetDesk(masiveDivaded[6]);
                tovars[i] = tovar;

            }
            if (isUpper == false)
            {
                for (int i = 0; i < tovars.Length; i++)
                {
                    for (int j = 0; j < tovars.Length; j++)
                    {
                        try
                        {
                            char n1 = tovars[i].GetterName()[0];
                            char n2 = tovars[j].GetterName()[0];
                            char n3 = tovars[i].GetterName()[1];
                            char n4 = tovars[j].GetterName()[1];
                            n1 = Convert.ToChar(n1);
                            n2 = Convert.ToChar(n2);
                            n3 = Convert.ToChar(n3);
                            n4 = Convert.ToChar(n4);
                            if ((int)n1 + (int)n3 < (int)n2 + (int)n4)
                            {
                                Tovar temp = new Tovar();
                                temp = tovars[i];
                                tovars[i] = tovars[j];
                                tovars[j] = temp;
                            }
                        }
                        catch
                        {
                            char n1 = tovars[i].GetterName()[0];
                            char n2 = tovars[j].GetterName()[0];
                            n1 = Convert.ToChar(n1);
                            n2 = Convert.ToChar(n2);
                            if((int)n1 < (int)n2)
                            {
                                Tovar temp = new Tovar();
                                temp = tovars[i];
                                tovars[i] = tovars[j];
                                tovars[j] = temp;
                            }
                        }

                    }
                }
            }
            else
            {
                for (int i = 0; i < tovars.Length; i++)
                {
                    for (int j = 0; j < tovars.Length; j++)
                    {
                        try
                        {
                            char n1 = tovars[i].GetterName()[0];
                            char n2 = tovars[j].GetterName()[0];
                            char n3 = tovars[i].GetterName()[1];
                            char n4 = tovars[j].GetterName()[1];
                            n1 = Convert.ToChar(n1);
                            n2 = Convert.ToChar(n2);
                            n3 = Convert.ToChar(n3);
                            n4 = Convert.ToChar(n4);
                            if ((int)n1 + (int)n3 > (int)n2 + (int)n4)
                            {
                                Tovar temp = new Tovar();
                                temp = tovars[i];
                                tovars[i] = tovars[j];
                                tovars[j] = temp;
                            }
                        }
                        catch
                        {
                            char n1 = tovars[i].GetterName()[0];
                            char n2 = tovars[j].GetterName()[0];
                            n1 = Convert.ToChar(n1);
                            n2 = Convert.ToChar(n2);
                            if ((int)n1 > (int)n2)
                            {
                                Tovar temp = new Tovar();
                                temp = tovars[i];
                                tovars[i] = tovars[j];
                                tovars[j] = temp;
                            }
                        }

                    }
                }
            }
            string[] mass = new string[tovars.Length];
            for (int i = 0; i < tovars.Length; i++)
            {
                string line = tovars[i].GetterId().ToString() + " " + tovars[i].GetterName().ToString() + " " + tovars[i].GetterValue().ToString() + " " + tovars[i].GetterPrice() + " " + tovars[i].GetterMaterial().ToString() + " " + tovars[i].GetterMasa().ToString() + " " + tovars[i].GetterDesk().ToString();
                if (line != null)
                {
                    mass[i] = line;
                }


            }
            File.WriteAllLines(@"tyrue1.txt", mass);
            listOfAll.Rows.Clear();
            readFromFile(@"tyrue1.txt");

        }

        //________________________________________
        //Сортировка по цене

        private void cashsort_Click(object sender, EventArgs e)
        {
            upName.Hide();
            upMaterial.Hide();
            upValue.Hide();
            upMassa.Hide();
            downValue.Hide();
            downMassa.Hide();
            downMaterial.Hide();
            downName.Hide();
            isUpperPriceController++;
            if (isUpperPriceController % 2 == 0)
            {
                isUpper = true;
                upPrice.Show();
                downPrice.Hide();
            }
            if (isUpperPriceController % 2 != 0)
            {
                isUpper = false;
                upPrice.Hide();
                downPrice.Show();
            }
            string[] massive = File.ReadAllLines(@"tyrue.txt");
            Tovar[] tovars = new Tovar[massive.Length];
            int CountGoods = massive.Length;
            for (int i = 0; i < massive.Length; i++)
            {
                string[] masiveDivaded = new string[100];
                masiveDivaded = massive[i].Split(' ');
                Tovar tovar = new Tovar();
                tovar.SettterId(Convert.ToInt32(masiveDivaded[0]));
                tovar.SetterName(masiveDivaded[1]);
                tovar.SetValue(Convert.ToInt32(masiveDivaded[2].ToString()));
                tovar.SetPrice(Convert.ToInt32(masiveDivaded[3].ToString()));
                tovar.SetMatrial(masiveDivaded[4]);
                tovar.SetMasa(Convert.ToDouble(masiveDivaded[5]));
                tovar.SetDesk(masiveDivaded[6]);
                tovars[i] = tovar;

            }
            if (isUpper == false)
            {
                for (int i = 0; i < tovars.Length; i++)
                {
                    for (int j = 0; j < tovars.Length; j++)
                    {
                        int n1 = tovars[i].GetterPrice();
                        int n2 = tovars[j].GetterPrice();
                        
                        if (n1 < n2)
                        {
                            Tovar temp = new Tovar();
                            temp = tovars[i];
                            tovars[i] = tovars[j];
                            tovars[j] = temp;
                        }

                    }
                }
            }
            else
            {
                for (int i = 0; i < tovars.Length; i++)
                {
                    for (int j = 0; j < tovars.Length; j++)
                    {
                        int n1 = tovars[i].GetterPrice();
                        int n2 = tovars[j].GetterPrice();

                        if (n1 > n2)
                        {
                            Tovar temp = new Tovar();
                            temp = tovars[i];
                            tovars[i] = tovars[j];
                            tovars[j] = temp;
                        }

                    }
                }
            }
            string[] mass = new string[tovars.Length];
            for (int i = 0; i < tovars.Length; i++)
            {
                string line = tovars[i].GetterId().ToString() + " " + tovars[i].GetterName().ToString() + " " + tovars[i].GetterValue().ToString() + " " + tovars[i].GetterPrice() + " " + tovars[i].GetterMaterial().ToString() + " " + tovars[i].GetterMasa().ToString()+" " + tovars[i].GetterDesk().ToString();
                if (line != null)
                {
                    mass[i] = line;
                }


            }
            File.WriteAllLines(@"tyrue1.txt", mass);
            listOfAll.Rows.Clear();
            readFromFile(@"tyrue1.txt");
        }
        //________________________________________
        //Сортировка по материалу
        private void materialsort_Click(object sender, EventArgs e)
        {
            upName.Hide();
            upPrice.Hide();
            upValue.Hide();
            upMassa.Hide();
            downValue.Hide();
            downMassa.Hide();
            downPrice.Hide();
            downName.Hide();
            isUpperMaterialController++;
            if (isUpperMaterialController % 2 == 0)
            {
                isUpper = true;
                upMaterial.Show();
                downMaterial.Hide();
            }
            if (isUpperMaterialController % 2 != 0)
            {
                isUpper = false;
                upMaterial.Hide();
                downMaterial.Show();
            }
            string[] massive = File.ReadAllLines(@"tyrue.txt");
            Tovar[] tovars = new Tovar[massive.Length];
            int CountGoods = massive.Length;
            for (int i = 0; i < massive.Length; i++)
            {
                string[] masiveDivaded = new string[100];
                masiveDivaded = massive[i].Split(' ');
                Tovar tovar = new Tovar();
                tovar.SettterId(Convert.ToInt32(masiveDivaded[0]));
                tovar.SetterName(masiveDivaded[1]);
                tovar.SetValue(Convert.ToInt32(masiveDivaded[2].ToString()));
                tovar.SetPrice(Convert.ToInt32(masiveDivaded[3].ToString()));
                tovar.SetMatrial(masiveDivaded[4]);
                tovar.SetMasa(Convert.ToDouble(masiveDivaded[5]));
                tovar.SetDesk(masiveDivaded[6]);
                tovars[i] = tovar;

            }
            if (isUpper == false)
            {
                for (int i = 0; i < tovars.Length; i++)
                {
                    for (int j = 0; j < tovars.Length; j++)
                    {
                        char n1 = tovars[i].GetterMaterial()[0];
                        char n2 = tovars[j].GetterMaterial()[0];
                        char n3 = tovars[i].GetterMaterial()[1];
                        char n4 = tovars[j].GetterMaterial()[1];
                        n1 = Convert.ToChar(n1);
                        n2 = Convert.ToChar(n2);
                        n3 = Convert.ToChar(n3);
                        n4 = Convert.ToChar(n4);
                        if ((int)n1 + (int)n3 < (int)n2 + (int)n4)
                        {
                            Tovar temp = new Tovar();
                            temp = tovars[i];
                            tovars[i] = tovars[j];
                            tovars[j] = temp;
                        }

                    }
                }
            }
            else
            {
                for (int i = 0; i < tovars.Length; i++)
                {
                    for (int j = 0; j < tovars.Length; j++)
                    {
                        char n1 = tovars[i].GetterMaterial()[0];
                        char n2 = tovars[j].GetterMaterial()[0];
                        char n3 = tovars[i].GetterMaterial()[1];
                        char n4 = tovars[j].GetterMaterial()[1];
                        n1 = Convert.ToChar(n1);
                        n2 = Convert.ToChar(n2);
                        n3 = Convert.ToChar(n3);
                        n4 = Convert.ToChar(n4);
                        if ((int)n1 + (int)n3 > (int)n2 + (int)n4)
                        {
                            Tovar temp = new Tovar();
                            temp = tovars[i];
                            tovars[i] = tovars[j];
                            tovars[j] = temp;
                        }

                    }
                }
            }
            string[] mass = new string[tovars.Length];
            for (int i = 0; i < tovars.Length; i++)
            {
                string line = tovars[i].GetterId().ToString() + " " + tovars[i].GetterName().ToString() + " " + tovars[i].GetterValue().ToString() + " " + tovars[i].GetterPrice() + " " + tovars[i].GetterMaterial().ToString() + " " + tovars[i].GetterMasa().ToString() + " " + tovars[i].GetterDesk().ToString();
                if (line != null)
                {
                    mass[i] = line;
                }


            }
            File.WriteAllLines(@"tyrue1.txt", mass);
            listOfAll.Rows.Clear();
            readFromFile(@"tyrue1.txt");
        }

    }


}
