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
        //for SQL connection
        string connectionString = "Data Source=RANJEETBB;Initial Catalog=radio;Integrated Security=True;";
        //for MySQL connection
        string MyConnectionString = "Server=localhost;Database=radio;Uid=root;Pwd=root;";
        public frmFetchData()
        {
            InitializeComponent();
        }

        Data_Encryption data_en = new Data_Encryption();
        Data_Decryptioncs data_decrypt = new Data_Decryptioncs();

        private void btnFetchData_Click(object sender, EventArgs e)
        {
            //Selecting Dept -->investigation from radio 
            SqlConnection sqlCon = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
           // cmd.CommandText = "select Dept_no,Investigation from Dept where Dept_No in(9,10)";
            cmd.CommandText = "select Dept_no,Investigation from Dept ";
            cmd.Connection = sqlCon;
            sqlCon.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            grdShowData.DataSource = dt;
            MySqlConnection connect = new MySqlConnection(MyConnectionString);
            String existValue = "";
            if (dt.Rows.Count > 0)
            {
                //MessageBox.Show("Found");
                 //Mysql database connection
                
                MySqlCommand Mycmd=new MySqlCommand();
                connect.Open();
                Mycmd = connect.CreateCommand();
               
                foreach (DataRow row in dt.Rows)
                {
                        existValue = data_en.Encrypt(row[0].ToString());
                        //MessageBox.Show(existValue);
                        Mycmd.CommandText = "select * from investigation where radioInvestigationId='"+existValue+"'";
                        MySqlDataAdapter myda = new MySqlDataAdapter(Mycmd);
                        DataTable mydt = new DataTable();
                        myda.Fill(mydt);
                        if (mydt.Rows.Count > 0)
                        {
                           // MessageBox.Show("M Found Update");
                            Mycmd.CommandText = "update investigation set radioInvestigationId ='" +data_en.Encrypt( row[1].ToString()) + "',radioInvestigationName='" + data_en.Encrypt(row[0].ToString()) + "' where investigationId ='" + row[0].ToString() + "'";
                            Mycmd.ExecuteNonQuery();
                        }
                        else
                        {
                           // MessageBox.Show("M No Found Insert");
                            Mycmd.CommandText = "INSERT INTO investigation(radioInvestigationId,radioInvestigationName) values('" +data_en.Encrypt( row[0].ToString()) + "','" +data_en.Encrypt( row[1].ToString()) + "')";
                            Mycmd.ExecuteNonQuery();
                        }
                }               
            }
            else
            {                
                MessageBox.Show("No New Investigation Found");
            }

            //Selecting Area from radio
            cmd.CommandText = "select * from tblAreaMaster";
            //cmd.CommandText = "select * from tblAreaMaster where id in(24,26)";
            //cmd.Connection = sqlCon;         
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            grdShowData.DataSource = dt;
            //MySqlConnection connect = new MySqlConnection(MyConnectionString);
            //String existValue = "";
            if (dt.Rows.Count > 0)
            {
                //MessageBox.Show("Found");
                //Mysql database connection

                MySqlCommand Mycmd = new MySqlCommand();
                //connect.Open();
                Mycmd = connect.CreateCommand();            
                foreach (DataRow row in dt.Rows)
                {
                    existValue = data_en.Encrypt(row[4].ToString());
                    //MessageBox.Show(existValue);
                    Mycmd.CommandText = "select * from MasterArea where radioAreaId='" + existValue + "'";
                    MySqlDataAdapter myda = new MySqlDataAdapter(Mycmd);
                    DataTable mydt = new DataTable();
                    myda.Fill(mydt);
                    if (mydt.Rows.Count > 0)
                    {
                       // MessageBox.Show("M Found Area Update");
                        Mycmd.CommandText = "update MasterArea set radioAreaId ='" + data_en.Encrypt(row[4].ToString()) + "',radioArea='" + data_en.Encrypt(row[0].ToString()) + "',radioSuburb='" + data_en.Encrypt(row[1].ToString()) + "',radioCity='" + data_en.Encrypt(row[2].ToString()) + "',radioPincode='" + data_en.Encrypt(row[3].ToString()) + "' where areaId ='" + row[0].ToString() + "'";
                        Mycmd.ExecuteNonQuery();
                    }
                    else
                    {
                        // MessageBox.Show("M No Found Area Insert");
                        Mycmd.CommandText = "INSERT INTO MasterArea(radioAreaId,radioArea,radioSuburb,radioCity,radioPincode) values('" + data_en.Encrypt(row[4].ToString()) + "','" + data_en.Encrypt(row[0].ToString()) + "','" + data_en.Encrypt(row[1].ToString()) + "','" + data_en.Encrypt(row[2].ToString()) + "','" + data_en.Encrypt(row[3].ToString()) + "')";
                        Mycmd.ExecuteNonQuery();                        
                    }
                }
            }
            else
            {
                MessageBox.Show("No New Area Found");
            }

            //Selecting tblPt_Details from radio for patients
            cmd.CommandText = "select Pt_regno,Pt_Name,Pt_Rep_Date,Pt_Sex,Pt_Age,Pt_Age_C,RefDr,invest from tblPt_Details where Pt_Rep_Date in('" + txtStartDate.Text.ToString() + "','" + txtEndDate.Text.ToString() + "')";
            //cmd.Connection = sqlCon;         
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            grdShowData.DataSource = dt;
            //MySqlConnection connect = new MySqlConnection(MyConnectionString);
            //String existValue = "";
            if (dt.Rows.Count > 0)
            {
                //MessageBox.Show("Found");
                //Mysql database connection
                MySqlCommand Mycmd = new MySqlCommand();
                //connect.Open();
                Mycmd = connect.CreateCommand();              
                foreach (DataRow row in dt.Rows)
                {
                    existValue = (row[0].ToString());
                    //existValue = (row[0].ToString());
                    //MessageBox.Show(existValue);
                    Mycmd.CommandText = "select * from patients where radioPatientsId='" + existValue + "'";
                    MySqlDataAdapter myda = new MySqlDataAdapter(Mycmd);
                    DataTable mydt = new DataTable();
                    myda.Fill(mydt);
                    if (mydt.Rows.Count > 0)
                    {
                        //MessageBox.Show("M Found patients Update");
                        //Mycmd.CommandText = "update MasterArea set radioAreaId ='" + data_en.Encrypt(row[4].ToString()) + "',radioArea='" + data_en.Encrypt(row[0].ToString()) + "',radioSuburb='" + data_en.Encrypt(row[1].ToString()) + "',radioCity='" + data_en.Encrypt(row[2].ToString()) + "',radioPincode='" + data_en.Encrypt(row[3].ToString()) + "' where areaId ='" + row[0].ToString() + "'";
                        Mycmd.CommandText = "update patients set radioPatientsId ='" + (row[0].ToString()) + "',radioPatientsName='" + (row[1].ToString()) + "',radioPatientRptDate='" + (row[2].ToString()) + "',radioSex='" + (row[3].ToString()) + "',radioAge='" + (row[4].ToString()) + "',radioAgeCategory='" + (row[5].ToString()) + "' where patientsId ='" + row[0].ToString() + "' ; update patients_investigation set patientsId='" + existValue + "',investigationId='" + row[7].ToString() + "' where patientsInvestigationId='" + existValue + "'";
                        Mycmd.ExecuteNonQuery();
                    }
                    else
                    {
                        //MessageBox.Show("M No Found patients Insert");
                        Mycmd.CommandText = "INSERT INTO patients(radioPatientsId,radioPatientsName,radioPatientRptDate,radioSex,radioAge,radioAgeCategory) values('" + (row[0].ToString()) + "','" + (row[1].ToString()) + "','" + (row[2].ToString()) + "','" + (row[3].ToString()) + "','" + (row[4].ToString()) + "','" + (row[5].ToString()) + "');insert into patients_investigation(patientsId,investigationId) values('"+existValue+"','"+row[7].ToString()+"')";
                        Mycmd.ExecuteNonQuery();
                    }

                    //Selecting for cut from radio for commision          
                    cmd.CommandText = "select Pt_RegNo,RefDr,Category,cut from RefDr r where Pt_RegNo='" + existValue + "'";
                    //cmd.Connection = sqlCon;         
                    da = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    da.Fill(dt);
                    grdShowData.DataSource = dt;
                    //MySqlConnection connect = new MySqlConnection(MyConnectionString);
                    //String existValue = "";
                    if (dt.Rows.Count > 0)
                    {
                        //MessageBox.Show("Found");
                        //Mysql database connection

                        Mycmd = new MySqlCommand();
                        //connect.Open();
                        Mycmd = connect.CreateCommand();
                        String ptId="", drId="", cut="";
                        foreach (DataRow row1 in dt.Rows)
                        {
                            ptId = (row1[0].ToString());
                            drId = (row1[1].ToString());
                            cut = (row1[3].ToString());
                            //MessageBox.Show(existValue);
                            Mycmd.CommandText = "select * from cut where radioPatientsId='" + ptId + "' and radioDoctorId='" + drId + "' and cut='" + cut + "'";
                            myda = new MySqlDataAdapter(Mycmd);
                            mydt = new DataTable();
                            myda.Fill(mydt);
                            if (mydt.Rows.Count > 0)
                            {
                                //MessageBox.Show("M Found  cut Update");
                                Mycmd.CommandText = "update cut set radioPatientsId ='" + (row1[0].ToString()) + "',radioDoctorId='" + (row1[1].ToString()) + "',radioCategory='" + (row1[2].ToString()) + "',cut='" + (row1[3].ToString()) + "' where cutid='" + row1[0].ToString() + "'";
                                Mycmd.ExecuteNonQuery();
                            }
                            else
                            {
                                //MessageBox.Show("M No Found cut Insert");
                                Mycmd.CommandText = "INSERT INTO cut(radioPatientsId,radioDoctorId,radioCategory,cut) values('" + (row1[0].ToString()) + "','" + (row1[1].ToString()) + "','" + (row1[2].ToString()) + "','" + (row1[3].ToString()) + "')";
                                Mycmd.ExecuteNonQuery();
                            }
                        }

                    }
                    //else   //cut else fart 
                  //  {
                       // MessageBox.Show(" No Found");
                   // }

                    //Selecting Addresses from radio fro doctor
                    cmd.CommandText = "select Title,Entry_No,FP,Address,PhRes,PhOff,Mobile,Fax,Category,id  from Addresses d,tblAreaMaster a where d.Area=a.Id and Entry_No='" + row[6].ToString() + "'";
                    //cmd.CommandText = "select Title,Entry_No,FP,Address,PhRes,PhOff,Mobile,Fax,Category,id  from Addresses d,tblAreaMaster a where d.Area=a.Id and Entry_No in(10)";
                    //cmd.Connection = sqlCon;         
                    da = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    da.Fill(dt);
                    grdShowData.DataSource = dt;
                    //MySqlConnection connect = new MySqlConnection(MyConnectionString);
                    //String existValue = "";
                    if (dt.Rows.Count > 0)
                    {
                        //MessageBox.Show("Found");
                        //Mysql database connection

                        Mycmd = new MySqlCommand();
                        //connect.Open();
                        Mycmd = connect.CreateCommand();
                        foreach (DataRow row1 in dt.Rows)
                        {
                            existValue = (row1[1].ToString());
                            string value = (row1[2].ToString()).Replace("'", "''");
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
                                Mycmd.CommandText = "update doctors set radioTitle ='" + (row1[0].ToString()) + "',radioDoctorId='" + (row1[1].ToString()) + "',radioName='" + value + "',radioAddress='" + (row1[3].ToString()) + "',radioPhoneRes='" +(row1[4].ToString()) + "',radioPhoneOffice='" + (row1[5].ToString()) + "',radioPhoneMobile='" + (row1[6].ToString()) + "',radioFax='" + (row1[7].ToString()) + "',radioCategory='" + (row1[8].ToString()) + "',areaId='" + (row1[9].ToString()) + "' where doctorId ='" + row[0].ToString() + "'";
                                Mycmd.ExecuteNonQuery();
                            }
                            else
                            {
                                //MessageBox.Show("M No Found doctors Insert");
                                Mycmd.CommandText = "INSERT INTO doctors(radioTitle,radioDoctorId,radioName,radioAddress,radioPhoneRes,radioPhoneOffice,radioPhoneMobile,radioFax,radioCategory,areaId,alternateMobile1,alternateMobile2) values('" + (row1[0].ToString()) + "','" + (row1[1].ToString()) + "','" + value + "','" + (row1[3].ToString()) + "','" + (row1[4].ToString()) + "','" + (row1[5].ToString()) + "','" + (row1[6].ToString()) + "','" + (row1[7].ToString()) + "','" + (row1[8].ToString()) + "','" + (row1[9].ToString()) + "','0000000000','0000000000')";
                                Mycmd.ExecuteNonQuery();

                            }
                        }

                    }
                   // else   //else part for doctors
                    //{

                      //  MessageBox.Show("No Dotor Found");

                   // }

                }
                MessageBox.Show(" Successful ");
            }
            else
            {
                MessageBox.Show("No Record Found for following date !");
            }
            
            //mysql conn close
            connect.Close();
            //sql conn close
            sqlCon.Close();          
            }
        }
    }

