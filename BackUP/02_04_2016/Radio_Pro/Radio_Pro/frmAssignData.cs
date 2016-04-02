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
        MySqlDataAdapter myda, mySelectDA;
        DataTable mydt,mySelectDT;

        string userName = "";//for user name to set particular user 
        string deviceId = "";//for device id to set particular user 
        string doctname = "";//
        string Areaid = "";//for area 
        string selectType = "";//for selection type
        string doctId = "";
        string[] years = new string[] { "2015", "2016", "2017" };
        string[] months = new string[] {"01","02","03","04","05","06","07","08","09","10","11","12" };
        string[] dates = new string[] { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"};

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
                           grdAssignStatus.Sort(grdAssignStatus.Columns[0], ListSortDirection.Descending);
                       }
        
        }
        private void frmAssignData_Load(object sender, EventArgs e)
        {
            label15.ForeColor = System.Drawing.Color.Red;
            label13.ForeColor = System.Drawing.Color.Red;
            label14.ForeColor = System.Drawing.Color.Red;        
            //adding items to cmbselection type 
            cmbSelectType.Items.Add("Date wise");
            cmbSelectType.Items.Add("Date-Area wise");
            cmbSelectType.Items.Add("Date-Area wiht Doctor wise");
            //cmbSelectType.Items.Add("Combination");

            grdCVSFile.Visible = false;
            grdShowData.Visible = false;
            checkAssign(); //call to vwPatientWithDoctorsCut_CSV for data
            getArea(); //call area
            lblMessages.Text = "";
            //MessageBox.Show("Users Found");    
            //cmbAreaIDHidden.Visible = false;
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
            string get_Myconn = con_sql_mysql.getConnectionMySql();
            MySqlConnection connect = new MySqlConnection(get_Myconn);
            Mycmd = new MySqlCommand();//for selecting users 
            connect.Open();
            Mycmd = connect.CreateCommand();
            Mycmd.CommandText = "select userName from users";
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
                    //cmbDeviceId.Items.Add(row[0].ToString());
                    lstUsers.Items.Add(row[0].ToString());
                }
            }        
           }
           private void btnFetchData_Click_1(object sender, EventArgs e)
           {
               //grdCVSFile.Visible = false;
               grdAssignStatus.Visible = true;
               if (cmbSelectType.Text == "")
               {
                   lblMessages.ForeColor = System.Drawing.Color.Red;
                   lblMessages.Text = "Please Select Selection Type ...";
               }
               else
               {
                   if (selectType == "Date wise")
                   {
                       //MessageBox.Show("Date OK");
                       getDataWise();
                   }
                   else if (selectType == "Date-Area wise")
                   {
                       //MessageBox.Show("Area OK");
                       getAreaDateWise();
                   }
                   else if (selectType == "Date-Area wiht Doctor wise")
                   {
                       //MessageBox.Show("Area Dr OK");
                       getAreaDateDoctorWise();
                   }          
               }
               
        }
        private void btnFetchData_Click(object sender, EventArgs e)
        {
            lblMessages.Text = "Please Wait while date assigning ....";
            MessageBox.Show("Please Wait while date assigning ....");
            string startDate = cmbYear.Text + "-" + cmbMonth.Text + "-" + cmdDate.Text;
            string endDate = cmbYearEnd.Text + "-" + cmbMonthEnd.Text + "-" + cmbDateEnd.Text;
            try
            {
                string get_Myconn = con_sql_mysql.getConnectionMySql();
                MySqlConnection connect = new MySqlConnection(get_Myconn);
                Mycmd = new MySqlCommand();//for selecting users 
                connect.Open();         
                if (mySelectDT != null && mySelectDT.Rows.Count > 0)
                {
                    // MessageBox.Show("Users Found");
                    foreach (DataRow row in mySelectDT.Rows)
                    {
                        //in your loop
                        var radioPatientRptDate = row[0].ToString();
                        var radioPatientsName = row[1].ToString();
                        var radioPatientsId = row[2].ToString();
                        var radioDoctorId = row[3].ToString();
                        var radioName = row[4].ToString().Replace("'", "''"); ;
                        var cut = row[5].ToString();
                        var invest = row[6].ToString();
                        Mycmd = connect.CreateCommand();
                        Mycmd.CommandText = "INSERT INTO  csvfile(radioPatientRptDate,radioPatientsName,radioPatientsId,radioDoctorId,radioName,cut,invest,deviceId,userName,status) values('" + radioPatientRptDate + "','" + radioPatientsName + "','" + radioPatientsId + "','" + radioDoctorId + "','" + radioName + "','" + cut + "','" + invest + "','" + userName + "','" + deviceId + "','0')";
                        Mycmd.ExecuteNonQuery();
                    }
                    var csv = new StringBuilder(); //reading file
                    if (lstUsers.Text != "")   //for checking user empty
                    {
                        Mycmd = connect.CreateCommand();
                        Mycmd.CommandText = "select radioPatientRptDate,radioPatientsId,radioPatientsName,radioDoctorId,radioName,cut,invest,deviceId,userName,status,pt_transaction from csvfile where userName='" + deviceId + "' and radioPatientRptDate between'" + startDate + "'and'" + endDate + "'";
                        Mycmd.ExecuteNonQuery();
                        MySqlDataAdapter mydaCsvFile = new MySqlDataAdapter(Mycmd);
                        DataTable mydtCsvFile = new DataTable();
                        mydaCsvFile.Fill(mydtCsvFile);
                        //grdShowData.DataSource = mydtCsvFile;
                        if (mydtCsvFile.Rows.Count > 0)
                        {
                            grdShowData.Visible = true;
                            grdAssignStatus.Visible = false;
                            grdCVSFile.Visible = true;
                            grdCVSFile.ColumnCount =11;
                            grdCVSFile.Columns[0].Name = "Date";
                            grdCVSFile.Columns[1].Name = "Pt ID";
                            grdCVSFile.Columns[2].Name = "Patients Name";
                            grdCVSFile.Columns[3].Name = "Dr ID";
                            grdCVSFile.Columns[4].Name = "Dr Name";
                            grdCVSFile.Columns[5].Name = "IP";
                            grdCVSFile.Columns[6].Name = "Investigation";
                            grdCVSFile.Columns[7].Name = "Device";
                            grdCVSFile.Columns[8].Name = "User Name";
                            grdCVSFile.Columns[9].Name = "Status";
                            grdCVSFile.Columns[10].Name = "TransID";

                            grdCVSFile.Columns[0].ReadOnly = true;
                            grdCVSFile.Columns[1].ReadOnly = true;
                            grdCVSFile.Columns[2].ReadOnly = true;
                            grdCVSFile.Columns[3].ReadOnly = true;
                            grdCVSFile.Columns[4].ReadOnly = true;
                            grdCVSFile.Columns[5].ReadOnly = true;
                            grdCVSFile.Columns[6].ReadOnly = true;
                            grdCVSFile.Columns[7].ReadOnly = true;
                            grdCVSFile.Columns[8].ReadOnly = true;
                            grdCVSFile.Columns[9].ReadOnly = true;

                            grdCVSFile.Columns[1].Visible = false;
                            grdCVSFile.Columns[3].Visible = false;
                            grdCVSFile.Columns[7].Visible = false;
                            grdCVSFile.Columns[10].Visible = false;

                            grdCVSFile.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            grdCVSFile.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            string[] row1;
                            foreach (DataRow value in mydtCsvFile.Rows)
                            {
                                Data_Decryptioncs data_decrypt = new Data_Decryptioncs();
                                string dateValue = Convert.ToDateTime(value[0]).ToString("dd-MM-yyyy");
                                //row = new string[] { data_decrypt.Decrypt(value[0].ToString()) };
                                // MessageBox.Show(value[0].ToString());                        
                                //row = new string[] { value[0].ToString(),data_decrypt.Decrypt(value[1].ToString()), data_decrypt.Decrypt(value[2].ToString()), data_decrypt.Decrypt(value[3].ToString()), data_decrypt.Decrypt(value[4].ToString()), data_decrypt.Decrypt(value[5].ToString()), data_decrypt.Decrypt(value[6].ToString()), data_decrypt.Decrypt(value[7].ToString()), data_decrypt.Decrypt(value[8].ToString()) };
                                row1 = new string[] { dateValue, (value[1].ToString()), (value[2].ToString()), (value[3].ToString()), (value[4].ToString()), (value[5].ToString()), (value[6].ToString()), (value[7].ToString()), (value[8].ToString()), (value[9].ToString()) };
                                /*row = new string[] { data_decrypt.Decrypt(value[0].ToString()), data_decrypt.Decrypt(value[1].ToString()), data_decrypt.Decrypt(value[2].ToString()), data_decrypt.Decrypt(value[3].ToString()), data_decrypt.Decrypt(value[4].ToString())
                                    , data_decrypt.Decrypt(value[5].ToString()), data_decrypt.Decrypt(value[6].ToString()), data_decrypt.Decrypt(value[7].ToString()) };*/
                                grdCVSFile.Rows.Add(row1);

                            }
                            grdCVSFile.Sort(grdCVSFile.Columns[0], ListSortDirection.Descending);
                            foreach (DataRow row in mydtCsvFile.Rows)
                            {
                                //in your loop
                                var transID = row[10].ToString();
                                var radioPatientRptDate = row[0].ToString();
                                var radioPatientsId = row[1].ToString();
                                var radioPatientsName = row[2].ToString();
                                var radioDoctorId = row[3].ToString();                           
                                var radioName = row[4].ToString().Replace("'", "''"); ;
                                var cut = row[5].ToString();
                                var invest = row[6].ToString();
                                var devId = row[7].ToString();
                                var userName = row[8].ToString();
                                var status = row[9].ToString();

                                string strValue = invest;
                                string[] strArray = strValue.Split(',');
                                string InvestName = "";
                                Mycmd = connect.CreateCommand();
                                for (int i = 0; i < strArray.Length; i++)
                                {
                                    //MessageBox.Show(strArray[i]);

                                    Mycmd.CommandText = "select radioInvestigationName from investigation  where radioInvestigationId='" + strArray[i] + "'; update vwPatientWithDoctorsCut_CSV set ass_status=1 where radioPatientRptDate between'" + startDate + "'and'" + endDate + "'";
                                    Mycmd.ExecuteNonQuery();
                                    MySqlDataAdapter myInvesName = new MySqlDataAdapter(Mycmd);
                                    DataTable mydtInvesName = new DataTable();
                                    myInvesName.Fill(mydtInvesName);
                                    if (mydtInvesName.Rows.Count > 0)
                                    {
                                        foreach (DataRow rowInvesName in mydtInvesName.Rows)
                                        {
                                            InvestName += rowInvesName[0].ToString() + " / ";
                                        }
                                    }

                                    //MessageBox.Show(InvestName);
                                }
                                Mycmd = connect.CreateCommand();
                                Mycmd.CommandText = "update vwPatientWithDoctorsCut_CSV set ass_status=1 where radioPatientRptDate between'" + startDate + "'and'" + endDate + "'";
                                Mycmd.ExecuteNonQuery();

                                var newLine = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}", transID, radioPatientRptDate, radioPatientsId, radioPatientsName, radioDoctorId, radioName, cut, InvestName, devId, userName, status);
                                csv.AppendLine(newLine);
                            }
                            //after your loop          
                            File.WriteAllText(@"D:\Radio\" + deviceId + ".csv", csv.ToString());
                            grdShowData.Visible = false;
                            MessageBox.Show("Send successfully !");
                            lblMessages.Text = "";
                        }
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
            catch (Exception)
            {
                MessageBox.Show("OOps check your formate !");
            }
        }

        private void cmbDeviceId_SelectedIndexChanged(object sender, EventArgs e)
        {
              /*deviceId=cmbDeviceId.Text;
              MessageBox.Show(deviceId);
              string get_Myconn = con_sql_mysql.getConnectionMySql();
              MySqlConnection connect = new MySqlConnection(get_Myconn);
              Mycmd = new MySqlCommand();//for selecting users 
              connect.Open();
              Mycmd = connect.CreateCommand();
              Mycmd.CommandText = "select deviceId from users where userName='" + deviceId + "'";
              MySqlDataAdapter mySelectUserName = new MySqlDataAdapter(Mycmd);
              DataTable mySelectDTUserName = new DataTable();
              mySelectUserName.Fill(mySelectDTUserName);
              if (mySelectDTUserName.Rows.Count > 0)
              {
                  
                 // MessageBox.Show("Users Found");
                  foreach (DataRow row in mySelectDTUserName.Rows)
                   {
                       //MessageBox.Show("Users Found"+row[1].ToString());
                       userName=row[0].ToString();
                   }
              }*/
        }

        private void lstUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            deviceId = lstUsers.SelectedItem.ToString();
            //MessageBox.Show(deviceId);
            string get_Myconn = con_sql_mysql.getConnectionMySql();
            MySqlConnection connect = new MySqlConnection(get_Myconn);
            Mycmd = new MySqlCommand();//for selecting users 
            connect.Open();
            Mycmd = connect.CreateCommand();
            Mycmd.CommandText = "select deviceId from users where userName='" + deviceId + "'";
            MySqlDataAdapter mySelectUserName = new MySqlDataAdapter(Mycmd);
            DataTable mySelectDTUserName = new DataTable();
            mySelectUserName.Fill(mySelectDTUserName);
            if (mySelectDTUserName.Rows.Count > 0)
            {

                // MessageBox.Show("Users Found");
                foreach (DataRow row in mySelectDTUserName.Rows)
                {
                    //MessageBox.Show("Users Found"+row[1].ToString());
                    userName = row[0].ToString();
                }
            }
        }

        private void getArea()
        {
            string get_Myconn = con_sql_mysql.getConnectionMySql();
            MySqlConnection connect = new MySqlConnection(get_Myconn);
            Mycmd = new MySqlCommand();//for selecting users 
            connect.Open();
            Mycmd = connect.CreateCommand();
            Mycmd.CommandText = "select radioArea from masterarea";
            MySqlDataAdapter myAreaDA = new MySqlDataAdapter(Mycmd);
            DataTable myAreaDT = new DataTable();
            myAreaDA.Fill(myAreaDT);
            if (myAreaDT.Rows.Count > 0)
            {

                // MessageBox.Show("Users Found");
                foreach (DataRow row in myAreaDT.Rows)
                {
                    //MessageBox.Show("Users Found"+row[1].ToString());
                    cmbArea.Items.Add(row[0].ToString());
                }
            }
            connect.Close();
        }

        private void cmbArea_SelectedIndexChanged(object sender, EventArgs e)
        {        
            Areaid = cmbArea.Text;
            string get_Myconn = con_sql_mysql.getConnectionMySql();
            MySqlConnection connect = new MySqlConnection(get_Myconn);
            Mycmd = new MySqlCommand();//for selecting users 
            connect.Open();
            Mycmd = connect.CreateCommand();
            Mycmd.CommandText = "select radioAreaId from masterarea where radioArea	='" + Areaid + "'";
            MySqlDataAdapter myAreaDA = new MySqlDataAdapter(Mycmd);
            DataTable myAreaDT = new DataTable();
            myAreaDA.Fill(myAreaDT);
            if (myAreaDT.Rows.Count > 0)
            {

                // MessageBox.Show("Users Found");
                foreach (DataRow row in myAreaDT.Rows)
                {
                    //MessageBox.Show("Users Found"+row[0].ToString());
                    doctname=row[0].ToString();
                }
            }
            //code to select doctor from Area code
            Mycmd = connect.CreateCommand();
            Mycmd.CommandText = "select radioName from doctors where areaId	='" + doctname + "'";
            MySqlDataAdapter myDoctrDA = new MySqlDataAdapter(Mycmd);
            DataTable myDoctrDT = new DataTable();
            myDoctrDA.Fill(myDoctrDT);
            if (myDoctrDT.Rows.Count > 0)
            {
                cmbDoctors.Items.Clear();
                // MessageBox.Show("Users Found");
                foreach (DataRow row in myDoctrDT.Rows)
                {
                    //MessageBox.Show("Users Found" + row[0].ToString());
                    cmbDoctors.Items.Add(row[0].ToString());
                }
            }
            else
            {
                cmbDoctors.Items.Clear();
            }
        }

        private void cmbSelectType_SelectedIndexChanged(object sender, EventArgs e)
        {           
            selectType = cmbSelectType.Text;
            
        }
        private void getDataWise()
        {
            if (cmbYear.Text == "" || cmbMonth.Text == "" || cmdDate.Text == "")
            {
                lblMessages.ForeColor = System.Drawing.Color.Red;
                lblMessages.Text = "Please Select start data ...";
                //MessageBox.Show("Please Select start data !..");
            }
            else if (cmbYearEnd.Text == "" || cmbMonthEnd.Text == "" || cmbDateEnd.Text == "")
            {
                lblMessages.ForeColor = System.Drawing.Color.Red;
                lblMessages.Text = "Please Select end data ...";
                // MessageBox.Show("Please Select end data !..");
            }
            else
            {
                try
                {
                    lblMessages.ForeColor = System.Drawing.Color.Blue;
                    MessageBox.Show("Please Wailt while data updating Do not cllick anywhere");
                    lblMessages.Text = "Please Wailt while data updating.... !";
                    string startDate = cmbYear.Text + "-" + cmbMonth.Text + "-" + cmdDate.Text;
                    string endDate = cmbYearEnd.Text + "-" + cmbMonthEnd.Text + "-" + cmbDateEnd.Text;
                    //MessageBox.Show(startDate +" "+endDate);
                    string get_Myconn = con_sql_mysql.getConnectionMySql();
                    MySqlConnection connect = new MySqlConnection(get_Myconn);
                    Mycmd = new MySqlCommand();//for selecting users 
                    connect.Open();
                    Mycmd = connect.CreateCommand();
                    Mycmd.CommandText = "select * from vwPatientWithDoctorsCut_CSV a where a.radioPatientRptDate between'" + startDate + "'and'" + endDate + "' and a.ass_status=0";

                    mySelectDA = new MySqlDataAdapter(Mycmd);
                    mySelectDT = new DataTable();
                    mySelectDA.Fill(mySelectDT);
                    if (mySelectDT.Rows.Count > 0)
                    {
                        lblMessages.ForeColor = System.Drawing.Color.Green;
                        lblMessages.Text = "Data fetched successfully !";
                        MessageBox.Show("Data fetched successfully !");
                        // grdShowData.DataSource = mySelectDT;
                        grdAssignStatus.Visible = false;
                        grdShowData.Visible = true;
                        grdShowData.ColumnCount = 7;
                        grdShowData.Columns[0].Name = "Date";
                        grdShowData.Columns[1].Name = "Patients Name";
                        grdShowData.Columns[2].Name = "Pt ID";
                        grdShowData.Columns[3].Name = "Dr ID";
                        grdShowData.Columns[4].Name = "Dr Name";
                        grdShowData.Columns[5].Name = "IP";
                        grdShowData.Columns[6].Name = "Investigation";

                        grdShowData.Columns[0].ReadOnly = true;
                        grdShowData.Columns[1].ReadOnly = true;
                        grdShowData.Columns[2].ReadOnly = true;
                        grdShowData.Columns[3].ReadOnly = true;
                        grdShowData.Columns[4].ReadOnly = true;
                        grdShowData.Columns[5].ReadOnly = true;
                        grdShowData.Columns[6].ReadOnly = true;

                        grdShowData.Columns[2].Visible = false;
                        grdShowData.Columns[3].Visible = false;

                        grdShowData.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        grdShowData.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        string[] row;
                        foreach (DataRow value in mySelectDT.Rows)
                        {
                            Data_Decryptioncs data_decrypt = new Data_Decryptioncs();
                            string dateValue = Convert.ToDateTime(value[0]).ToString("dd-MM-yyyy");
                            //row = new string[] { data_decrypt.Decrypt(value[0].ToString()) };
                            // MessageBox.Show(value[0].ToString());                        
                            //row = new string[] { value[0].ToString(),data_decrypt.Decrypt(value[1].ToString()), data_decrypt.Decrypt(value[2].ToString()), data_decrypt.Decrypt(value[3].ToString()), data_decrypt.Decrypt(value[4].ToString()), data_decrypt.Decrypt(value[5].ToString()), data_decrypt.Decrypt(value[6].ToString()), data_decrypt.Decrypt(value[7].ToString()), data_decrypt.Decrypt(value[8].ToString()) };
                            row = new string[] { dateValue, (value[1].ToString()), (value[2].ToString()), (value[3].ToString()), (value[4].ToString()), (value[5].ToString()), (value[6].ToString()) };
                            /*row = new string[] { data_decrypt.Decrypt(value[0].ToString()), data_decrypt.Decrypt(value[1].ToString()), data_decrypt.Decrypt(value[2].ToString()), data_decrypt.Decrypt(value[3].ToString()), data_decrypt.Decrypt(value[4].ToString())
                                , data_decrypt.Decrypt(value[5].ToString()), data_decrypt.Decrypt(value[6].ToString()), data_decrypt.Decrypt(value[7].ToString()) };*/
                            grdShowData.Rows.Add(row);

                        }
                        grdShowData.Sort(grdShowData.Columns[0], ListSortDirection.Descending);
                        //MessageBox.Show("Please Wailt while data updating !");

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
                        lblMessages.Text = "";
                    }
                    connect.Close();
                }
                catch (Exception exe)
                {
                    MessageBox.Show("Check your formate !" + exe);
                }
            }
        
        }
        private void getAreaDateWise()
        {
            if (cmbYear.Text == "" || cmbMonth.Text == "" || cmdDate.Text == "")
            {
                lblMessages.ForeColor = System.Drawing.Color.Red;
                lblMessages.Text = "Please Select start data ...";
                //MessageBox.Show("Please Select start data !..");
            }
            else if (cmbYearEnd.Text == "" || cmbMonthEnd.Text == "" || cmbDateEnd.Text == "")
            {
                lblMessages.ForeColor = System.Drawing.Color.Red;
                lblMessages.Text = "Please Select end data ...";
                // MessageBox.Show("Please Select end data !..");
            }
            else if (cmbArea.Text == "")
            {
                lblMessages.ForeColor = System.Drawing.Color.Red;
                lblMessages.Text = "Please Select Area ...";
            }
            else
            {
                try
                {
                    lblMessages.ForeColor = System.Drawing.Color.Blue;
                    MessageBox.Show("Please Wailt while data updating Do not cllick anywhere");
                    lblMessages.Text = "Please Wailt while data updating.... !";
                    string startDate = cmbYear.Text + "-" + cmbMonth.Text + "-" + cmdDate.Text;
                    string endDate = cmbYearEnd.Text + "-" + cmbMonthEnd.Text + "-" + cmbDateEnd.Text;
                    //MessageBox.Show(startDate +" "+endDate);
                    string get_Myconn = con_sql_mysql.getConnectionMySql();
                    MySqlConnection connect = new MySqlConnection(get_Myconn);
                    Mycmd = new MySqlCommand();//for selecting users 
                    connect.Open();
                    Mycmd = connect.CreateCommand();
                    //Mycmd.CommandText = "select * from vwPatientWithDoctorsCut_CSV a where a.radioPatientRptDate between'" + startDate + "'and'" + endDate + "' and a.ass_status=0 and AND a.radioDoctorId = b.radioDoctorIdAND b.areaId ='"+Ar+"'";
                    Mycmd.CommandText = "SELECT a.radioPatientRptDate, a.radioPatientsName, a.radioPatientsId, a.radioDoctorId, a.radioName, a.cut, a.radioInvestigation, a.ass_status FROM vwPatientWithDoctorsCut_CSV a, doctors b WHERE a.radioPatientRptDate BETWEEN '" + startDate + "' AND '" + endDate + "' AND a.ass_status =0 AND a.radioDoctorId=b.radioDoctorId AND b.areaId ='" + doctname + "'";
                    mySelectDA = new MySqlDataAdapter(Mycmd);
                    mySelectDT = new DataTable();
                    mySelectDA.Fill(mySelectDT);
                    if (mySelectDT.Rows.Count > 0)
                    {
                        lblMessages.ForeColor = System.Drawing.Color.Green;
                        lblMessages.Text = "Data fetched successfully !";
                        MessageBox.Show("Data fetched successfully !");
                        // grdShowData.DataSource = mySelectDT;
                        grdAssignStatus.Visible = false;
                        grdShowData.Visible = true;
                        grdShowData.ColumnCount = 7;
                        grdShowData.Columns[0].Name = "Date";
                        grdShowData.Columns[1].Name = "Patients Name";
                        grdShowData.Columns[2].Name = "Pt ID";
                        grdShowData.Columns[3].Name = "Dr ID";
                        grdShowData.Columns[4].Name = "Dr Name";
                        grdShowData.Columns[5].Name = "IP";
                        grdShowData.Columns[6].Name = "Investigation";

                        grdShowData.Columns[0].ReadOnly = true;
                        grdShowData.Columns[1].ReadOnly = true;
                        grdShowData.Columns[2].ReadOnly = true;
                        grdShowData.Columns[3].ReadOnly = true;
                        grdShowData.Columns[4].ReadOnly = true;
                        grdShowData.Columns[5].ReadOnly = true;
                        grdShowData.Columns[6].ReadOnly = true;

                        grdShowData.Columns[2].Visible = false;
                        grdShowData.Columns[3].Visible = false;

                        grdShowData.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        grdShowData.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        string[] row;
                        foreach (DataRow value in mySelectDT.Rows)
                        {
                            Data_Decryptioncs data_decrypt = new Data_Decryptioncs();
                            string dateValue = Convert.ToDateTime(value[0]).ToString("dd-MM-yyyy");
                            //row = new string[] { data_decrypt.Decrypt(value[0].ToString()) };
                            // MessageBox.Show(value[0].ToString());                        
                            //row = new string[] { value[0].ToString(),data_decrypt.Decrypt(value[1].ToString()), data_decrypt.Decrypt(value[2].ToString()), data_decrypt.Decrypt(value[3].ToString()), data_decrypt.Decrypt(value[4].ToString()), data_decrypt.Decrypt(value[5].ToString()), data_decrypt.Decrypt(value[6].ToString()), data_decrypt.Decrypt(value[7].ToString()), data_decrypt.Decrypt(value[8].ToString()) };
                            row = new string[] { dateValue, (value[1].ToString()), (value[2].ToString()), (value[3].ToString()), (value[4].ToString()), (value[5].ToString()), (value[6].ToString()) };
                            /*row = new string[] { data_decrypt.Decrypt(value[0].ToString()), data_decrypt.Decrypt(value[1].ToString()), data_decrypt.Decrypt(value[2].ToString()), data_decrypt.Decrypt(value[3].ToString()), data_decrypt.Decrypt(value[4].ToString())
                                , data_decrypt.Decrypt(value[5].ToString()), data_decrypt.Decrypt(value[6].ToString()), data_decrypt.Decrypt(value[7].ToString()) };*/
                            grdShowData.Rows.Add(row);

                        }
                        grdShowData.Sort(grdShowData.Columns[0], ListSortDirection.Descending);
                        //MessageBox.Show("Please Wailt while data updating !");

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
                        lblMessages.Text = "";
                    }
                    connect.Close();
                }
                catch (Exception exe)
                {
                    MessageBox.Show("Check your formate !" + exe);
                }
            }
        }

        private void getAreaDateDoctorWise()
        {
            if (cmbYear.Text == "" || cmbMonth.Text == "" || cmdDate.Text == "")
            {
                lblMessages.ForeColor = System.Drawing.Color.Red;
                lblMessages.Text = "Please Select start data ...";
                //MessageBox.Show("Please Select start data !..");
            }
            else if (cmbYearEnd.Text == "" || cmbMonthEnd.Text == "" || cmbDateEnd.Text == "")
            {
                lblMessages.ForeColor = System.Drawing.Color.Red;
                lblMessages.Text = "Please Select end data ...";
                // MessageBox.Show("Please Select end data !..");
            }
            else if (cmbArea.Text == "")
            {
                lblMessages.ForeColor = System.Drawing.Color.Red;
                lblMessages.Text = "Please Select Area ...";
            }
            else if (cmbDoctors.Text == "")
            {
                lblMessages.ForeColor = System.Drawing.Color.Red;
                lblMessages.Text = "Please Select Doctor ...";
            }
            else
            {
                try
                {
                    lblMessages.ForeColor = System.Drawing.Color.Blue;
                    MessageBox.Show("Please Wailt while data updating Do not cllick anywhere");
                    lblMessages.Text = "Please Wailt while data updating.... !";
                    string startDate = cmbYear.Text + "-" + cmbMonth.Text + "-" + cmdDate.Text;
                    string endDate = cmbYearEnd.Text + "-" + cmbMonthEnd.Text + "-" + cmbDateEnd.Text;
                    //MessageBox.Show(startDate +" "+endDate);
                    string get_Myconn = con_sql_mysql.getConnectionMySql();
                    MySqlConnection connect = new MySqlConnection(get_Myconn);
                    Mycmd = new MySqlCommand();//for selecting users 
                    connect.Open();
                    Mycmd = connect.CreateCommand();
                    //Mycmd.CommandText = "select * from vwPatientWithDoctorsCut_CSV a where a.radioPatientRptDate between'" + startDate + "'and'" + endDate + "' and a.ass_status=0 and AND a.radioDoctorId = b.radioDoctorIdAND b.areaId ='"+Ar+"'";
                    Mycmd.CommandText = "SELECT a.radioPatientRptDate, a.radioPatientsName, a.radioPatientsId, a.radioDoctorId, a.radioName, a.cut, a.radioInvestigation, a.ass_status FROM vwPatientWithDoctorsCut_CSV a, doctors b WHERE a.radioPatientRptDate BETWEEN '" + startDate + "' AND '" + endDate + "' AND a.ass_status =0 AND a.radioDoctorId=b.radioDoctorId AND b.areaId ='" + doctname + "' and a.radioDoctorId ='" + doctId + "'";
                    mySelectDA = new MySqlDataAdapter(Mycmd);
                    mySelectDT = new DataTable();
                    mySelectDA.Fill(mySelectDT);
                    if (mySelectDT.Rows.Count > 0)
                    {
                        lblMessages.ForeColor = System.Drawing.Color.Green;
                        lblMessages.Text = "Data fetched successfully !";
                        MessageBox.Show("Data fetched successfully !");
                        // grdShowData.DataSource = mySelectDT;
                        grdAssignStatus.Visible = false;
                        grdShowData.Visible = true;
                        grdShowData.ColumnCount = 7;
                        grdShowData.Columns[0].Name = "Date";
                        grdShowData.Columns[1].Name = "Patients Name";
                        grdShowData.Columns[2].Name = "Pt ID";
                        grdShowData.Columns[3].Name = "Dr ID";
                        grdShowData.Columns[4].Name = "Dr Name";
                        grdShowData.Columns[5].Name = "IP";
                        grdShowData.Columns[6].Name = "Investigation";

                        grdShowData.Columns[0].ReadOnly = true;
                        grdShowData.Columns[1].ReadOnly = true;
                        grdShowData.Columns[2].ReadOnly = true;
                        grdShowData.Columns[3].ReadOnly = true;
                        grdShowData.Columns[4].ReadOnly = true;
                        grdShowData.Columns[5].ReadOnly = true;
                        grdShowData.Columns[6].ReadOnly = true;

                        grdShowData.Columns[2].Visible = false;
                        grdShowData.Columns[3].Visible = false;

                        grdShowData.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        grdShowData.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        string[] row;
                        foreach (DataRow value in mySelectDT.Rows)
                        {
                            Data_Decryptioncs data_decrypt = new Data_Decryptioncs();
                            string dateValue = Convert.ToDateTime(value[0]).ToString("dd-MM-yyyy");
                            //row = new string[] { data_decrypt.Decrypt(value[0].ToString()) };
                            // MessageBox.Show(value[0].ToString());                        
                            //row = new string[] { value[0].ToString(),data_decrypt.Decrypt(value[1].ToString()), data_decrypt.Decrypt(value[2].ToString()), data_decrypt.Decrypt(value[3].ToString()), data_decrypt.Decrypt(value[4].ToString()), data_decrypt.Decrypt(value[5].ToString()), data_decrypt.Decrypt(value[6].ToString()), data_decrypt.Decrypt(value[7].ToString()), data_decrypt.Decrypt(value[8].ToString()) };
                            row = new string[] { dateValue, (value[1].ToString()), (value[2].ToString()), (value[3].ToString()), (value[4].ToString()), (value[5].ToString()), (value[6].ToString()) };
                            /*row = new string[] { data_decrypt.Decrypt(value[0].ToString()), data_decrypt.Decrypt(value[1].ToString()), data_decrypt.Decrypt(value[2].ToString()), data_decrypt.Decrypt(value[3].ToString()), data_decrypt.Decrypt(value[4].ToString())
                                , data_decrypt.Decrypt(value[5].ToString()), data_decrypt.Decrypt(value[6].ToString()), data_decrypt.Decrypt(value[7].ToString()) };*/
                            grdShowData.Rows.Add(row);

                        }
                        grdShowData.Sort(grdShowData.Columns[0], ListSortDirection.Descending);
                        //MessageBox.Show("Please Wailt while data updating !");

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
                        lblMessages.Text = "";
                    }
                    connect.Close();
                }
                catch (Exception exe)
                {
                    MessageBox.Show("Check your formate !" + exe);
                }
            }
        }
        private void cmbDoctors_SelectedIndexChanged(object sender, EventArgs e)
        {
            string doctorName = cmbDoctors.Text;
            string get_Myconn = con_sql_mysql.getConnectionMySql();
            MySqlConnection connect = new MySqlConnection(get_Myconn);
            Mycmd = new MySqlCommand();//for selecting users 
            connect.Open();
            Mycmd = connect.CreateCommand();
            Mycmd.CommandText = "select radioDoctorId from doctors where radioName	='" + doctorName + "'";
            MySqlDataAdapter myAreaDA = new MySqlDataAdapter(Mycmd);
            DataTable myAreaDT = new DataTable();
            myAreaDA.Fill(myAreaDT);
            if (myAreaDT.Rows.Count > 0)
            {

                // MessageBox.Show("Users Found");
                foreach (DataRow row in myAreaDT.Rows)
                {
                    //MessageBox.Show("Users Found"+row[0].ToString());
                    doctId = row[0].ToString();
                }
                //MessageBox.Show(doctId);
            }
        }
    }
}
