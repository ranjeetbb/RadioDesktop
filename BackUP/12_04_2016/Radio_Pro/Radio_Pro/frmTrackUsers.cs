using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.IO;
using System.Diagnostics;
namespace Radio_Pro
{
    public partial class frmTrackUsers : Form
    {
        public frmTrackUsers()
        {
            InitializeComponent();
        }
        Connection_SQL_MySql con_sql_mysql = new Connection_SQL_MySql();
        /*string[] years = new string[] { "2000", "2011", "2012", "2013", "2014", "2015", "2016", "2017", "2018", "2019", "3000", "3001", "3002" };
        string[] months = new string[] { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12" };
        string[] dates = new string[] { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31" };
        */
        int i;
        string deviceId;
        private void frmTrackUsers_Load(object sender, EventArgs e)
        {
            label1.ForeColor = System.Drawing.Color.Red;
            this.MaximizeBox = false;
            //lstDisplay.Items.Clear();
            setDate();
            string get_Myconn = con_sql_mysql.getConnectionMySql();
            MySqlConnection connect = new MySqlConnection(get_Myconn);
            MySqlCommand Mycmd = new MySqlCommand();//for selecting users 
            connect.Open();
            Mycmd = connect.CreateCommand();
            Mycmd.CommandText = "select userName from users ";
            MySqlDataAdapter mySelectUserName = new MySqlDataAdapter(Mycmd);
            DataTable mySelectDTUserName = new DataTable();
            mySelectUserName.Fill(mySelectDTUserName);
            if (mySelectDTUserName.Rows.Count > 0)
            {

                // MessageBox.Show("Users Found");
                foreach (DataRow row in mySelectDTUserName.Rows)
                {
                    //MessageBox.Show("Users Found"+row[1].ToString());
                    cmbUserName.Items.Add(row[0].ToString());
                }
                cmbUserName.Sorted = true;
            }
        }
        private void setDate()
        {
            /*for (int i = 0; i < months.Length; i++)
            {
                cmbMonth.Items.Add(months[i]);
                cmbMonth.Items.Add(months[i]);
            }

            for (int i = 0; i < dates.Length; i++)
            {
                cmbDate.Items.Add(dates[i]);
                cmbDate.Items.Add(dates[i]);
            }

            for (int i = 0; i < years.Length; i++)
            {
                cmbYear.Items.Add(years[i]);
                cmbYear.Items.Add(years[i]);
            }*/
        }

        private void btnTrackUsers_Click(object sender, EventArgs e)
        {
           
        }

        private void cmbUserName_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cmbUserName_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string name;
            name = cmbUserName.SelectedItem.ToString();
            //MessageBox.Show(name);
            string get_Myconn = con_sql_mysql.getConnectionMySql();
            MySqlConnection connect = new MySqlConnection(get_Myconn);
            MySqlCommand Mycmd = new MySqlCommand();//for selecting users 
            connect.Open();
            Mycmd = connect.CreateCommand();
            Mycmd.CommandText = "select deviceId from users where userName='" + name + "'";
            MySqlDataAdapter mySelectUserName = new MySqlDataAdapter(Mycmd);
            DataTable mySelectDTUserName = new DataTable();
            mySelectUserName.Fill(mySelectDTUserName);
            if (mySelectDTUserName.Rows.Count > 0)
            {

                // MessageBox.Show("Users Found");
                foreach (DataRow row in mySelectDTUserName.Rows)
                {
                    //MessageBox.Show("Users Found"+row[1].ToString());
                    deviceId = row[0].ToString();
                }
            }
            //MessageBox.Show(" Your Device " + deviceId);
        }

        private void btnTrackUsers_Click_1(object sender, EventArgs e)
        {
            string get_Myconn = con_sql_mysql.getConnectionMySql();
            MySqlConnection connect = new MySqlConnection(get_Myconn);
            MySqlCommand Mycmd = new MySqlCommand();//for selecting users 
            connect.Open();
            Mycmd = connect.CreateCommand();
            Mycmd.CommandText = "select a.deviceId,b.latitude,b.longitude,b.createdOn from users a,serverlocation b where a.deviceId=b.deviceId and  b.deviceId='" + deviceId + "' order by b.createdOn DESC ";
            MySqlDataAdapter transDA = new MySqlDataAdapter(Mycmd);
            DataTable transDT = new DataTable();
            transDA.Fill(transDT);
            if (transDT.Rows.Count > 0)
            {
                grdDisplayLocation.Rows.Clear();
                grdDisplayLocation.ColumnCount = 4;
                grdDisplayLocation.Columns[0].Name = "Date";
                grdDisplayLocation.Columns[1].Name = "Latitude";
                grdDisplayLocation.Columns[2].Name = "Longitude";           
                grdDisplayLocation.Columns[3].Name = "Link";
                grdDisplayLocation.Columns[0].ReadOnly = true;
                grdDisplayLocation.Columns[1].ReadOnly = true;
                grdDisplayLocation.Columns[2].ReadOnly = true;
                grdDisplayLocation.Columns[3].ReadOnly = true;
                grdDisplayLocation.Columns[2].Visible = false;
                grdDisplayLocation.Columns[1].Visible = false;
                grdDisplayLocation.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                grdDisplayLocation.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                grdDisplayLocation.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                grdDisplayLocation.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                // MessageBox.Show("Users Found");
                string[] row1;
                foreach (DataRow row in transDT.Rows)
                {
                     //DateTime.Now.ToString("yyyyMMdd-HHMMss");
                    string dateValue = Convert.ToDateTime(row[3]).ToString("dd-MM-yyyy HH:MM:ss").ToString();  
                    //lstDisplay.Items.Clear();
                    //MessageBox.Show("Users Found"+row[1].ToString());
                    row1 = new string[] { dateValue, row[1].ToString(), row[2].ToString(), "Go to Location" };
                    grdDisplayLocation.Rows.Add(row1);
                }
                 grdDisplayLocation.Sort(grdDisplayLocation.Columns[2], ListSortDirection.Descending);

                
            }
            
        }
        private void lnk_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ok");
        }
        private void btnSeeLocation_Click(object sender, EventArgs e)
        {
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
        }

        private void grdDisplayLocation_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            i = grdDisplayLocation.CurrentCell.RowIndex;           
            DataGridViewRow row = grdDisplayLocation.Rows[i];
            string latitude = (row.Cells[1].Value ?? string.Empty).ToString();
            string longitude = (row.Cells[2].Value ?? string.Empty).ToString();
            //MessageBox.Show("Lat " + latitude +" Log "+longitude);
            ProcessStartInfo sInfo = new ProcessStartInfo("chrome.exe", "www.google.com/maps?q="+latitude+","+longitude+"");
            Process.Start(sInfo);
        }
    }
}
