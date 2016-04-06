using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.IO;
namespace Radio_Pro
{
    public partial class frmRadioDesktop : Form
    {
        //for connection
        Connection_SQL_MySql con_sql_mysql = new Connection_SQL_MySql();
        public frmRadioDesktop()
        {
            InitializeComponent();
        }
        Data_Encryption data_en = new Data_Encryption();
        Data_Decryptioncs data_decrypt = new Data_Decryptioncs();   
        MySqlCommand Mycmd;  
        private void frmRadioDesktop_Load(object sender, EventArgs e)
        {
            displayAll();
            displayPending();
            displayRejected();
            displayAccepted();
        }
        private void frmRadioDesktop_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (e.Cancel = true)
            {
                // Display a MsgBox asking the user to save changes or abort.
                if (MessageBox.Show("Do you want to save changes to your text?", "My Application",
                   MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    // Cancel the Closing event from closing the form.
                    e.Cancel = true;
                    // Call method to save file...
                }
            }
            
        }
        private void fetchRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var pullData = new frmFetchData();
            pullData.Show();
        }

        private void frmRadioDesktop_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void manageDoctorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmUpdatedDoctorscs updr = new frmUpdatedDoctorscs();
            updr.Show();
        }

        private void manageUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMangeUsers maguser = new frmMangeUsers();
            maguser.Show();
        }

        private void trackToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //ProcessStartInfo sInfo = new ProcessStartInfo("chrome.exe", "http://localhost/Test_Local_Server_Db/getelement.php");
            //Process.Start(sInfo);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            frmAssignData data = new frmAssignData();
            data.Show();
        }

        private void btnFetchData_Click(object sender, EventArgs e)
        {
            var pullData = new frmFetchData();
            pullData.Show();
        }

        private void btnAssignData_Click(object sender, EventArgs e)
        {
            frmAssignData data = new frmAssignData();
            data.Show();
        }
        private void displayAll()
        {
            string get_Myconn = con_sql_mysql.getConnectionMySql();
            MySqlConnection connect = new MySqlConnection(get_Myconn);
            Mycmd = new MySqlCommand();//for selecting users 
            connect.Open();
            Mycmd = connect.CreateCommand();
            Mycmd.CommandText = "select radioPatientRptDate,radioPatientsId,radioPatientsName,radioDoctorId,radioName,cut,invest,deviceId,userName,status from csvfile";
            Mycmd.ExecuteNonQuery();
            MySqlDataAdapter mydaCsvFile = new MySqlDataAdapter(Mycmd);
            DataTable mydtCsvFile = new DataTable();
            mydaCsvFile.Fill(mydtCsvFile);
            //grdDisplayAll.DataSource = mydtCsvFile;
            if (mydtCsvFile.Rows.Count > 0)
            {

                grdDisplayAll.ColumnCount = 10;
                grdDisplayAll.Columns[0].Name = "Date";
                grdDisplayAll.Columns[1].Name = "Pt ID";
                grdDisplayAll.Columns[2].Name = "Patients Name";
                grdDisplayAll.Columns[3].Name = "Dr ID";
                grdDisplayAll.Columns[4].Name = "Dr Name";
                grdDisplayAll.Columns[5].Name = "IP";
                grdDisplayAll.Columns[6].Name = "Investigation";
                grdDisplayAll.Columns[7].Name = "Device";
                grdDisplayAll.Columns[8].Name = "User Name";
                grdDisplayAll.Columns[9].Name = "Status";

                grdDisplayAll.Columns[0].ReadOnly = true;
                grdDisplayAll.Columns[1].ReadOnly = true;
                grdDisplayAll.Columns[2].ReadOnly = true;
                grdDisplayAll.Columns[3].ReadOnly = true;
                grdDisplayAll.Columns[4].ReadOnly = true;
                grdDisplayAll.Columns[5].ReadOnly = true;
                grdDisplayAll.Columns[6].ReadOnly = true;
                grdDisplayAll.Columns[7].ReadOnly = true;
                grdDisplayAll.Columns[8].ReadOnly = true;
                grdDisplayAll.Columns[9].ReadOnly = true;

                grdDisplayAll.Columns[1].Visible = false;
                grdDisplayAll.Columns[3].Visible = false;
                grdDisplayAll.Columns[7].Visible = false;

                grdDisplayAll.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                grdDisplayAll.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
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
                    grdDisplayAll.Rows.Add(row1);

                }
            }
        
        }
        private void displayRejected()
        {
            string get_Myconn = con_sql_mysql.getConnectionMySql();
            MySqlConnection connect = new MySqlConnection(get_Myconn);
            Mycmd = new MySqlCommand();//for selecting users 
            connect.Open();
            Mycmd = connect.CreateCommand();
            Mycmd.CommandText = "select radioPatientRptDate,radioPatientsId,radioPatientsName,radioDoctorId,radioName,cut,invest,deviceId,userName,status from csvfile where status=2";
            Mycmd.ExecuteNonQuery();
            MySqlDataAdapter mydaCsvFile = new MySqlDataAdapter(Mycmd);
            DataTable mydtCsvFile = new DataTable();
            mydaCsvFile.Fill(mydtCsvFile);
            //dataGridView1.DataSource = mydtCsvFile;
            if (mydtCsvFile.Rows.Count > 0)
            {

                dataGridView1.ColumnCount = 10;
                dataGridView1.Columns[0].Name = "Date";
                dataGridView1.Columns[1].Name = "Pt ID";
                dataGridView1.Columns[2].Name = "Patients Name";
                dataGridView1.Columns[3].Name = "Dr ID";
                dataGridView1.Columns[4].Name = "Dr Name";
                dataGridView1.Columns[5].Name = "IP";
                dataGridView1.Columns[6].Name = "Investigation";
                dataGridView1.Columns[7].Name = "Device";
                dataGridView1.Columns[8].Name = "User Name";
                dataGridView1.Columns[9].Name = "Status";

                dataGridView1.Columns[0].ReadOnly = true;
                dataGridView1.Columns[1].ReadOnly = true;
                dataGridView1.Columns[2].ReadOnly = true;
                dataGridView1.Columns[3].ReadOnly = true;
                dataGridView1.Columns[4].ReadOnly = true;
                dataGridView1.Columns[5].ReadOnly = true;
                dataGridView1.Columns[6].ReadOnly = true;
                dataGridView1.Columns[7].ReadOnly = true;
                dataGridView1.Columns[8].ReadOnly = true;
                dataGridView1.Columns[9].ReadOnly = true;

                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[7].Visible = false;

                dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
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
                    dataGridView1.Rows.Add(row1);

                }
            }

        }
        private void displayPending()
        {
            string get_Myconn = con_sql_mysql.getConnectionMySql();
            MySqlConnection connect = new MySqlConnection(get_Myconn);
            Mycmd = new MySqlCommand();//for selecting users 
            connect.Open();
            Mycmd = connect.CreateCommand();
            Mycmd.CommandText = "select radioPatientRptDate,radioPatientsId,radioPatientsName,radioDoctorId,radioName,cut,invest,deviceId,userName,status from csvfile where status=0";
            Mycmd.ExecuteNonQuery();
            MySqlDataAdapter mydaCsvFile = new MySqlDataAdapter(Mycmd);
            DataTable mydtCsvFile = new DataTable();
            mydaCsvFile.Fill(mydtCsvFile);
            //grdDisplayPending.DataSource = mydtCsvFile;
            if (mydtCsvFile.Rows.Count > 0)
            {

                grdDisplayPending.ColumnCount = 10;
                grdDisplayPending.Columns[0].Name = "Date";
                grdDisplayPending.Columns[1].Name = "Pt ID";
                grdDisplayPending.Columns[2].Name = "Patients Name";
                grdDisplayPending.Columns[3].Name = "Dr ID";
                grdDisplayPending.Columns[4].Name = "Dr Name";
                grdDisplayPending.Columns[5].Name = "IP";
                grdDisplayPending.Columns[6].Name = "Investigation";
                grdDisplayPending.Columns[7].Name = "Device";
                grdDisplayPending.Columns[8].Name = "User Name";
                grdDisplayPending.Columns[9].Name = "Status";

                grdDisplayPending.Columns[0].ReadOnly = true;
                grdDisplayPending.Columns[1].ReadOnly = true;
                grdDisplayPending.Columns[2].ReadOnly = true;
                grdDisplayPending.Columns[3].ReadOnly = true;
                grdDisplayPending.Columns[4].ReadOnly = true;
                grdDisplayPending.Columns[5].ReadOnly = true;
                grdDisplayPending.Columns[6].ReadOnly = true;
                grdDisplayPending.Columns[7].ReadOnly = true;
                grdDisplayPending.Columns[8].ReadOnly = true;
                grdDisplayPending.Columns[9].ReadOnly = true;

                grdDisplayPending.Columns[1].Visible = false;
                grdDisplayPending.Columns[3].Visible = false;
                grdDisplayPending.Columns[7].Visible = false;
                grdDisplayPending.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                grdDisplayPending.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
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
                    grdDisplayPending.Rows.Add(row1);

                }
            }

        }
        private void displayAccepted()
        {
            string get_Myconn = con_sql_mysql.getConnectionMySql();
            MySqlConnection connect = new MySqlConnection(get_Myconn);
            Mycmd = new MySqlCommand();//for selecting users 
            connect.Open();
            Mycmd = connect.CreateCommand();
            Mycmd.CommandText = "select radioPatientRptDate,radioPatientsId,radioPatientsName,radioDoctorId,radioName,cut,invest,deviceId,userName,status from csvfile where status=1";
            Mycmd.ExecuteNonQuery();
            MySqlDataAdapter mydaCsvFile = new MySqlDataAdapter(Mycmd);
            DataTable mydtCsvFile = new DataTable();
            mydaCsvFile.Fill(mydtCsvFile);
            //grdDisplayAccepted.DataSource = mydtCsvFile;
            if (mydtCsvFile.Rows.Count > 0)
            {

                grdDisplayAccepted.ColumnCount = 10;
                grdDisplayAccepted.Columns[0].Name = "Date";
                grdDisplayAccepted.Columns[1].Name = "Pt ID";
                grdDisplayAccepted.Columns[2].Name = "Patients Name";
                grdDisplayAccepted.Columns[3].Name = "Dr ID";
                grdDisplayAccepted.Columns[4].Name = "Dr Name";
                grdDisplayAccepted.Columns[5].Name = "IP";
                grdDisplayAccepted.Columns[6].Name = "Investigation";
                grdDisplayAccepted.Columns[7].Name = "Device";
                grdDisplayAccepted.Columns[8].Name = "User Name";
                grdDisplayAccepted.Columns[9].Name = "Status";

                grdDisplayAccepted.Columns[0].ReadOnly = true;
                grdDisplayAccepted.Columns[1].ReadOnly = true;
                grdDisplayAccepted.Columns[2].ReadOnly = true;
                grdDisplayAccepted.Columns[3].ReadOnly = true;
                grdDisplayAccepted.Columns[4].ReadOnly = true;
                grdDisplayAccepted.Columns[5].ReadOnly = true;
                grdDisplayAccepted.Columns[6].ReadOnly = true;
                grdDisplayAccepted.Columns[7].ReadOnly = true;
                grdDisplayAccepted.Columns[8].ReadOnly = true;
                grdDisplayAccepted.Columns[9].ReadOnly = true;

                grdDisplayAccepted.Columns[1].Visible = false;
                grdDisplayAccepted.Columns[3].Visible = false;
                grdDisplayAccepted.Columns[7].Visible = false;
                grdDisplayAccepted.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                grdDisplayAccepted.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
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
                    grdDisplayAccepted.Rows.Add(row1);

                }
            }

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }
        

        private void btnManageDoctors_Click(object sender, EventArgs e)
        {
            frmUpdatedDoctorscs doctordata = new frmUpdatedDoctorscs();
            doctordata.Show();
        }

        private void btnTrackUsers_Click(object sender, EventArgs e)
        {
            frmTrackUsers trac = new frmTrackUsers();
            trac.Show();
        }

        private void btnRefress_Click(object sender, EventArgs e)
        {
            grdDisplayAll.Rows.Clear();
            grdDisplayAccepted.Rows.Clear();
            grdDisplayPending.Rows.Clear();
            dataGridView1.Rows.Clear();
            displayAll();
            displayPending();
            displayRejected();
            displayAccepted();
            string drId = "", flag = "";
            string get_Myconn = con_sql_mysql.getConnectionMySql();
            MySqlConnection connect = new MySqlConnection(get_Myconn);
            Mycmd = new MySqlCommand();//for selecting users 
            connect.Open();
            Mycmd = connect.CreateCommand();
            Mycmd.CommandText = "select doctorId,flag from doctormobilenumber";
            Mycmd.ExecuteNonQuery();
            MySqlDataAdapter mydaTrans = new MySqlDataAdapter(Mycmd);
            DataTable mydtTrans = new DataTable();
            mydaTrans.Fill(mydtTrans);
            if (mydtTrans.Rows.Count > 0)
            {
                string csvDrId = "", csvDrName = "";
                Mycmd = connect.CreateCommand();
                foreach (DataRow trID in mydtTrans.Rows)
                {
                    drId = trID[0].ToString();
                    flag = trID[1].ToString();
                    Mycmd.CommandText = "select radioDoctorId,radioName from  csvfile where radioDoctorId ='" + drId + "' and status=0";
                    Mycmd.ExecuteNonQuery();
                    MySqlDataAdapter mydaDrID = new MySqlDataAdapter(Mycmd);
                    DataTable mydtDrId = new DataTable();
                    mydaDrID.Fill(mydtDrId);
                   
                    if (mydtDrId.Rows.Count > 0)
                    {
                        Mycmd = connect.CreateCommand();
                        foreach (DataRow chekDr in mydtDrId.Rows)
                        {
                            csvDrId = chekDr[0].ToString();
                            csvDrName = chekDr[1].ToString();
                            Mycmd.CommandText = "update csvfile set status='" + flag + "' where radioDoctorId='" + chekDr[0].ToString() + "' and status in(0);";
                            Mycmd.ExecuteNonQuery();
                        }
                        Mycmd = connect.CreateCommand();
                        Mycmd.CommandText = "insert into doctorhistory(DrID,DrName,DrResponse)values('" + csvDrId + "','" + csvDrName + "','" + flag + "');delete from doctormobilenumber where doctorId='" + csvDrId + "'";
                        Mycmd.ExecuteNonQuery();
                    }
                }
               
            }
            connect.Close();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        Dictionary<string, string> GetTablesAndSQL()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            foreach (DataGridViewRow dgvr in dataGridView1.Rows)
            {
                if (!Convert.ToBoolean(dgvr.Cells[0].Value))
                    continue;

                string table = dgvr.Cells[1].Value.ToString();
                string sql = "";
                if (dgvr.Cells[2].Value + "" == "")
                    sql = "SELECT * FROM `" + table + "`;";
                else
                    sql = dgvr.Cells[2].Value.ToString();

                dic.Add(table, sql);
            }
            return dic;
        }
        private void btnBackUp_Click(object sender, EventArgs e)
        {
           
        }

        private void backUPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string file = "";
            SaveFileDialog f = new SaveFileDialog();
            f.Filter = "SQL Dump File (*.sql)|*.sql|All files (*.*)|*.*";
            f.FileName = "New Backup " + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".sql";
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                file = f.FileName;
            }
            else
                return;
            Dictionary<string, string> dic = GetTablesAndSQL();


            MySqlBackup mb = new MySqlBackup("Server=localhost;Database=radio;Uid=root;Pwd='';");
            //mb.BackupRowsData = cbRows.Checked;
            //mb.BackupTableStructure = cbTable.Checked;
            //mb.EnableEncryption = cbEncrypt.Checked;
            //mb.EncryptionKey = txtKey.Text.Trim();
            mb.Export(file, dic);
            mb = null;
            MessageBox.Show("BackUp Done");
        }

        private void recordToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void trackUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTrackUsers trac = new frmTrackUsers();
            trac.Show();
        }

        private void doctorsHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDoctorHistory doctHist = new frmDoctorHistory();
            doctHist.Show();
        }

        private void btnReAssign_Click(object sender, EventArgs e)
        {
            frmReAssign reAss = new frmReAssign();
            reAss.Show();
        }    
    }
}
