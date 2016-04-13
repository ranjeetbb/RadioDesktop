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
    public partial class frmDirectAssign : Form
    {
        public frmDirectAssign()
        {
            InitializeComponent();
        }

        private void frmDirectAssign_Load(object sender, EventArgs e)
        {

        }

        private void btnAssignData_Click(object sender, EventArgs e)
        {
            using (frmFetchData form2 = new frmFetchData())
            {
                  string name=form2.TheValue.ToString();
                  MessageBox.Show(name);
                
            }
        }
    }
}
