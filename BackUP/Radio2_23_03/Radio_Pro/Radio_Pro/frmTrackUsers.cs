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
namespace Radio_Pro
{
    public partial class frmTrackUsers : Form
    {
        public frmTrackUsers()
        {
            InitializeComponent();
        }
        Connection_SQL_MySql con_sql_mysql = new Connection_SQL_MySql();
        string[] years = new string[] { "2000", "2011", "2012", "2013", "2014", "2015", "2016", "2017", "2018", "2019", "3000", "3001", "3002" };
        string[] months = new string[] { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12" };
        string[] dates = new string[] { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31" };
        string deviceId;
        private void frmTrackUsers_Load(object sender, EventArgs e)
        {

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
            }
        }
        private void setDate()
        {
            for (int i = 0; i < months.Length; i++)
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
            }
        }

        private void btnTrackUsers_Click(object sender, EventArgs e)
        {
            if (cmbYear.Text == "" || cmbMonth.Text == "" || cmbDate.Text == "")
            {
                //lblMessages.ForeColor = System.Drawing.Color.Red;
                //lblMessages.Text = "Please Select start data ...";
                MessageBox.Show("Please Select start data !..");
            }
            else
             {
                  try
                   {

                   }
                    catch(Exception)
                   {

                    }
               }
        }

        private void cmbUserName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name;
            name = cmbUserName.SelectedItem.ToString();
            MessageBox.Show(name);
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
            MessageBox.Show(" Your Device "+deviceId);
        }
    }
}
