using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
namespace Radio_Pro
{
    public partial class splash : Form
    {
        public splash()
        {
            InitializeComponent();
        }
        public int timeLeft { get; set; }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Refresh();
            int percent = (int)(((double)(progressBar1.Value - progressBar1.Minimum) /
            (double)(progressBar1.Maximum - progressBar1.Minimum)) * 100);
            using (Graphics gr = progressBar1.CreateGraphics())
            {
                gr.DrawString(percent.ToString() + "%",
                    new Font("Arial",
                                          (float)15.25, FontStyle.Bold),
                     Brushes.Red,
                    new PointF(progressBar1.Width / 2 - (gr.MeasureString(percent.ToString() + "%",
                        SystemFonts.DefaultFont).Width / 2.0F),
                    progressBar1.Height / 2 - (gr.MeasureString(percent.ToString() + "%",
                        SystemFonts.DefaultFont).Height / 2.0F)));
            }

            progressBar1.Increment(5);
            if (progressBar1.Value == 50)
            {
                pictureBox1.Image = new Bitmap(@"D:\Radio\Radio_Pro\Image\doctor.jpg");
                          
            }
            else if (progressBar1.Value == 75)
            {
                pictureBox1.Image = new Bitmap(@"D:\Radio\Radio_Pro\Image\flash4.jpg");
                
            }
            else if (progressBar1.Value == 100)
            {
                pictureBox1.Image = new Bitmap(@"D:\Radio\Radio_Pro\Image\Become-a-Doctor.jpg");
                timer1.Stop();
                
                this.Hide();
                frmLogincs login= new frmLogincs();
                login.Show();
                ProcessStartInfo sInfo = new ProcessStartInfo("chrome.exe", "http://localhost/Test_Local_Server_Db/getelement.php");
                Process.Start(sInfo);
            }

            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void splash_Load(object sender, EventArgs e)
        {
            //timeLeft = 10;
            timer1.Start();

        }
    }
}
