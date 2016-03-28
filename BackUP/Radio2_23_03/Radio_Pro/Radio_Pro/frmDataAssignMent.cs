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
    public partial class frmDataAssignMent : Form
    {
        //for connection
        Connection_SQL_MySql con_sql_mysql = new Connection_SQL_MySql();
        public frmDataAssignMent()
        {
            InitializeComponent();
        }
        Data_Encryption data_en = new Data_Encryption();
        Data_Decryptioncs data_decrypt = new Data_Decryptioncs();

        MySqlCommand Mycmd;
        MySqlDataAdapter myda, mySelectDA;
        DataTable mydt, mySelectDT;

        string userName = "";//for user name to set particular user 
        string deviceId = "";//for device id to set particular user 

        string[] years = new string[] { "2000", "2011", "2012", "2013", "2014", "2015", "2016", "2017", "2018", "2019", "3000", "3001", "3002" };
        string[] months = new string[] { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12" };
        string[] dates = new string[] { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31" };

        private void checkAssign()
        {

            string get_Myconn = con_sql_mysql.getConnectionMySql();
            MySqlConnection connect = new MySqlConnection(get_Myconn);
            Mycmd = new MySqlCommand();//for selecting users 
            connect.Open();
            Mycmd = connect.CreateCommand();
            Mycmd.CommandText = "select * from vwPatientWithDoctorsCut_CSV where ass_status=0";

            MySqlDataAdapter assingDA = new MySqlDataAdapter(Mycmd);
            DataTable assignDT = new DataTable();
            assingDA.Fill(assignDT);
            //MessageBox.Show(""+assignDT.Rows.Count);
            if (assignDT.Rows.Count > 0)
            {
                // grdShowData.DataSource = mySelectDT;
                grdAssignStatus.ColumnCount = 8;
                grdAssignStatus.Columns[0].Name = "Date";
                grdAssignStatus.Columns[1].Name = "Patients Name";
                grdAssignStatus.Columns[2].Name = "Pt ID";
                grdAssignStatus.Columns[3].Name = "Dr ID";
                grdAssignStatus.Columns[4].Name = "Dr Name";
                grdAssignStatus.Columns[5].Name = "IP";
                grdAssignStatus.Columns[6].Name = "Investigation";
                grdAssignStatus.Columns[7].Name = "Assign";

                grdAssignStatus.Columns[0].ReadOnly = true;
                grdAssignStatus.Columns[1].ReadOnly = true;
                grdAssignStatus.Columns[2].ReadOnly = true;
                grdAssignStatus.Columns[3].ReadOnly = true;
                grdAssignStatus.Columns[4].ReadOnly = true;
                grdAssignStatus.Columns[5].ReadOnly = true;
                grdAssignStatus.Columns[6].ReadOnly = true;
                grdAssignStatus.Columns[7].ReadOnly = true;
                grdAssignStatus.Columns[2].Visible = false;
                grdAssignStatus.Columns[3].Visible = false;

                grdAssignStatus.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                grdAssignStatus.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                // grdAssignStatus.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                string[] row;
                foreach (DataRow value in assignDT.Rows)
                {
                    Data_Decryptioncs data_decrypt = new Data_Decryptioncs();
                    string dateValue = Convert.ToDateTime(value[0]).ToString("dd-MM-yyyy");
                    //row = new string[] { data_decrypt.Decrypt(value[0].ToString()) };
                    // MessageBox.Show(value[0].ToString());                        
                    //row = new string[] { value[0].ToString(),data_decrypt.Decrypt(value[1].ToString()), data_decrypt.Decrypt(value[2].ToString()), data_decrypt.Decrypt(value[3].ToString()), data_decrypt.Decrypt(value[4].ToString()), data_decrypt.Decrypt(value[5].ToString()), data_decrypt.Decrypt(value[6].ToString()), data_decrypt.Decrypt(value[7].ToString()), data_decrypt.Decrypt(value[8].ToString()) };
                    row = new string[] { dateValue, (value[1].ToString()), (value[2].ToString()), (value[3].ToString()), (value[4].ToString()), (value[5].ToString()), (value[6].ToString()), (value[7].ToString()) };
                    /*row = new string[] { data_decrypt.Decrypt(value[0].ToString()), data_decrypt.Decrypt(value[1].ToString()), data_decrypt.Decrypt(value[2].ToString()), data_decrypt.Decrypt(value[3].ToString()), data_decrypt.Decrypt(value[4].ToString())
                        , data_decrypt.Decrypt(value[5].ToString()), data_decrypt.Decrypt(value[6].ToString()), data_decrypt.Decrypt(value[7].ToString()) };*/
                    grdAssignStatus.Rows.Add(row);

                }
            }

        }
        private void frmDataAssignMent_Load(object sender, EventArgs e)
        {

        }
    }
}
