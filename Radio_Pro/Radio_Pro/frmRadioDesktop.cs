using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
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
            var pullData = new frmFetchData();
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

        private void manageUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMangeUsers maguser = new frmMangeUsers();
            maguser.Show();
        }

        private void trackToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //ProcessStartInfo sInfo = new ProcessStartInfo("chrome.exe", "http://localhost/Test_Local_Server_Db/getelement.php");
            //Process.Start(sInfo);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            frmAssignData data = new frmAssignData();
            data.Show();
        }
    }
}
