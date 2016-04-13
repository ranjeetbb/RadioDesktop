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
    public partial class frmReAssign : Form
    {   //for connection
        Connection_SQL_MySql con_sql_mysql = new Connection_SQL_MySql();
        string updateView = "";
        public frmReAssign()
        {
            InitializeComponent();
        }

        private void frmReAssign_Load(object sender, EventArgs e)
        {
            //btnFetchData.Enabled = false;
            lstUsers.Enabled = false;
            btnAssignData.Enabled = false;
            cmbArea.Enabled = false;
            cmbDoctors.Enabled = false;
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
            //lblMessages.Text = "";
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
                lstUsers.Sorted = true;
            }        
        }
        Data_Encryption data_en = new Data_Encryption();
        Data_Decryptioncs data_decrypt = new Data_Decryptioncs();

        MySqlCommand Mycmd;
        MySqlDataAdapter myda, mySelectDA;
        DataTable mydt, mySelectDT;

        string userName = "";//for user name to set particular user 
        string deviceId = "";//for device id to set particular user 
        string doctname = "";//
        string Areaid = "";//for area 
        string selectType = "";//for selection type
        string doctId = "";
        string[] years = new string[] { "2011","2015", "2016", "2017" };
        string[] months = new string[] { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12" };
        string[] dates = new string[] { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31" };

        private void checkAssign()
        {
            string get_Myconn = con_sql_mysql.getConnectionMySql();
            MySqlConnection connect = new MySqlConnection(get_Myconn);
            Mycmd = new MySqlCommand();//for selecting users 
            connect.Open();
            Mycmd = connect.CreateCommand();
            Mycmd.CommandText = "SELECT a.radioPatientRptDate, a.radioPatientsName, a.radioPatientsId, a.radioDoctorId, a.radioName, a.invest, c.radioArea, a.cut, a.status FROM csvfile a, doctors b, masterarea c WHERE a.STATUS =2 AND a.radioDoctorId = b.radioDoctorId AND b.areaId = c.radioAreaId";
            MySqlDataAdapter assingDA = new MySqlDataAdapter(Mycmd);
            DataTable assignDT = new DataTable();
            assingDA.Fill(assignDT);
            //MessageBox.Show(""+assignDT.Rows.Count);
            if (assignDT.Rows.Count > 0)
            {
                lblMessages.Text = "";
                // grdShowData.DataSource = mySelectDT;
                grdAssignStatus.Rows.Clear();
                grdAssignStatus.ColumnCount = 9;
                grdAssignStatus.Columns[0].Name = "Date";
                grdAssignStatus.Columns[1].Name = "Patients Name";
                grdAssignStatus.Columns[2].Name = "Pt ID";
                grdAssignStatus.Columns[3].Name = "Dr ID";
                grdAssignStatus.Columns[4].Name = "Dr Name";
                grdAssignStatus.Columns[5].Name = "Investigation";
                grdAssignStatus.Columns[6].Name = "Area";
                grdAssignStatus.Columns[7].Name = "IP";
                grdAssignStatus.Columns[8].Name = "Status";

                grdAssignStatus.Columns[0].ReadOnly = true;
                grdAssignStatus.Columns[1].ReadOnly = true;
                grdAssignStatus.Columns[2].ReadOnly = true;
                grdAssignStatus.Columns[3].ReadOnly = true;
                grdAssignStatus.Columns[4].ReadOnly = true;
                grdAssignStatus.Columns[5].ReadOnly = true;
                grdAssignStatus.Columns[6].ReadOnly = true;
                grdAssignStatus.Columns[7].ReadOnly = true;
                grdAssignStatus.Columns[8].ReadOnly = true;

                grdAssignStatus.Columns[2].Visible = false;
                grdAssignStatus.Columns[3].Visible = false;

                grdAssignStatus.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                grdAssignStatus.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                grdAssignStatus.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                string[] row;
                string message="";
                foreach (DataRow value in assignDT.Rows)
                {
                    Data_Decryptioncs data_decrypt = new Data_Decryptioncs();
                    string dateValue = Convert.ToDateTime(value[0]).ToString("dd-MM-yyyy");
                    string status = value[8].ToString();
                    if(status == "2")
                    {
                        message = "Rejected";
                    }
                    //row = new string[] { data_decrypt.Decrypt(value[0].ToString()) };
                    // MessageBox.Show(value[0].ToString());                        
                    //row = new string[] { value[0].ToString(),data_decrypt.Decrypt(value[1].ToString()), data_decrypt.Decrypt(value[2].ToString()), data_decrypt.Decrypt(value[3].ToString()), data_decrypt.Decrypt(value[4].ToString()), data_decrypt.Decrypt(value[5].ToString()), data_decrypt.Decrypt(value[6].ToString()), data_decrypt.Decrypt(value[7].ToString()), data_decrypt.Decrypt(value[8].ToString()) };
                    row = new string[] { dateValue, (value[1].ToString()), (value[2].ToString()), (value[3].ToString()), (value[4].ToString()), (value[5].ToString()), (value[6].ToString()), (value[7].ToString()), message };
                    /*row = new string[] { data_decrypt.Decrypt(value[0].ToString()), data_decrypt.Decrypt(value[1].ToString()), data_decrypt.Decrypt(value[2].ToString()), data_decrypt.Decrypt(value[3].ToString()), data_decrypt.Decrypt(value[4].ToString())
                        , data_decrypt.Decrypt(value[5].ToString()), data_decrypt.Decrypt(value[6].ToString()), data_decrypt.Decrypt(value[7].ToString()) };*/
                    grdAssignStatus.Rows.Add(row);

                }
                grdAssignStatus.Sort(grdAssignStatus.Columns[0], ListSortDirection.Ascending);
            }
            else
            {
                grdAssignStatus.Rows.Clear();
                lblAssign.Text = "";
                lblMessages.ForeColor = System.Drawing.Color.Red;
                lblMessages.Text = "No records available for assignment  ....";
                btnFetchData.Enabled = false;
                lstUsers.Enabled = false;
                btnAssignData.Enabled = false;
            }

        }

        private void btnFetchData_Click(object sender, EventArgs e)
        {
            //grdCVSFile.Visible = false;
            lblAssign.Text = "";
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
                    //cmbArea.Enabled = true;
                    getAreaDateWise();
                }
                else if (selectType == "Date-Area wiht Doctor wise")
                {
                    //MessageBox.Show("Area Dr OK");
                    getAreaDateDoctorWise();
                }
            }
        }

        private void btnAssignData_Click(object sender, EventArgs e)
        {
            lblAssign.Text = "Please Wait while date assigning ....";
            //MessageBox.Show("Please Wait while date assigning ....");
            string startDate = cmbYear.Text + "-" + cmbMonth.Text + "-" + cmdDate.Text;
            string endDate = cmbYearEnd.Text + "-" + cmbMonthEnd.Text + "-" + cmbDateEnd.Text;
            if (selectType == "Date wise")
            {
                updateView = "update csvfile set status=0,deviceId='" + userName + "',userName='" + deviceId + "' where radioPatientRptDate between'" + startDate + "'and'" + endDate + "' and status=2";
            }
            else if (selectType == "Date-Area wise")
            {
                updateView = "update csvfile a, doctors b set a.status=0,a.deviceId='" + userName + "',a.userName='" + deviceId + "' WHERE a.radioPatientRptDate BETWEEN '" + startDate + "' AND '" + endDate + "' AND a.status =2 AND a.radioDoctorId=b.radioDoctorId AND b.areaId ='" + doctname + "'";
            }
            else if (selectType == "Date-Area wiht Doctor wise")
            {
                updateView = "update csvfile a, doctors b set a.status=0,a.deviceId='" + userName + "',a.userName='" + deviceId + "' WHERE a.radioPatientRptDate BETWEEN '" + startDate + "' AND '" + endDate + "' AND a.status =2 AND a.radioDoctorId=b.radioDoctorId AND b.areaId ='" + doctname + "' and a.radioDoctorId ='" + doctId + "'";
            }       
            try
            {
                string get_Myconn = con_sql_mysql.getConnectionMySql();
                MySqlConnection connect = new MySqlConnection(get_Myconn);
                Mycmd = new MySqlCommand();//for selecting users 
                connect.Open();
             if (lstUsers.Text != "")   //for checking user empty
             {
                if (mySelectDT != null && mySelectDT.Rows.Count > 0)
                {
                    // MessageBox.Show("Users Found");
                    Mycmd = connect.CreateCommand();
                    foreach (DataRow row in mySelectDT.Rows)
                    {
                        //in your loop
                        var radioPatientRptDate = row[0].ToString();
                        var radioPatientsName = row[1].ToString();
                        var radioPatientsId = row[2].ToString();
                        var radioDoctorId = row[3].ToString();
                        var radioName = row[4].ToString().Replace("'","''");
                        var invest = row[5].ToString();
                        var cut = row[7].ToString();                                           
                        //Mycmd.CommandText = "update csvfile set deviceId='" + userName + "',userName='" + deviceId + "',status=0 where radioPatientRptDate between'" + startDate + "'and'" + endDate + "' and status=2 and deviceId='" + userName + "'";
                        Mycmd.CommandText = updateView;
                        Mycmd.ExecuteNonQuery();
                    }
                        var csv = new StringBuilder(); //reading file                
                        Mycmd = connect.CreateCommand();
                        Mycmd.CommandText = "select radioPatientRptDate,radioPatientsId,radioPatientsName,radioDoctorId,radioName,cut,invest,deviceId,userName,status,pt_transaction from csvfile where userName='" + deviceId + "' and radioPatientRptDate between'" + startDate + "'and'" + endDate + "' and status=2";
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
                            grdCVSFile.Rows.Clear();
                            grdCVSFile.ColumnCount = 11;
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
                            string message = "";
                            foreach (DataRow value in mydtCsvFile.Rows)
                            {
                                Data_Decryptioncs data_decrypt = new Data_Decryptioncs();
                                string dateValue = Convert.ToDateTime(value[0]).ToString("dd-MM-yyyy");
                                string status = value[9].ToString();
                                if (status == "2")
                                {
                                    message = "Rejected";
                                }
                                //row = new string[] { data_decrypt.Decrypt(value[0].ToString()) };
                                // MessageBox.Show(value[0].ToString());                        
                                //row = new string[] { value[0].ToString(),data_decrypt.Decrypt(value[1].ToString()), data_decrypt.Decrypt(value[2].ToString()), data_decrypt.Decrypt(value[3].ToString()), data_decrypt.Decrypt(value[4].ToString()), data_decrypt.Decrypt(value[5].ToString()), data_decrypt.Decrypt(value[6].ToString()), data_decrypt.Decrypt(value[7].ToString()), data_decrypt.Decrypt(value[8].ToString()) };
                                row1 = new string[] { dateValue, (value[1].ToString()), (value[2].ToString()), (value[3].ToString()), (value[4].ToString()), (value[5].ToString()), (value[6].ToString()), (value[7].ToString()), (value[8].ToString()), message };
                                /*row = new string[] { data_decrypt.Decrypt(value[0].ToString()), data_decrypt.Decrypt(value[1].ToString()), data_decrypt.Decrypt(value[2].ToString()), data_decrypt.Decrypt(value[3].ToString()), data_decrypt.Decrypt(value[4].ToString())
                                    , data_decrypt.Decrypt(value[5].ToString()), data_decrypt.Decrypt(value[6].ToString()), data_decrypt.Decrypt(value[7].ToString()) };*/
                                grdCVSFile.Rows.Add(row1);

                            }
                            grdCVSFile.Sort(grdCVSFile.Columns[0], ListSortDirection.Ascending);
                            foreach (DataRow row in mydtCsvFile.Rows)
                            {
                                //in your loop
                                var transID = row[10].ToString();
                                var radioPatientRptDate = row[0].ToString();
                                var radioPatientsId = row[1].ToString();
                                var radioPatientsName = row[2].ToString();
                                var radioDoctorId = row[3].ToString();
                                var radioName = row[4].ToString().Replace("'", "''");
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

                                    Mycmd.CommandText = "select radioInvestigationName from investigation  where radioInvestigationId='" + strArray[i] + "';";
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
                                var newLine = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}", transID, radioPatientRptDate, radioPatientsId, radioPatientsName, radioDoctorId, radioName, cut, InvestName, devId, userName, status);
                                csv.AppendLine(newLine);
                            }
                            //after your loop          
                            File.WriteAllText(@"D:\Radio\" + deviceId + ".csv", csv.ToString());
                            grdShowData.Visible = false;
                            //MessageBox.Show("Send successfully !");                           
                            lblMessages.Text = "";
                            //btnAssignData.Enabled = false;
                            //lstUsers.Enabled = false;
                            //btnFetchData.Enabled = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("No Record Found for following date !");
                        
                    }
                }
                else
                {
                    MessageBox.Show("Select User !");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("OOps check your formate ! "+ex);
            }
            lblAssign.ForeColor = System.Drawing.Color.Red;
            lblAssign.Text = "Send successfully !";
            checkAssign();
            grdAssignStatus.Visible = true;
        }
          
        private void lstUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            deviceId = lstUsers.SelectedItem.ToString();
            MessageBox.Show(deviceId);
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
                    MessageBox.Show(userName);
                }
            }
            btnAssignData.Enabled = true;
            //MessageBox.Show(updateView);
        }

        private void getArea()
        {
            string startDate = cmbYear.Text + "-" + cmbMonth.Text + "-" + cmdDate.Text;
            string endDate = cmbYearEnd.Text + "-" + cmbMonthEnd.Text + "-" + cmbDateEnd.Text;
            string get_Myconn = con_sql_mysql.getConnectionMySql();
            MySqlConnection connect = new MySqlConnection(get_Myconn);
            Mycmd = new MySqlCommand();//for selecting users 
            connect.Open();
            Mycmd = connect.CreateCommand();
           // Mycmd.CommandText = "SELECT DISTINCT b.radioArea FROM masterarea b, vwPatientWithDoctorsCut_CSV a WHERE b.radioAreaId = a.areaId AND a.radioPatientRptDate BETWEEN  '" + startDate + "' AND  '" + endDate + "' AND a.ass_status =0";
            Mycmd.CommandText = "select distinct radioDoctorId from csvfile where radioPatientRptDate between '"+startDate+"' and '"+endDate+"' and status=2";
            MySqlDataAdapter myAreaDA = new MySqlDataAdapter(Mycmd);
            DataTable myAreaDT = new DataTable();
            myAreaDA.Fill(myAreaDT);
            if (myAreaDT.Rows.Count > 0)
            {
                cmbArea.Text = "";
                cmbArea.Items.Clear();
              // MessageBox.Show("Users Found");
                Mycmd = connect.CreateCommand();
                foreach (DataRow row in myAreaDT.Rows)
                {
                    //MessageBox.Show("Users Found"+row[1].ToString());
                    Mycmd.CommandText = "select a.radioArea from masterarea a,doctors b where a.radioAreaId=b.areaId and b.radioDoctorId='" + row[0].ToString() + "'";
                    MySqlDataAdapter areaNameDA = new MySqlDataAdapter(Mycmd);
                    DataTable areaNameDT = new DataTable();
                    areaNameDA.Fill(areaNameDT);
                    if (areaNameDT.Rows.Count > 0)
                    {
                        foreach (DataRow area in areaNameDT.Rows)
                        {
                            if (!cmbArea.Items.Contains(area[0].ToString()))
                            {
                                cmbArea.Items.Add(area[0].ToString());
                            }
                        }
                    }
                    
                }
                cmbArea.Sorted = true;
            }
            connect.Close();
        }

        private void cmbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            string startDate = cmbYear.Text + "-" + cmbMonth.Text + "-" + cmdDate.Text;
            string endDate = cmbYearEnd.Text + "-" + cmbMonthEnd.Text + "-" + cmbDateEnd.Text;

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
                    doctname = row[0].ToString();
                }
            }
            //code to select doctor from Area code
            Mycmd = connect.CreateCommand();
            Mycmd.CommandText = "SELECT b.radioName FROM doctors a, csvfile b WHERE a.areaId ='"+doctname+"' AND a.radioDoctorId = b.radioDoctorId AND b.radioPatientRptDate BETWEEN  '"+startDate+"' AND  '"+endDate+"' AND b.status =2";
            MySqlDataAdapter myDoctrDA = new MySqlDataAdapter(Mycmd);
            DataTable myDoctrDT = new DataTable();
            myDoctrDA.Fill(myDoctrDT);
            if (myDoctrDT.Rows.Count > 0)
            {
                cmbDoctors.Text = "";
                cmbDoctors.Items.Clear();
                // MessageBox.Show("Users Found");
                foreach (DataRow row in myDoctrDT.Rows)
                {
                    //MessageBox.Show("Users Found" + row[0].ToString());
                    if (!cmbDoctors.Items.Contains(row[0].ToString()))
                    {
                        cmbDoctors.Items.Add(row[0].ToString());
                    }
                }
                cmbDoctors.Sorted = true;
            }
            else
            {
                cmbDoctors.Items.Clear();
            }
        }

        private void cmbSelectType_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectType = cmbSelectType.Text;
            if (selectType == "Date wise")
            {          
                cmbArea.Enabled = false;
                cmbDoctors.Enabled = false;
            }
            else if (selectType == "Date-Area wise")
            {
                    getArea(); //call area
                    cmbArea.Enabled = true;
                    cmbDoctors.Enabled = false; 
            }
            else if (selectType == "Date-Area wiht Doctor wise")
            {
                //MessageBox.Show("Area OK");
                getArea(); //call area
                cmbArea.Enabled = true; 
                cmbDoctors.Enabled = true;
            }
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
                    //MessageBox.Show("Please Wailt while data updating Do not cllick anywhere");
                    lblMessages.Text = "Please Wailt while data updating.... !";
                    string startDate = cmbYear.Text + "-" + cmbMonth.Text + "-" + cmdDate.Text;
                    string endDate = cmbYearEnd.Text + "-" + cmbMonthEnd.Text + "-" + cmbDateEnd.Text;
                    //MessageBox.Show(startDate +" "+endDate);
                    string get_Myconn = con_sql_mysql.getConnectionMySql();
                    MySqlConnection connect = new MySqlConnection(get_Myconn);
                    Mycmd = new MySqlCommand();//for selecting users 
                    connect.Open();
                    Mycmd = connect.CreateCommand();
                    Mycmd.CommandText = "SELECT a.radioPatientRptDate, a.radioPatientsName, a.radioPatientsId, a.radioDoctorId, a.radioName, a.invest, c.radioArea, a.cut, a.status FROM csvfile a, doctors b, masterarea c WHERE a.STATUS =2 AND a.radioDoctorId = b.radioDoctorId AND b.areaId = c.radioAreaId AND a.radioPatientRptDate BETWEEN  '"+startDate+"' AND  '"+endDate+"'";

                    mySelectDA = new MySqlDataAdapter(Mycmd);
                    mySelectDT = new DataTable();
                    mySelectDA.Fill(mySelectDT);                 
                    if (mySelectDT.Rows.Count > 0)
                    {
                        lblMessages.ForeColor = System.Drawing.Color.Green;
                        lblMessages.Text = "Data fetched successfully !";
                        //MessageBox.Show("Data fetched successfully !");
                        lstUsers.Enabled = true;
                        //btnAssignData.Enabled = true;
                        // grdShowData.DataSource = mySelectDT;
                        grdAssignStatus.Visible = false;
                        grdShowData.Visible = true;
                        grdShowData.Rows.Clear();
                        grdShowData.ColumnCount = 9;
                        grdShowData.Columns[0].Name = "Date";
                        grdShowData.Columns[1].Name = "Patients Name";
                        grdShowData.Columns[2].Name = "Pt ID";
                        grdShowData.Columns[3].Name = "Dr ID";
                        grdShowData.Columns[4].Name = "Dr Name";
                        grdShowData.Columns[5].Name = "Investigation";
                        grdShowData.Columns[6].Name = "Area";
                        grdShowData.Columns[7].Name = "IP";
                        grdShowData.Columns[8].Name = "Status";

                        grdShowData.Columns[0].ReadOnly = true;
                        grdShowData.Columns[1].ReadOnly = true;
                        grdShowData.Columns[2].ReadOnly = true;
                        grdShowData.Columns[3].ReadOnly = true;
                        grdShowData.Columns[4].ReadOnly = true;
                        grdShowData.Columns[5].ReadOnly = true;
                        grdShowData.Columns[6].ReadOnly = true;
                        grdShowData.Columns[7].ReadOnly = true;
                        grdShowData.Columns[8].ReadOnly = true;

                        grdShowData.Columns[2].Visible = false;
                        grdShowData.Columns[3].Visible = false;

                        grdShowData.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        grdShowData.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        grdShowData.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        string[] row;
                        string message = "";
                        foreach (DataRow value in mySelectDT.Rows)
                        {
                            Data_Decryptioncs data_decrypt = new Data_Decryptioncs();
                            string dateValue = Convert.ToDateTime(value[0]).ToString("dd-MM-yyyy");
                            string status = value[8].ToString();
                            if (status == "2")
                            {
                                message = "Rejected";
                            }
                            //row = new string[] { data_decrypt.Decrypt(value[0].ToString()) };
                            // MessageBox.Show(value[0].ToString());                        
                            //row = new string[] { value[0].ToString(),data_decrypt.Decrypt(value[1].ToString()), data_decrypt.Decrypt(value[2].ToString()), data_decrypt.Decrypt(value[3].ToString()), data_decrypt.Decrypt(value[4].ToString()), data_decrypt.Decrypt(value[5].ToString()), data_decrypt.Decrypt(value[6].ToString()), data_decrypt.Decrypt(value[7].ToString()), data_decrypt.Decrypt(value[8].ToString()) };
                            row = new string[] { dateValue, (value[1].ToString()), (value[2].ToString()), (value[3].ToString()), (value[4].ToString()), (value[5].ToString()), (value[6].ToString()), (value[7].ToString()), message };
                            /*row = new string[] { data_decrypt.Decrypt(value[0].ToString()), data_decrypt.Decrypt(value[1].ToString()), data_decrypt.Decrypt(value[2].ToString()), data_decrypt.Decrypt(value[3].ToString()), data_decrypt.Decrypt(value[4].ToString())
                                , data_decrypt.Decrypt(value[5].ToString()), data_decrypt.Decrypt(value[6].ToString()), data_decrypt.Decrypt(value[7].ToString()) };*/
                            grdShowData.Rows.Add(row);

                        }
                        grdShowData.Sort(grdShowData.Columns[0], ListSortDirection.Ascending);
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
                    //MessageBox.Show("Please Wailt while data updating Do not cllick anywhere");
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
                    Mycmd.CommandText = "SELECT a.radioPatientRptDate, a.radioPatientsName, a.radioPatientsId, a.radioDoctorId, a.radioName, a.invest, c.radioArea, a.cut, a.status FROM csvfile a, doctors b, masterarea c WHERE a.STATUS =2 AND a.radioDoctorId = b.radioDoctorId AND b.areaId = c.radioAreaId AND a.radioPatientRptDate BETWEEN '"+startDate+"' AND '"+endDate+"' AND b.areaId = '"+doctname+"'";
                    mySelectDA = new MySqlDataAdapter(Mycmd);
                    mySelectDT = new DataTable();
                    mySelectDA.Fill(mySelectDT);
                    
                    if (mySelectDT.Rows.Count > 0)
                    {
                        lblMessages.ForeColor = System.Drawing.Color.Green;
                        lblMessages.Text = "Data fetched successfully !";
                        //MessageBox.Show("Data fetched successfully !");
                        lstUsers.Enabled = true;
                        //btnAssignData.Enabled = true;
                        // grdShowData.DataSource = mySelectDT;
                        grdAssignStatus.Visible = false;
                        grdShowData.Visible = true;
                        grdShowData.Rows.Clear();
                        grdShowData.ColumnCount = 9;
                        grdShowData.Columns[0].Name = "Date";
                        grdShowData.Columns[1].Name = "Patients Name";
                        grdShowData.Columns[2].Name = "Pt ID";
                        grdShowData.Columns[3].Name = "Dr ID";
                        grdShowData.Columns[4].Name = "Dr Name";
                        grdShowData.Columns[5].Name = "Investigation";
                        grdShowData.Columns[6].Name = "Area";
                        grdShowData.Columns[7].Name = "IP";
                        grdShowData.Columns[8].Name = "Status";

                        grdShowData.Columns[0].ReadOnly = true;
                        grdShowData.Columns[1].ReadOnly = true;
                        grdShowData.Columns[2].ReadOnly = true;
                        grdShowData.Columns[3].ReadOnly = true;
                        grdShowData.Columns[4].ReadOnly = true;
                        grdShowData.Columns[5].ReadOnly = true;
                        grdShowData.Columns[6].ReadOnly = true;
                        grdShowData.Columns[7].ReadOnly = true;
                        grdShowData.Columns[8].ReadOnly = true;

                        grdShowData.Columns[2].Visible = false;
                        grdShowData.Columns[3].Visible = false;

                        grdShowData.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        grdShowData.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        grdShowData.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        string[] row;
                        string message="";
                        foreach (DataRow value in mySelectDT.Rows)
                        {
                            Data_Decryptioncs data_decrypt = new Data_Decryptioncs();
                            string dateValue = Convert.ToDateTime(value[0]).ToString("dd-MM-yyyy");
                            string status = value[8].ToString();
                            if (status == "2")
                            {
                                message = "Rejected";
                            }
                            //row = new string[] { data_decrypt.Decrypt(value[0].ToString()) };
                            // MessageBox.Show(value[0].ToString());                        
                            //row = new string[] { value[0].ToString(),data_decrypt.Decrypt(value[1].ToString()), data_decrypt.Decrypt(value[2].ToString()), data_decrypt.Decrypt(value[3].ToString()), data_decrypt.Decrypt(value[4].ToString()), data_decrypt.Decrypt(value[5].ToString()), data_decrypt.Decrypt(value[6].ToString()), data_decrypt.Decrypt(value[7].ToString()), data_decrypt.Decrypt(value[8].ToString()) };
                            row = new string[] { dateValue, (value[1].ToString()), (value[2].ToString()), (value[3].ToString()), (value[4].ToString()), (value[5].ToString()), (value[6].ToString()), (value[7].ToString()),message };
                            /*row = new string[] { data_decrypt.Decrypt(value[0].ToString()), data_decrypt.Decrypt(value[1].ToString()), data_decrypt.Decrypt(value[2].ToString()), data_decrypt.Decrypt(value[3].ToString()), data_decrypt.Decrypt(value[4].ToString())
                                , data_decrypt.Decrypt(value[5].ToString()), data_decrypt.Decrypt(value[6].ToString()), data_decrypt.Decrypt(value[7].ToString()) };*/
                            grdShowData.Rows.Add(row);

                        }
                        grdShowData.Sort(grdShowData.Columns[0], ListSortDirection.Ascending);
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
                    //MessageBox.Show("Please Wailt while data updating Do not cllick anywhere");
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
                    //Mycmd.CommandText = "SELECT a.radioPatientRptDate, a.radioPatientsName, a.radioPatientsId, a.radioDoctorId, a.radioName, a.cut, a.invest, a.status FROM csvfile a, doctors b WHERE a.radioPatientRptDate BETWEEN '" + startDate + "' AND '" + endDate + "' AND a.status =2 AND a.radioDoctorId=b.radioDoctorId AND b.areaId ='" + doctname + "' and a.radioDoctorId ='" + doctId + "'";
                    Mycmd.CommandText = "SELECT a.radioPatientRptDate, a.radioPatientsName, a.radioPatientsId, a.radioDoctorId, a.radioName, a.invest, c.radioArea, a.cut, a.status FROM csvfile a, doctors b, masterarea c WHERE a.STATUS =2 AND a.radioDoctorId = b.radioDoctorId AND b.areaId = c.radioAreaId AND a.radioPatientRptDate BETWEEN '" + startDate + "' AND '" + endDate + "' AND b.areaId = '" + doctname + "'and a.radioDoctorId ='" + doctId + "'";
                    mySelectDA = new MySqlDataAdapter(Mycmd);
                    mySelectDT = new DataTable();
                    mySelectDA.Fill(mySelectDT);
                    
                    if (mySelectDT.Rows.Count > 0)
                    {
                        lblMessages.ForeColor = System.Drawing.Color.Green;
                        lblMessages.Text = "Data fetched successfully !";
                        //MessageBox.Show("Data fetched successfully !");
                        lstUsers.Enabled = true;
                        //btnAssignData.Enabled = true;
                        // grdShowData.DataSource = mySelectDT;
                        grdAssignStatus.Visible = false;
                        grdShowData.Visible = true;
                        grdShowData.Rows.Clear();
                        grdShowData.ColumnCount = 9;
                        grdShowData.Columns[0].Name = "Date";
                        grdShowData.Columns[1].Name = "Patients Name";
                        grdShowData.Columns[2].Name = "Pt ID";
                        grdShowData.Columns[3].Name = "Dr ID";
                        grdShowData.Columns[4].Name = "Dr Name";
                        grdShowData.Columns[5].Name = "Investigation";
                        grdShowData.Columns[6].Name = "Area";
                        grdShowData.Columns[7].Name = "IP";
                        grdShowData.Columns[8].Name = "Status";

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
                        grdShowData.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        string[] row;
                        string message = "";
                        foreach (DataRow value in mySelectDT.Rows)
                        {
                            Data_Decryptioncs data_decrypt = new Data_Decryptioncs();
                            string dateValue = Convert.ToDateTime(value[0]).ToString("dd-MM-yyyy");
                            string status = value[8].ToString();
                            if (status == "2")
                            {
                                message = "Rejected";
                            }
                            //row = new string[] { data_decrypt.Decrypt(value[0].ToString()) };
                            // MessageBox.Show(value[0].ToString());                        
                            //row = new string[] { value[0].ToString(),data_decrypt.Decrypt(value[1].ToString()), data_decrypt.Decrypt(value[2].ToString()), data_decrypt.Decrypt(value[3].ToString()), data_decrypt.Decrypt(value[4].ToString()), data_decrypt.Decrypt(value[5].ToString()), data_decrypt.Decrypt(value[6].ToString()), data_decrypt.Decrypt(value[7].ToString()), data_decrypt.Decrypt(value[8].ToString()) };
                            row = new string[] { dateValue, (value[1].ToString()), (value[2].ToString()), (value[3].ToString()), (value[4].ToString()), (value[5].ToString()), (value[6].ToString()), (value[7].ToString()),message };
                            /*row = new string[] { data_decrypt.Decrypt(value[0].ToString()), data_decrypt.Decrypt(value[1].ToString()), data_decrypt.Decrypt(value[2].ToString()), data_decrypt.Decrypt(value[3].ToString()), data_decrypt.Decrypt(value[4].ToString())
                                , data_decrypt.Decrypt(value[5].ToString()), data_decrypt.Decrypt(value[6].ToString()), data_decrypt.Decrypt(value[7].ToString()) };*/
                            grdShowData.Rows.Add(row);

                        }
                        grdShowData.Sort(grdShowData.Columns[0], ListSortDirection.Ascending);
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
            
        }

        private void cmbDoctors_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string doctorName = cmbDoctors.Text;
            var radioName = doctorName.ToString().Replace("'", "''");
            string get_Myconn = con_sql_mysql.getConnectionMySql();
            MySqlConnection connect = new MySqlConnection(get_Myconn);
            Mycmd = new MySqlCommand();//for selecting users 
            connect.Open();
            Mycmd = connect.CreateCommand();
            Mycmd.CommandText = "select radioDoctorId from doctors where radioName	='" + radioName + "'";
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
