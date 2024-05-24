using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Spire.Xls;
using System.Reflection;
using System.Diagnostics;
using System.Media;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        bool drag = false;
        Point start_point = new Point(0, 0);
        int Counter = 0;
        int SortCounter = 1;
        int Cheker = 0;
        static int CounterOne = 0;
        int RememberedID = 0;

        string[] mas = File.ReadAllLines(@"tyrue.txt");
        bool isUpper = false;
        int showTips = 0;

        


        //___________________________________________________
        //Определение присваемого id
        public void setCounter()
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


        //_________________________________
        //Класс для описания товара
        public class Tovar
        {
            private int id;
            private string name;
            private double masa;
            private string material;
            private int value;
            private int price;
            private string directory;
            //________________________
            //Запись в файл
            public void addToFile()
            {
                string path = @"tyrue.txt";
                
                
                string line = id.ToString() + " " + name + " " + value.ToString() + " " + price.ToString() + " " + material + " " + masa.ToString() + " " + directory.ToString() + " \n";
                FileInfo file = new FileInfo(path);
                if (file.Exists)
                {
                    File.AppendAllText(path, line);
                }
            }
                
                    
                

            //__________________
            //Удаление из файла
            public void deleteFromFile(int id)
            {
                if(id <= CounterOne)
                {
                    var Log = id.ToString();
                    string path = @"tyrue.txt";
                    string[] delUser = File.ReadAllLines(path); 
                    StreamWriter sw = new StreamWriter(path, false);
                    bool flag = false;
                    for (int i = 0; i < delUser.Length; i++)
                    {
                        string[] splitet = delUser[i].Split(' ');
                        if (Convert.ToInt32(splitet[0]) == id)
                        {
                            delUser[i] = " ";
                            flag = true;
                        }
 
                    }
                    if(flag == false)
                    {
                        MessageBox.Show("Не существует объект удаления", "Ошибка удаления", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                else
                {
                    MessageBox.Show("Не существует объект удаления", "Ошибка удаления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }


            public void SettterId(int idSet)
            {
                id = idSet;
            }
            public void SetMatrial(string mt)
            {
                material = mt;
            }
            public void SetterName(string nm)
            {
                name = nm;
            }
            public void SetMasa(double dsk)
            {
                masa = dsk;
            }
            public void SetValue(int vl)
            {
                value = vl;
            }
            public void SetPrice(int pr)
            {
                price = pr;
            }
            public void SetDesk(string ds)
            {
                directory = ds;
            }
            public string GetterDesk()
            {
                return directory;
            }

            public int GetterId()
            {
                return id;
            }
            public string GetterName()
            {
                return name;
            }
            public double GetterMasa()
            {
                return masa;
            }
            public int GetterValue()
            {
                return value;
            }
            public int GetterPrice()
            {
                return price;
            }
            public string GetterMaterial() { return material; }

        }
        //________________________
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

        
        public Form1()
        {
            InitializeComponent();
            readFromFile(@"tyrue.txt");
            setCounter();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Addprod_Click(object sender, EventArgs e)
        {
            this.Hide();
            Add addForm = new Add();
            addForm.Show();
            Counter = 1;
            SortCounter = 1;
        }
        
        //_______________________________________
        //Скрыть показать строку поиска

        private void research_Click(object sender, EventArgs e)
        {
            Counter++;
            if(Counter % 2==0)
            {
                searchText.Visible = true;
            }
            else if(Counter%2!=0)
            {
                searchText.Visible = false;
            }
            SortCounter = 1;
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
        //________________
        //Динамический поиск 
        private void searchText_TextChanged(object sender, EventArgs e)
        {
           
            string text = searchText.Text;
            StreamReader sr = new StreamReader(@"tyrue.txt");
            StreamWriter sw = new StreamWriter(@"buffer.txt");

            while (!sr.EndOfStream)
            {
                string lines = sr.ReadLine();
                if (lines.Contains(text))
                {
                    sw.WriteLine(lines);
                }

            }
            
            sw.Close();
            sr.Close();
            listOfAll.Rows.Clear();
            readFromFile(@"buffer.txt");

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
            Changer changeForm = new Changer();
            changeForm.Show();
           

        }

       

        

        private void goodsList_TextChanged(object sender, EventArgs e)
        {

        }

        private void desktext_TextChanged(object sender, EventArgs e)
        {

        }

        private void desk_Click(object sender, EventArgs e)
        {

        }

        private void redact_Click(object sender, EventArgs e)
        {
            
        }

        

        private void addbutton_Click_1(object sender, EventArgs e)
        {
            
        }

        private void deletebutton_Click(object sender, EventArgs e)
        {
            

        }

        private void exportButton_Click(object sender, EventArgs e)
        {

        }

        private void sortprod_Click(object sender, EventArgs e)
        {
            this.Hide();
            Sort sortForm = new Sort();
            sortForm.Show();
            
        }

        private void goodsList_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void Logo_Click(object sender, EventArgs e)
        {

        }
        //_______________________________________
        //Создание эксель таблицы и её заполнение
        public void CreateBook()
        {
            Workbook book = new Workbook();
            Worksheet worksheet = book.Worksheets[0];
            worksheet.Range[1, 1].Value = "Id";
            worksheet.Range[1, 2].Value = "Имя";
            worksheet.Range[1, 3].Value = "Масса";
            worksheet.Range[1, 4].Value = "Количество";
            worksheet.Range[1, 5].Value = "Цена";
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
            int lengthOfMass = 0;
            int allCash = 0;
            int allValue = 0;
            double allMas = 0;
            for (int i = 0; i < tovars.Length; i++)
            {
                worksheet.Range[i + 2, 1].Value = tovars[i].GetterId().ToString();
                worksheet.Range[i + 2, 2].Value = tovars[i].GetterName().ToString();
                worksheet.Range[i + 2, 3].Value = tovars[i].GetterMasa().ToString();
                worksheet.Range[i + 2, 4].Value = tovars[i].GetterValue().ToString();
                worksheet.Range[i + 2, 5].Value = tovars[i].GetterPrice().ToString();
                lengthOfMass++;
                allCash += tovars[i].GetterPrice();
                allValue += tovars[i].GetterValue();
                allMas += tovars[i].GetterMasa();
            }
            lengthOfMass++;
            worksheet.Range[lengthOfMass + 1, 1].Value = "Общая стомость: ";
            worksheet.Range[lengthOfMass + 1, 2].Value = allCash.ToString();
            worksheet.Range[lengthOfMass + 2, 1].Value = "Общее количество: ";
            worksheet.Range[lengthOfMass + 2, 2].Value = allValue.ToString();
            worksheet.Range[lengthOfMass + 3, 1].Value = "Общая масса: ";
            worksheet.Range[lengthOfMass + 3, 2].Value = allMas.ToString();
            worksheet.AllocatedRange.AutoFitColumns();
            Chart chart = worksheet.Charts.Add(ExcelChartType.ColumnClustered);
            Chart chartL = worksheet.Charts.Add(ExcelChartType.Line);
            Chart chartR = worksheet.Charts.Add(ExcelChartType.Pie);
            chart.DataRange = worksheet.Range["B1:E" + lengthOfMass.ToString()];
            chartL.DataRange = worksheet.Range["B1:E" + lengthOfMass.ToString()];
            chartR.DataRange = worksheet.Range["B1:E" + lengthOfMass.ToString()];
            chart.SeriesDataFromRange = false;
            chart.LeftColumn = 7;
            chart.TopRow = 15;
            chart.RightColumn = 20;
            chart.BottomRow = 29;
            chartL.SeriesDataFromRange = false;
            chartL.LeftColumn = 7;
            chartL.TopRow = 1;
            chartL.RightColumn = 20;
            chartL.BottomRow = 15;
            chartR.SeriesDataFromRange = false;
            chartR.LeftColumn = 20;
            chartR.TopRow = 1;
            chartR.RightColumn = 30;
            chartR.BottomRow = 15;
            chart.ChartTitle = "Общая гистограмма";
            chart.PrimaryValueAxis.Title = "Величина в кг, долларах и штуках";
            chartL.ChartTitle = "Общий график";
            chartL.PrimaryValueAxis.Title = "Величина в кг, долларах и штуках";
            chartR.ChartTitle = "Товары по массе";
            chartR.PrimaryValueAxis.Title = "Величина в кг, долларах и штуках";

            book.SaveToFile("Отчет.xls", ExcelVersion.Version2007);
            MessageBox.Show("Отчет импортирован в Excel", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult result = MessageBox.Show("Хотите открыть отчет Excel?", "Уведомление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                var newProcessInfo = new ProcessStartInfo();
                newProcessInfo.FileName = @"Excel.exe";
                newProcessInfo.Arguments = @"Отчет.xls";
                Process process = new Process();
                process.StartInfo = newProcessInfo;
                process.Start();
                process.WaitForExit();

            }
            if (result == DialogResult.No)
            {

            }
        }
        public void CreateBooks()
        {
            Workbook book = new Workbook();
            Worksheet worksheet = book.Worksheets[0];
            worksheet.Range[1, 1].Value = "Таблица по массе";
            worksheet.Range[2, 1].Value = "Мебель";
            worksheet.Range[3, 1].Value = "Стройматериалы";
            worksheet.Range[4, 1].Value = "Товары для дома";
            worksheet.Range[5, 1].Value = "Садовая техника";
            worksheet.Range[6, 1].Value = "Декор";
            worksheet.Range[7, 1].Value = "Инструменты";
            worksheet.Range[8, 1].Value = "Крепёжные изделия";
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
            double MassMeb = 0;
            double MassStroi = 0;
            double MassDom = 0;
            double MassTech = 0;
            double MassDeck = 0;
            double MasssInst = 0;
            double MassKrep = 0;
            for(int i = 0; i < tovars.Length; i++)
            {
                if(tovars[i].GetterDesk() == "Мебель")
                {
                    MassMeb+=tovars[i].GetterMasa() * tovars[i].GetterValue();
                }
                if (tovars[i].GetterDesk() == "Стройматериалы")
                {
                    MassStroi += tovars[i].GetterMasa() * tovars[i].GetterValue();
                }
                if (tovars[i].GetterDesk() == "Товары_для_дома")
                {
                    MassDom += tovars[i].GetterMasa() * tovars[i].GetterValue();
                }
                if (tovars[i].GetterDesk() == "Садовая_техника")
                {
                    MassTech += tovars[i].GetterMasa() * tovars[i].GetterValue();
                }
                if (tovars[i].GetterDesk() == "Декор")
                {
                    MassDeck += tovars[i].GetterMasa() * tovars[i].GetterValue();
                }
                if (tovars[i].GetterDesk() == "Инструменты")
                {
                    MasssInst += tovars[i].GetterMasa() * tovars[i].GetterValue();
                }
                if (tovars[i].GetterDesk() == "Крепежные_изделия")
                {
                    MassKrep += tovars[i].GetterMasa() * tovars[i].GetterValue();
                }

            }
            worksheet.Range[2, 2].Value = MassMeb.ToString();
            worksheet.Range[3, 2].Value = MassStroi.ToString();
            worksheet.Range[4, 2].Value = MassDom.ToString();
            worksheet.Range[5, 2].Value = MassTech.ToString();
            worksheet.Range[6, 2].Value = MassDeck.ToString();
            worksheet.Range[7, 2].Value = MasssInst.ToString();
            worksheet.Range[8, 2].Value = MassKrep.ToString();
            worksheet.Range[9,1].Value = "/////////////////////////////////////////////////////";
            worksheet.Range[10, 1].Value = "Таблица по колличеству";
            worksheet.Range[11, 1].Value = "Мебель";
            worksheet.Range[12, 1].Value = "Стройматериалы";
            worksheet.Range[13, 1].Value = "Товары для дома";
            worksheet.Range[14, 1].Value = "Садовая техника";
            worksheet.Range[15, 1].Value = "Декор";
            worksheet.Range[16, 1].Value = "Инструменты";
            worksheet.Range[17, 1].Value = "Крепёжные изделия";
            double ValMeb = 0;
            double ValStroi = 0;
            double ValDom = 0;
            double ValTech = 0;
            double ValDeck = 0;
            double ValInst = 0;
            double ValKrep = 0;
            for (int i = 0; i < tovars.Length; i++)
            {
                if (tovars[i].GetterDesk() == "Мебель")
                {
                    ValMeb += tovars[i].GetterMasa() * tovars[i].GetterValue();
                }
                if (tovars[i].GetterDesk() == "Стройматериалы")
                {
                    ValStroi += tovars[i].GetterValue();
                }
                if (tovars[i].GetterDesk() == "Товары_для_дома")
                {
                    ValDom += tovars[i].GetterValue();
                }
                if (tovars[i].GetterDesk() == "Садовая_техника")
                {
                    ValTech += tovars[i].GetterMasa() * tovars[i].GetterValue();
                }
                if (tovars[i].GetterDesk() == "Декор")
                {
                    ValDeck += tovars[i].GetterValue();
                }
                if (tovars[i].GetterDesk() == "Инструменты")
                {
                    ValInst += tovars[i].GetterValue();
                }
                if (tovars[i].GetterDesk() == "Крепежные_изделия")
                {
                    ValKrep += tovars[i].GetterValue();
                }

            }
            worksheet.Range[11, 2].Value = ValMeb.ToString();
            worksheet.Range[12, 2].Value = ValStroi.ToString();
            worksheet.Range[13, 2].Value = ValDom.ToString();
            worksheet.Range[14, 2].Value = ValTech.ToString();
            worksheet.Range[15, 2].Value = ValDeck.ToString();
            worksheet.Range[16, 2].Value = ValInst.ToString();
            worksheet.Range[17, 2].Value = ValKrep.ToString();
            worksheet.Range[18, 1].Value = "/////////////////////////////////////////////////////";
            worksheet.Range[19, 1].Value = "Таблица по цене";
            worksheet.Range[20, 1].Value = "Мебель";
            worksheet.Range[21, 1].Value = "Стройматериалы";
            worksheet.Range[22, 1].Value = "Товары для дома";
            worksheet.Range[23, 1].Value = "Садовая техника";
            worksheet.Range[24, 1].Value = "Декор";
            worksheet.Range[25, 1].Value = "Инструменты";
            worksheet.Range[26, 1].Value = "Крепёжные изделия";
            double CashMeb = 0;
            double CashStroi = 0;
            double CashDom = 0;
            double CashTech = 0;
            double CashDeck = 0;
            double CashInst = 0;
            double CashKrep = 0;
            for (int i = 0; i < tovars.Length; i++)
            {
                if (tovars[i].GetterDesk() == "Мебель")
                {
                    CashMeb += tovars[i].GetterPrice() * tovars[i].GetterValue();
                }
                if (tovars[i].GetterDesk() == "Стройматериалы")
                {
                    CashStroi += tovars[i].GetterPrice() * tovars[i].GetterValue();
                }
                if (tovars[i].GetterDesk() == "Товары_для_дома")
                {
                    CashDom += tovars[i].GetterPrice() * tovars[i].GetterValue();
                }
                if (tovars[i].GetterDesk() == "Садовая_техника")
                {
                    CashTech += tovars[i].GetterPrice() * tovars[i].GetterValue();
                }
                if (tovars[i].GetterDesk() == "Декор")
                {
                    CashDeck += tovars[i].GetterPrice() * tovars[i].GetterValue();
                }
                if (tovars[i].GetterDesk() == "Инструменты")
                {
                    CashInst += tovars[i].GetterPrice() * tovars[i].GetterValue();
                }
                if (tovars[i].GetterDesk() == "Крепежные_изделия")
                {
                    CashKrep += tovars[i].GetterMasa() * tovars[i].GetterValue();
                }

            }
            worksheet.Range[20, 2].Value = CashMeb.ToString();
            worksheet.Range[21, 2].Value = CashStroi.ToString();
            worksheet.Range[22, 2].Value = CashDom.ToString();
            worksheet.Range[23, 2].Value = CashTech.ToString();
            worksheet.Range[24, 2].Value = CashDeck.ToString();
            worksheet.Range[25, 2].Value = CashInst.ToString();
            worksheet.Range[26, 2].Value = CashKrep.ToString();
            int allCash = 0;
            int allValue = 0;
            double allMas = 0;
            for(int i = 0; i < tovars.Length; i++)
            {
                allCash+=tovars[i].GetterPrice() * tovars[i].GetterValue();
                allValue+=tovars[i].GetterValue();
                allMas+=tovars[i].GetterValue()* tovars[i].GetterMasa();
            }
            worksheet.Range[27, 1].Value = "/////////////////////////////////////////////////////";
            worksheet.Range[28, 1].Value = "Общая цена";
            worksheet.Range[29, 1].Value = "Общее количество";
            worksheet.Range[30, 1].Value = "Общая масса";
            worksheet.Range[28, 2].Value = allCash.ToString();
            worksheet.Range[29, 2].Value = allValue.ToString();
            worksheet.Range[30, 2].Value = allMas.ToString();
            worksheet.AllocatedRange.AutoFitColumns();
            Chart chart = worksheet.Charts.Add(ExcelChartType.Pie);
            //ColumnClustered
            Chart chartL = worksheet.Charts.Add(ExcelChartType.Pie);
            Chart chartR = worksheet.Charts.Add(ExcelChartType.BarClustered);
            chart.DataRange = worksheet.Range["A2:B8" ];
            chartL.DataRange = worksheet.Range["A11:B17"];
            chartR.DataRange = worksheet.Range["A20:B26"];
            chart.SeriesDataFromRange = false;
            chart.LeftColumn = 7;
            chart.TopRow = 15;
            chart.RightColumn = 20;
            chart.BottomRow = 29;
            chartL.SeriesDataFromRange = false;
            chartL.LeftColumn = 7;
            chartL.TopRow = 1;
            chartL.RightColumn = 20;
            chartL.BottomRow = 15;
            chartR.SeriesDataFromRange = false;
            chartR.LeftColumn = 20;
            chartR.TopRow = 1;
            chartR.RightColumn = 30;
            chartR.BottomRow = 15;
            chart.ChartTitle = "Процентная величина категорий от массы";
            chart.PrimaryValueAxis.Title = "Величина кг";
            chartL.ChartTitle = "Процентное соотношение категорий от общего числа";
            chartL.PrimaryValueAxis.Title = "Величина в штуках";
            chartR.ChartTitle = "График стоимости каждой категории";
            book.SaveToFile("Отчет.xls", ExcelVersion.Version2007);
            MessageBox.Show("Отчет импортирован в Excel", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult result = MessageBox.Show("Хотите открыть отчет Excel?", "Уведомление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                var newProcessInfo = new ProcessStartInfo();
                newProcessInfo.FileName = @"Excel.exe";
                newProcessInfo.Arguments = @"Отчет.xls";
                Process process = new Process();
                process.StartInfo = newProcessInfo;
                process.Start();
                process.WaitForExit();

            }



        }
        //________________________________________
        //Обработка нажатия кнопки создания отчёта
        private void exportButton_Click_1(object sender, EventArgs e)
        {
            //CreateBook();
            CreateBooks();
        }
        private void listOfAll_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        //________________________________________
        //Обработка возможности перемещения формы
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            start_point = new Point(e.X, e.Y);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if(drag)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X-start_point.X, p.Y-start_point.Y);
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите выйти?","Уведомление системы",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                Application.Exit();
            }
           
        }

        private void minimalizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //________________________________________
        //Обработка возможности перемещения формы
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            start_point = new Point(e.X, e.Y);
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if( drag )
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - start_point.X, p.Y - start_point.Y);
            }
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void sortProd_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Sort sort = new Sort();
            sort.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Music music = new Music();
            music.Show();
        }
    }
}
