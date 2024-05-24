using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Music : Form
    {
bool drag = false;
        Point start_point = new Point(0, 0);

       
        public Music()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(Music_KeyDown);
        }

        private void Music_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }
private void backMusic_Click(object sender, EventArgs e)
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

        private void miniButton_Click(object sender, EventArgs e)
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

        private void Music_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            start_point = new Point(e.X, e.Y);
        }

        private void Music_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - start_point.X, p.Y - start_point.Y);
            }
        }

        private void Music_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void jazz_Click(object sender, EventArgs e)
        {
            try
            {
                SoundPlayer sp = new SoundPlayer();
                sp.SoundLocation = "Jazz.wav";
                sp.Load();
                sp.PlayLooping();
            }
            catch
            {
                MessageBox.Show("Аудиофайл не обнаружен", "Ошибка воспроизведения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void metal_Click(object sender, EventArgs e)
        {
            try
            {
                SoundPlayer sp = new SoundPlayer();
                sp.SoundLocation = "Metal.wav";
                sp.Load();
                sp.PlayLooping();
            }
            catch
            {
                MessageBox.Show("Аудиофайл не обнаружен", "Ошибка воспроизведения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rock_Click(object sender, EventArgs e)
        {
            try
            {
                SoundPlayer sp = new SoundPlayer();
                sp.SoundLocation = "Rock.wav";
                sp.Load();
                sp.PlayLooping();
            }
            catch
            {
                MessageBox.Show("Аудиофайл не обнаружен", "Ошибка воспроизведения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void classic_Click(object sender, EventArgs e)
        {
            try
            {
                SoundPlayer sp = new SoundPlayer();
                sp.SoundLocation = "Classical.wav";
                sp.Load();
                sp.PlayLooping();
            }
            catch
            {
                MessageBox.Show("Аудиофайл не обнаружен", "Ошибка воспроизведения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void hiphop_Click(object sender, EventArgs e)
        {
            try
            {
                SoundPlayer sp = new SoundPlayer();
                sp.SoundLocation = "HipHop.wav";
                sp.Load();
                sp.PlayLooping();
            }
            catch
            {
                MessageBox.Show("Аудиофайл не обнаружен", "Ошибка воспроизведения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dubstep_Click(object sender, EventArgs e)
        {
            try
            {
                SoundPlayer sp = new SoundPlayer();
                sp.SoundLocation = "Dubstep.wav";
                sp.Load();
                sp.PlayLooping();
            }
            catch
            {
                MessageBox.Show("Аудиофайл не обнаружен", "Ошибка воспроизведения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pop_Click(object sender, EventArgs e)
        {
            try
            {
                SoundPlayer sp = new SoundPlayer();
                sp.SoundLocation = "Pop.wav";
                sp.Load();
                sp.PlayLooping();
            }
            catch 
            {
                MessageBox.Show("Аудиофайл не обнаружен", "Ошибка воспроизведения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void EDM_Click(object sender, EventArgs e)
        {
            try
            {
                SoundPlayer sp = new SoundPlayer();
                sp.SoundLocation = "EDM.wav";
                sp.Load();
                sp.PlayLooping();
            }
            catch
            {
                MessageBox.Show("Аудиофайл не обнаружен", "Ошибка воспроизведения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        }
    }
}
