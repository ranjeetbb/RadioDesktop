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
    public partial class frmAssignData : Form
    {      
        //for connection
        Connection_SQL_MySql con_sql_mysql = new Connection_SQL_MySql();
        public frmAssignData()
        {
            InitializeComponent();         
        }
        Data_Encryption data_en = new Data_Encryption();
        Data_Decryptioncs data_decrypt = new Data_Decryptioncs();

        MySqlCommand Mycmd;
        MySqlDataAdapter myda,mySelectDA;
        DataTable mydt,mySelectDT;

       
       
        private void frmAssignData_Load(object sender, EventArgs e)
        {            
            //MessageBox.Show("Users Found");
            cmbDeviceId.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSelectArea.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSelectDoctors.DropDownStyle = ComboBoxStyle.DropDownList;
            //cmbAreaIDHidden.Visible = false;
            string get_Myconn = con_sql_mysql.getConnectionMySql();
            MySqlConnection connect = new MySqlConnection(get_Myconn);           
            Mycmd = new MySqlCommand();//for selecting users 
            connect.Open();
            Mycmd = connect.CreateCommand();
            Mycmd.CommandText = "select userName from users";
            MySqlDataAdapter myda = new MySqlDataAdapter(Mycmd);
            DataTable mydt = new DataTable();
            myda.Fill(mydt);
            //grdShowData.DataSource = mydt;            
            if (mydt.Rows.Count > 0)
            {
               // MessageBox.Show("Users Found");
                foreach (DataRow row in mydt.Rows)
                {
                    //MessageBox.Show("Users Found"+row[1].ToString());
                    cmbDeviceId.Items.Add(row[0].ToString());
                }
            
            }
            Mycmd = new MySqlCommand();      //for selecting areas    
            Mycmd = connect.CreateCommand();
            Mycmd.CommandText = "select radioArea from MasterArea";
            myda = new MySqlDataAdapter(Mycmd);
            mydt = new DataTable();
            myda.Fill(mydt);
            //grdShowData.DataSource = mydt;            
            if (mydt.Rows.Count > 0)
            {
                // MessageBox.Show("Users Found");
                foreach (DataRow row in mydt.Rows)
                {
                    //MessageBox.Show("Users Found"+row[1].ToString());
                    cmbSelectArea.Items.Add(data_decrypt.Decrypt(row[0].ToString()));                  
                }

            }
            connect.Close();
        }

        private void cmbSelectArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            string areaName= cmbSelectArea.SelectedItem.ToString();
            //MessageBox.Show(areaName);
            string get_Myconn = con_sql_mysql.getConnectionMySql();
            MySqlConnection connect = new MySqlConnection(get_Myconn);
            Mycmd = new MySqlCommand();//for selecting area ID 
            connect.Open();
            Mycmd = connect.CreateCommand();
            Mycmd.CommandText = "select radioAreaId from MasterArea where radioArea='" + data_en.Encrypt(areaName) + "'";
            myda = new MySqlDataAdapter(Mycmd);
            mydt = new DataTable();
            myda.Fill(mydt);
            //grdShowData.DataSource = mydt;   
            if (mydt.Rows.Count > 0)
            {

                //MessageBox.Show("Users Found");
                foreach (DataRow row in mydt.Rows)
                {
                    //MessageBox.Show("Users Found "+data_decrypt.Decrypt(row[0].ToString())); 
                    //MessageBox.Show("" + data_decrypt.Decrypt(row[0].ToString()));
                    string areaId = data_decrypt.Decrypt(row[0].ToString());
                    Mycmd = new MySqlCommand();//for selecting doctors accourding to area                   
                    Mycmd = connect.CreateCommand();
                    Mycmd.CommandText = "select radioName from doctors where areaId='" + areaId + "'";
                    myda = new MySqlDataAdapter(Mycmd);
                    mydt = new DataTable();
                    myda.Fill(mydt);
                    //grdShowData.DataSource = mydt;   
                    if (mydt.Rows.Count > 0)
                    {
                        cmbSelectDoctors.Text="";
                        cmbSelectDoctors.Items.Clear();
                        //MessageBox.Show("Users Found");
                        foreach (DataRow row1 in mydt.Rows)
                        {
                            //MessageBox.Show("Doctors Found"+row1[0].ToString()); 
                            //MessageBox.Show("" + data_decrypt.Decrypt(row[0].ToString()));
                           
                            cmbSelectDoctors.Items.Add(row1[0].ToString());
                        }

                    }
                    else 
                    {
                        cmbSelectDoctors.Text = "";
                        cmbSelectDoctors.Items.Clear();
                        cmbSelectDoctors.Items.Add("No Doctors Exist");
                    }
                }

            }
            connect.Close();
        }

        private void btnFetchData_Click_1(object sender, EventArgs e)
        {
            string get_Myconn = con_sql_mysql.getConnectionMySql();
            MySqlConnection connect = new MySqlConnection(get_Myconn);
            Mycmd = new MySqlCommand();//for selecting users 
            connect.Open();
            Mycmd = connect.CreateCommand();
            Mycmd.CommandText = "select * from vwPatientWithDoctorsCut where radioPatientRptDate in('" + txtStartDate.Text + "','" + txtEndDate.Text +"')";
            mySelectDA = new MySqlDataAdapter(Mycmd);
            mySelectDT= new DataTable();
            mySelectDA.Fill(mySelectDT);
            if (mySelectDT.Rows.Count > 0)
            {
                grdShowData.DataSource = mySelectDT; 
                // MessageBox.Show("Users Found");
               /* foreach (DataRow row in mydt.Rows)
                {
                    //MessageBox.Show("Users Found"+row[1].ToString());
                    cmbDeviceId.Items.Add(row[0].ToString());
                }*/

            }
            else
            {
                MessageBox.Show("No Record Found for following date !");
            }
            connect.Close();
        }
        private void btnFetchData_Click(object sender, EventArgs e)
        {
            string userName = cmbDeviceId.Text;
            //MessageBox.Show(userName);
            /*string get_Myconn = con_sql_mysql.getConnectionMySql();
            MySqlConnection connect = new MySqlConnection(get_Myconn);
            Mycmd = new MySqlCommand();
            connect.Open();
            Mycmd = connect.CreateCommand();
            Mycmd.CommandText = "select * from patients where radioPatientRptDate in ('" + txtStartDate.Text + "','" + txtEndDate.Text + "')";
            myda = new MySqlDataAdapter(Mycmd);
            mydt = new DataTable();
            myda.Fill(mydt);
            grdShowData.DataSource = mydt;*/
            var csv = new StringBuilder(); //reading file
            if (mySelectDT.Rows.Count > 0)
            {
                // MessageBox.Show("Users Found");
                foreach (DataRow row in mySelectDT.Rows)
                {
                    //in your loop
                    var radioPatientRptDate = row[0].ToString();
                    var radioPatientsName = row[1].ToString();
                    var radioPatientsId = row[2].ToString();
                    var radioDoctorId = row[3].ToString();
                    var radioName = row[4].ToString();
                    var cut = row[5].ToString();               
                    //var second = image.ToString();
                    //Suggestion made by KyleMit
                    //var newLine = string.Format("{0},{1}", first, second);
                    var newLine = string.Format("{0},{1},{2},{3},{4},{5}", radioPatientRptDate, radioPatientsName, radioPatientsId, radioDoctorId, radioName, cut);
                    csv.AppendLine(newLine);
                    //after your loop                  
                }
                if (userName != "")
                {
                    File.WriteAllText(@"D:\Radio\" + userName + ".csv", csv.ToString());
                    MessageBox.Show("Send successfully !");
                }
                else
                {
                    MessageBox.Show("Select User !");
                }

            }
            else
            {
                MessageBox.Show("No Record Found for following date !");
            }
          

        }
    }
}
