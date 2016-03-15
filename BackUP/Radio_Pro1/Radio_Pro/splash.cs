using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
            }

            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void splash_Load(object sender, EventArgs e)
        {
            timeLeft = 10;
            timer1.Start();
        }
    }
}
