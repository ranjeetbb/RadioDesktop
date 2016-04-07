using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.IO;
using System.Diagnostics;
namespace Radio_Pro
{
    public partial class frmDoctorHistory : Form
    {
        Connection_SQL_MySql con_sql_mysql = new Connection_SQL_MySql();
        public frmDoctorHistory()
        {
            InitializeComponent();
        }
        string DrName = "";
        private void frmDoctorHistory_Load(object sender, EventArgs e)
        {
            label3.Text = "";
            label1.ForeColor = System.Drawing.Color.Red;
            this.MaximizeBox = false;
            //lstDisplay.Items.Clear();  
            string get_Myconn = con_sql_mysql.getConnectionMySql();
            MySqlConnection connect = new MySqlConnection(get_Myconn);
            MySqlCommand Mycmd = new MySqlCommand();//for selecting users 
            connect.Open();
            Mycmd = connect.CreateCommand();
            Mycmd.CommandText = "select radioDoctorId,radioName from doctors ";
            MySqlDataAdapter mySelectDctrName = new MySqlDataAdapter(Mycmd);
            DataTable mySelectDTDctrName = new DataTable();
            mySelectDctrName.Fill(mySelectDTDctrName);
            if (mySelectDTDctrName.Rows.Count > 0)
            {

                // MessageBox.Show("Users Found");
                foreach (DataRow row in mySelectDTDctrName.Rows)
                {
                    //MessageBox.Show("Users Found"+row[1].ToString());
                    cmbDoctorName.Items.Add(row[1].ToString());
                }
                cmbDoctorName.Sorted = true;
            }
        }

        private void btnTrackUsers_Click(object sender, EventArgs e)
        {
            string get_Myconn = con_sql_mysql.getConnectionMySql();
            MySqlConnection connect = new MySqlConnection(get_Myconn);
            MySqlCommand Mycmd = new MySqlCommand();//for selecting users 
            connect.Open();
            Mycmd = connect.CreateCommand();
            Mycmd.CommandText = "select a.DrName,a.DrResponse,a.ResponseDate from doctorhistory a where a.DrName='" + DrName + "' ";
            MySqlDataAdapter DADrHist = new MySqlDataAdapter(Mycmd);
            DataTable DTDrHist = new DataTable();
            DADrHist.Fill(DTDrHist);
            if (DTDrHist.Rows.Count > 0)
            {
                grdDisplayDoctorsHistory.Rows.Clear();
                grdDisplayDoctorsHistory.ColumnCount = 3;
                grdDisplayDoctorsHistory.Columns[0].Name = "Date";
                grdDisplayDoctorsHistory.Columns[1].Name = "Dr Name";
                grdDisplayDoctorsHistory.Columns[2].Name = "Status";
                grdDisplayDoctorsHistory.Columns[0].ReadOnly = true;
                grdDisplayDoctorsHistory.Columns[1].ReadOnly = true;
                grdDisplayDoctorsHistory.Columns[2].ReadOnly = true;
                grdDisplayDoctorsHistory.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                grdDisplayDoctorsHistory.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                grdDisplayDoctorsHistory.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                // MessageBox.Show("Users Found");
                string[] row1;
                foreach (DataRow row in DTDrHist.Rows)
                {
                    //DateTime.Now.ToString("yyyyMMdd-HHMMss");
                    string dateValue = Convert.ToDateTime(row[2]).ToString("dd-MM-yyyy HH:MM:ss").ToString();
                    //lstDisplay.Items.Clear();
                    //MessageBox.Show("Users Found"+row[1].ToString());
                    row1 = new string[] { dateValue, row[0].ToString(), row[1].ToString() };
                    grdDisplayDoctorsHistory.Rows.Add(row1);
                }
                grdDisplayDoctorsHistory.Sort(grdDisplayDoctorsHistory.Columns[0], ListSortDirection.Descending);


            }
            else 
            {
                grdDisplayDoctorsHistory.Rows.Clear();
                label3.ForeColor = System.Drawing.Color.Red;
                label3.Text = "No Any Response For this doctors.. !";
            }
        }

        private void cmbDoctorName_SelectedIndexChanged(object sender, EventArgs e)
        {
            DrName = cmbDoctorName.Text;
        }
    }
}
