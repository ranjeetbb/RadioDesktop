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
    public partial class frmFetchData : Form
    {
        Connection_SQL_MySql con_sql_mysql = new Connection_SQL_MySql();
        public frmFetchData()
        {
            InitializeComponent();
        }

        Data_Encryption data_en = new Data_Encryption();
        Data_Decryptioncs data_decrypt = new Data_Decryptioncs();

        string[] years = new string[] { "2015", "2016", "2017" };
        string[] months = new string[] { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12" };
        string[] dates = new string[] { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31" };

        private void setMsg()
        {
            lblWaitMessage.Text = "Please wait while information is updating DO NOT CLICK AGAIN......";
        }
        private void btnFetchData_Click(object sender, EventArgs e)
        {
            lblWaitMessage.Text = "";         
            if (cmbYear.Text =="" || cmbMonth.Text =="" || cmdDate.Text =="")
            {
                lblMessages.ForeColor = System.Drawing.Color.Red;
                lblMessages.Text = "Please Select start data ...";
                //MessageBox.Show("Please Select start data !..");
            }
            else if (cmbYearEnd.Text == "" || cmbMonthEnd.Text == "" || cmbDateEnd.Text == "")
            {
                lblMessages.ForeColor = System.Drawing.Color.Red;
                lblMessages.Text = "Please Select end data ...";
                //MessageBox.Show("Please Select end data !..");
            }
            else
            {    
                int i=0;
                if (i == 0)
                {
                    lblWaitMessage.Text = "Please wait while information is updating DO NOT CLICK AGAIN......";
                }
                try
                {
                    
                    string startDate = cmbYear.Text + "-" + cmbMonth.Text + "-" + cmdDate.Text;
                    string endDate = cmbYearEnd.Text + "-" + cmbMonthEnd.Text + "-" + cmbDateEnd.Text;
                    MessageBox.Show("Please wait while date fetching do not click again ! ");
                    lblWaitMessage.ForeColor = System.Drawing.Color.Blue;               
                    //class to call investigation
                    lblMessages.ForeColor = System.Drawing.Color.Blue;
                    lblMessages.Text = "Investigation updating ...";
                    InvestigationInsert investInsert = new InvestigationInsert();
                    investInsert.investigationInsert();
                    lblMessages.ForeColor = System.Drawing.Color.Green;
                    lblMessages.Text = "Investigation update successfull ...";
                    //class to call area master
                    lblMessages.ForeColor = System.Drawing.Color.Blue;
                    lblMessages.Text = "Doctor Area updating ...";
                    AreaInsert areaInrt = new AreaInsert();
                    areaInrt.AreasInsert();
                    lblMessages.ForeColor = System.Drawing.Color.Green;
                    lblMessages.Text = "Doctors Area update successfull ...";

                    Connection_SQL_MySql con_sql_mysql = new Connection_SQL_MySql();   //class for connection
            
                    string get_conn = con_sql_mysql.getConnectionSql(); //getting sql connection
                    SqlConnection sqlCon = new SqlConnection(get_conn);
                    SqlCommand cmd = new SqlCommand();
                    //Selecting tblPt_Details from radio for patients
                    cmd.Connection = sqlCon;
                    sqlCon.Open();  
                    cmd.CommandText = "select Pt_regno,Pt_Name,Pt_Rep_Date,Pt_Sex,Pt_Age,Pt_Age_C,RefDr,invest from tblPt_Details where Pt_Rep_Date between '" + startDate + "' and '" + endDate + "'";                  
                    SqlDataAdapter da_pt = new SqlDataAdapter(cmd);
                    DataTable dt_pt = new DataTable();
                    da_pt.Fill(dt_pt);
                    string get_Myconn = con_sql_mysql.getConnectionMySql();
                    MySqlConnection connect = new MySqlConnection(get_Myconn);
                    String existValue = "";
                    if (dt_pt.Rows.Count > 0)
                    {
                        //MessageBox.Show("Found");
                        //Mysql database connection
                        string strgroupids = "";
                        MySqlCommand Mycmd = new MySqlCommand();
                        connect.Open();
                        Mycmd = connect.CreateCommand();
                        lblMessages.ForeColor = System.Drawing.Color.Blue;
                        lblMessages.Text = "Patient Infotmation updating ...";
                        foreach (DataRow row in dt_pt.Rows)
                        {
                            existValue = (row[0].ToString());
                            //existValue = (row[0].ToString());
                            //MessageBox.Show(existValue);
                            Mycmd.CommandText = "select * from patients where radioPatientsId='" + existValue + "'";
                            MySqlDataAdapter myda = new MySqlDataAdapter(Mycmd);
                            DataTable mydt = new DataTable();
                            myda.Fill(mydt);              
                            string dateValue = Convert.ToDateTime(row[2]).ToString("yyyy-MM-dd");                       
                            if (mydt.Rows.Count > 0)
                            {
                                //MessageBox.Show(dateValue);
                                //Mycmd.CommandText = "update MasterArea set radioAreaId ='" + data_en.Encrypt(row[4].ToString()) + "',radioArea='" + data_en.Encrypt(row[0].ToString()) + "',radioSuburb='" + data_en.Encrypt(row[1].ToString()) + "',radioCity='" + data_en.Encrypt(row[2].ToString()) + "',radioPincode='" + data_en.Encrypt(row[3].ToString()) + "' where areaId ='" + row[0].ToString() + "'";
                                Mycmd.CommandText = "update patients set radioPatientsId ='" + (row[0].ToString()) + "',radioPatientsName='" + (row[1].ToString()) + "',radioPatientRptDate='" + (dateValue) + "',radioSex='" + (row[3].ToString()) + "',radioAge='" + (row[4].ToString()) + "',radioAgeCategory='" + (row[5].ToString()) + "',radioInvestigation='" + (row[7].ToString()) + "' where radioPatientsId ='" + row[0].ToString() + "'";
                                Mycmd.ExecuteNonQuery();
                            }
                            else
                            {
                                //MessageBox.Show("M No Found patients Insert");
                                Mycmd.CommandText = "INSERT INTO patients(radioPatientsId,radioPatientsName,radioPatientRptDate,radioSex,radioAge,radioAgeCategory,radioInvestigation) values('" + (row[0].ToString()) + "','" + (row[1].ToString()) + "','" + (dateValue) + "','" + (row[3].ToString()) + "','" + (row[4].ToString()) + "','" + (row[5].ToString()) + "','" + (row[7].ToString()) + "')";
                                Mycmd.ExecuteNonQuery();
                            }
                            lblMessages.ForeColor = System.Drawing.Color.Green;
                            lblMessages.Text = "Patient Infotmation update successfull ...";
                            //Selecting for cut from radio for commision          
                            cmd.CommandText = "select Pt_RegNo,RefDr,Category,cut from RefDr where Pt_RegNo='" + existValue + "'";
                            //cmd.Connection = sqlCon;         
                            SqlDataAdapter da_cut = new SqlDataAdapter(cmd);
                            DataTable dt_cut = new DataTable();
                            da_cut.Fill(dt_cut);
                            //grdShowData.DataSource = dt;
                            //MySqlConnection connect = new MySqlConnection(MyConnectionString);
                            //String existValue = "";
                            if (dt_cut.Rows.Count > 0)
                            {
                                //MessageBox.Show("Found");
                                //Mysql database connection
                                lblMessages.ForeColor = System.Drawing.Color.Blue;
                                lblMessages.Text = "Cut updating ...";
                                Mycmd = new MySqlCommand();
                                //connect.Open();
                                Mycmd = connect.CreateCommand();
                                String ptId = "", drId = "", cut = "";
                                foreach (DataRow row1 in dt_cut.Rows)
                                {
                                    ptId = (row1[0].ToString());
                                    drId = (row1[1].ToString());
                                    cut = (row1[3].ToString());
                                    //MessageBox.Show(existValue);
                                    Mycmd.CommandText = "select * from cut where radioPatientsId='" + ptId + "' and radioDoctorId='" + drId + "' and cut='" + cut + "'";
                                    MySqlDataAdapter myda_cut = new MySqlDataAdapter(Mycmd);
                                    DataTable mydt_cut = new DataTable();
                                    myda_cut.Fill(mydt_cut);
                                    if (mydt_cut.Rows.Count > 0)
                                    {
                                        //MessageBox.Show("M Found  cut Update");
                                        Mycmd.CommandText = "update cut set radioPatientsId ='" + (row1[0].ToString()) + "',radioDoctorId='" + (row1[1].ToString()) + "',radioCategory='" + (row1[2].ToString()) + "',cut='" + (row1[3].ToString()) + "' where radioPatientsId='" + ptId + "' and radioDoctorId='" + drId + "' and cut='" + cut + "'";
                                        Mycmd.ExecuteNonQuery();
                                    }
                                    else
                                    {
                                        //MessageBox.Show("M No Found cut Insert");
                                        Mycmd.CommandText = "INSERT INTO cut(radioPatientsId,radioDoctorId,radioCategory,cut) values('" + (row1[0].ToString()) + "','" + (row1[1].ToString()) + "','" + (row1[2].ToString()) + "','" + (row1[3].ToString()) + "')";
                                        Mycmd.ExecuteNonQuery();
                                    }
                                    
                                }
                                lblMessages.ForeColor = System.Drawing.Color.Green;
                                lblMessages.Text = "Cut Infotmation update successfull ...";
                            }
                            //else   //cut else fart 
                            //  {
                            // MessageBox.Show(" No Found");
                            // }
                            string getEntry_no = row[6].ToString();
                            //string Entry_no = "'" + getEntry_no + "'";      
                            //MessageBox.Show(""+No);
                            //Selecting Addresses from radio fro doctor
                            cmd.CommandText = "select Title,Entry_No,FP,Address,PhRes,PhOff,Mobile,Fax,Category,id  from Addresses d,tblAreaMaster a where d.Area=a.Id and cast(Entry_No as varchar)=cast('" + row[6].ToString() + "' as varchar)";
                            //cmd.CommandText = "select Title,Entry_No,FP,Address,PhRes,PhOff,Mobile,Fax,Category,id  from Addresses d,tblAreaMaster a where d.Area=a.Id and Entry_No in(10)";
                            //cmd.Connection = sqlCon;         
                            SqlDataAdapter da_doctr = new SqlDataAdapter(cmd);
                            DataTable dt_doctr = new DataTable();
                            da_doctr.Fill(dt_doctr);
                            //grdShowData.DataSource = dt;
                            //MySqlConnection connect = new MySqlConnection(MyConnectionString);
                            //String existValue = "";
                            if (dt_doctr.Rows.Count > 0)
                            {
                                //MessageBox.Show("Found");
                                //Mysql database connection
                                lblMessages.ForeColor = System.Drawing.Color.Blue;
                                lblMessages.Text = "Doctors Infotmation updating ...";
                                Mycmd = new MySqlCommand();
                                //connect.Open();
                                Mycmd = connect.CreateCommand();
                                foreach (DataRow row1 in dt_doctr.Rows)
                                {
                                    existValue = (row1[1].ToString());
                                    string DrName = (row1[2].ToString()).Replace("'", "''");
                                    string DrAddress = (row1[3].ToString()).Replace("'", "''");
                                    //existValue = (row[1].ToString());
                                    //MessageBox.Show("Dr Id"+existValue);
                                    Mycmd.CommandText = "select * from doctors where radioDoctorId='" + existValue + "'";
                                    myda = new MySqlDataAdapter(Mycmd);
                                    mydt = new DataTable();
                                    myda.Fill(mydt);
                                    if (mydt.Rows.Count > 0)
                                    {
                                        //MessageBox.Show("M Found doctors Update");
                                        //Mycmd.CommandText = "update MasterArea set radioAreaId ='" + data_en.Encrypt(row[4].ToString()) + "',radioArea='" + data_en.Encrypt(row[0].ToString()) + "',radioSuburb='" + data_en.Encrypt(row[1].ToString()) + "',radioCity='" + data_en.Encrypt(row[2].ToString()) + "',radioPincode='" + data_en.Encrypt(row[3].ToString()) + "' where areaId ='" + row[0].ToString() + "'";
                                        Mycmd.CommandText = "update doctors set radioTitle ='" + (row1[0].ToString()) + "',radioDoctorId='" + (row1[1].ToString()) + "',radioName='" + DrName + "',radioAddress='" + DrAddress + "',radioPhoneRes='" + (row1[4].ToString()) + "',radioPhoneOffice='" + (row1[5].ToString()) + "',radioPhoneMobile='" + (row1[6].ToString()) + "',radioFax='" + (row1[7].ToString()) + "',radioCategory='" + (row1[8].ToString()) + "',areaId='" + (row1[9].ToString()) + "' where radioDoctorId ='" + row[0].ToString() + "'";
                                        Mycmd.ExecuteNonQuery();
                                    }
                                    else
                                    {
                                        //MessageBox.Show("M No Found doctors Insert");
                                        Mycmd.CommandText = "INSERT INTO doctors(radioTitle,radioDoctorId,radioName,radioAddress,radioPhoneRes,radioPhoneOffice,radioPhoneMobile,radioFax,radioCategory,areaId,alternateMobile1,alternateMobile2) values('" + (row1[0].ToString()) + "','" + (row1[1].ToString()) + "','" + DrName + "','" + DrAddress + "','" + (row1[4].ToString()) + "','" + (row1[5].ToString()) + "','" + (row1[6].ToString()) + "','" + (row1[7].ToString()) + "','" + (row1[8].ToString()) + "','" + (row1[9].ToString()) + "','','')";
                                        Mycmd.ExecuteNonQuery();

                                    }
                                    
                                }
                                lblMessages.ForeColor = System.Drawing.Color.Green;
                                lblMessages.Text = "Doctors Infotmation update successfull ...";
                            }
                            // else   //else part for doctors
                            //{

                            //  MessageBox.Show("No Dotor Found");

                            // }

                        }
                        MessageBox.Show("Successful ");
                        lblMessages.Text = "";
                        lblWaitMessage.ForeColor = System.Drawing.Color.Green;
                        lblWaitMessage.Text = "Completed Successfully ...";
                        btnViewData.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("No Record Found for following date !");
                        lblMessages.Text = "";
                        lblWaitMessage.Text = "";
                    }

                    //mysql conn close
                    connect.Close();
                    //sql conn close
                    sqlCon.Close();

                }
                catch (Exception)
                { 
                
                }
            }

        }       
        private void frmFetchData_Load(object sender, EventArgs e)
        {
            //this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.MaximizeBox = false;
            label13.ForeColor = System.Drawing.Color.Red;
            label9.ForeColor = System.Drawing.Color.Red;      
            lblTotalRows.Visible = false;
            btnViewData.Visible = false;
            lblMessages.Text = "";
            lblWaitMessage.Text = "";
            for (int i = 0; i < months.Length; i++)
            {
                cmbMonth.Items.Add(months[i]);
                cmbMonthEnd.Items.Add(months[i]);
            }

            for (int i = 0; i < dates.Length; i++)
            {
                cmdDate.Items.Add(dates[i]);
                cmbDateEnd.Items.Add(dates[i]);
            }

            for (int i = 0; i < years.Length; i++)
            {
                cmbYear.Items.Add(years[i]);
                cmbYearEnd.Items.Add(years[i]);
            }
           
        }

        private void btnViewData_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            viewFetchData();

        }
        private void viewFetchData()
        {
                       string startDate = cmbYear.Text + "-" + cmbMonth.Text + "-" + cmdDate.Text;
                       string endDate = cmbYearEnd.Text + "-" + cmbMonthEnd.Text + "-" + cmbDateEnd.Text;
                       string get_Myconn = con_sql_mysql.getConnectionMySql();
                       MySqlConnection connect = new MySqlConnection(get_Myconn);
                       MySqlCommand Mycmd = new MySqlCommand();//for selecting users 
                       connect.Open();
                       Mycmd = connect.CreateCommand();
                       Mycmd.CommandText = "select * from vwPatientWithDoctorsCut_CSV where radioPatientRptDate between'" + startDate + "'and'" + endDate + "'";

                       MySqlDataAdapter viewDA = new MySqlDataAdapter(Mycmd);
                       DataTable ViewDT = new DataTable();
                       viewDA.Fill(ViewDT);
                       int talRows = ViewDT.Rows.Count;
                       //grdViewFetchData.DataSource = ViewDT;
                       if (ViewDT.Rows.Count > 0)
                       {
                           grdViewFetchData.ColumnCount = 7;
                           grdViewFetchData.Columns[0].Name = "Date";
                           grdViewFetchData.Columns[1].Name = "Patients Name";
                           grdViewFetchData.Columns[2].Name = "Pt ID";
                           grdViewFetchData.Columns[3].Name = "Dr ID";
                           grdViewFetchData.Columns[4].Name = "Dr Name";
                           grdViewFetchData.Columns[5].Name = "IP";
                           grdViewFetchData.Columns[6].Name = "Investigation";

                           grdViewFetchData.Columns[0].ReadOnly = true;
                           grdViewFetchData.Columns[1].ReadOnly = true;
                           grdViewFetchData.Columns[2].ReadOnly = true;
                           grdViewFetchData.Columns[3].ReadOnly = true;
                           grdViewFetchData.Columns[4].ReadOnly = true;
                           grdViewFetchData.Columns[5].ReadOnly = true;
                           grdViewFetchData.Columns[6].ReadOnly = true;

                           grdViewFetchData.Columns[2].Visible = false;
                           grdViewFetchData.Columns[3].Visible = false;
                           string[] row;
                           foreach (DataRow value in ViewDT.Rows)
                           {
                               Data_Decryptioncs data_decrypt = new Data_Decryptioncs();
                               //row = new string[] { data_decrypt.Decrypt(value[0].ToString()) };
                               // MessageBox.Show(value[0].ToString());                        
                               //row = new string[] { value[0].ToString(),data_decrypt.Decrypt(value[1].ToString()), data_decrypt.Decrypt(value[2].ToString()), data_decrypt.Decrypt(value[3].ToString()), data_decrypt.Decrypt(value[4].ToString()), data_decrypt.Decrypt(value[5].ToString()), data_decrypt.Decrypt(value[6].ToString()), data_decrypt.Decrypt(value[7].ToString()), data_decrypt.Decrypt(value[8].ToString()) };
                               row = new string[] { value[0].ToString(), (value[1].ToString()), (value[2].ToString()), (value[3].ToString()), (value[4].ToString()), (value[5].ToString()), (value[6].ToString()) };
                               /*row = new string[] { data_decrypt.Decrypt(value[0].ToString()), data_decrypt.Decrypt(value[1].ToString()), data_decrypt.Decrypt(value[2].ToString()), data_decrypt.Decrypt(value[3].ToString()), data_decrypt.Decrypt(value[4].ToString())
                                   , data_decrypt.Decrypt(value[5].ToString()), data_decrypt.Decrypt(value[6].ToString()), data_decrypt.Decrypt(value[7].ToString()) };*/
                               grdViewFetchData.Rows.Add(row);

                           }

                           lblTotalRows.Visible = true;
                           lblTotalRows.Text = "Total Rows count : "+talRows.ToString();
                           btnViewData.Enabled = false;

                       }

        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            frmAssignData go_ass = new frmAssignData();
            this.Hide();
            go_ass.Show();
        }

       
      }
 }

