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
    public partial class frmRadioDesktop : Form
    {
        public frmRadioDesktop()
        {
            InitializeComponent();
        }

        private void frmRadioDesktop_Load(object sender, EventArgs e)
        {
            
        }

        private void fetchRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var pullData = new Form1();
            pullData.Show();
        }

        private void frmRadioDesktop_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void manageDoctorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmUpdatedDoctorscs updr = new frmUpdatedDoctorscs();
            updr.Show();
        }
    }
}
