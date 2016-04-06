using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.IO;
namespace Radio_Pro
{
    public partial class frmUpdatedDoctorscs : Form
    {
        //for MySQL connection
        //string MyConnectionString = "Server=localhost;Database=radio;Uid=root;Pwd=root;";  
        Connection_SQL_MySql con_sql_mysql = new Connection_SQL_MySql();
        MySqlDataAdapter mydack;
        DataTable mydt;
        MySqlConnection connect;
        MySqlCommand Mycmd;
        string tbl_id="";
        int i;
        public frmUpdatedDoctorscs()
        {
            InitializeComponent();
        }

        private void btnUpdateClose_Click(object sender, EventArgs e)
        {
            this.Hide();
            //frmManageDoctors dctr = new frmManageDoctors();
           // dctr.Show();
        }

        private void frmUpdatedDoctorscs_Load(object sender, EventArgs e)
        {
            grdManagesDoctor.ColumnCount = 13;
            grdManagesDoctor.Columns[0].Name = "Key";
            grdManagesDoctor.Columns[1].Name = "Title";
            grdManagesDoctor.Columns[2].Name = "Dr Code";
            grdManagesDoctor.Columns[3].Name = "Dr Name";
            grdManagesDoctor.Columns[4].Name = "Address";
            grdManagesDoctor.Columns[5].Name = "Ph Res";
            grdManagesDoctor.Columns[6].Name = "Ph Off";
            grdManagesDoctor.Columns[7].Name = "Mobile";
            grdManagesDoctor.Columns[8].Name = "Fax";
            grdManagesDoctor.Columns[9].Name = "Category";
            grdManagesDoctor.Columns[10].Name = "Area";
            grdManagesDoctor.Columns[11].Name = "Primary Contact";
            grdManagesDoctor.Columns[12].Name = "Secondry Contact";

            grdManagesDoctor.Columns[0].Visible = false;
            grdManagesDoctor.Columns[8].Visible = false;
            grdManagesDoctor.Columns[5].Visible = false;
            grdManagesDoctor.Columns[6].Visible = false;
            grdManagesDoctor.Columns[2].Visible = false;

            grdManagesDoctor.Columns[1].ReadOnly = true;
            grdManagesDoctor.Columns[2].ReadOnly = true;
            grdManagesDoctor.Columns[3].ReadOnly = true;
            grdManagesDoctor.Columns[4].ReadOnly = true;
            grdManagesDoctor.Columns[5].ReadOnly = true;
            grdManagesDoctor.Columns[6].ReadOnly = true;
            grdManagesDoctor.Columns[7].ReadOnly = true;
            grdManagesDoctor.Columns[8].ReadOnly = true;
            grdManagesDoctor.Columns[9].ReadOnly = true;
            grdManagesDoctor.Columns[10].ReadOnly = true;
            string get_Myconn = con_sql_mysql.getConnectionMySql();
            connect = new MySqlConnection(get_Myconn);
            connect.Open();
            Mycmd = connect.CreateCommand();
            Mycmd.CommandText = "select * from doctors";

            mydack = new MySqlDataAdapter(Mycmd);
            mydt = new DataTable();
            mydack.Fill(mydt);

            string[] row;
          
            foreach (DataRow value in mydt.Rows)
            {
                Data_Decryptioncs data_decrypt = new Data_Decryptioncs();
                //row = new string[] { data_decrypt.Decrypt(value[0].ToString()) };
               // MessageBox.Show(value[0].ToString());
                tbl_id = value[0].ToString();
                //row = new string[] { value[0].ToString(),data_decrypt.Decrypt(value[1].ToString()), data_decrypt.Decrypt(value[2].ToString()), data_decrypt.Decrypt(value[3].ToString()), data_decrypt.Decrypt(value[4].ToString()), data_decrypt.Decrypt(value[5].ToString()), data_decrypt.Decrypt(value[6].ToString()), data_decrypt.Decrypt(value[7].ToString()), data_decrypt.Decrypt(value[8].ToString()) };
                row = new string[] { value[0].ToString(), (value[1].ToString()), (value[2].ToString()), (value[3].ToString()), (value[4].ToString()), (value[5].ToString()), (value[6].ToString()), (value[7].ToString()), (value[8].ToString()), (value[9].ToString()), (value[10].ToString()), (value[11].ToString()), (value[12].ToString()) };
                /*row = new string[] { data_decrypt.Decrypt(value[0].ToString()), data_decrypt.Decrypt(value[1].ToString()), data_decrypt.Decrypt(value[2].ToString()), data_decrypt.Decrypt(value[3].ToString()), data_decrypt.Decrypt(value[4].ToString())
                    , data_decrypt.Decrypt(value[5].ToString()), data_decrypt.Decrypt(value[6].ToString()), data_decrypt.Decrypt(value[7].ToString()) };*/
                grdManagesDoctor.Rows.Add(row);

            }
            grdManagesDoctor.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }
       
        private void btnUpdateContact_Click(object sender, EventArgs e)
        {
            Data_Encryption data_en = new Data_Encryption();
            i = grdManagesDoctor.CurrentCell.RowIndex;
            DataGridViewRow row = grdManagesDoctor.Rows[i];
            string tbl_id = (row.Cells[0].Value ?? string.Empty).ToString(); 
            string dr_compulsry = (row.Cells[11].Value ?? string.Empty).ToString();
            string dr_primary = (row.Cells[12].Value ?? string.Empty).ToString();
           //MessageBox.Show(tbl_id);
            long num1,num2;
            bool digit1 = Int64.TryParse(dr_compulsry, out num1);
            bool digit2 = Int64.TryParse(dr_primary, out num2);
            Mycmd = connect.CreateCommand();
            if (!digit1)
            {
                MessageBox.Show("Enter number only  !");
            }
            else
            {
                long contact = Convert.ToInt64(dr_compulsry);
                if (contact.ToString().Length != 10)
                {
                    MessageBox.Show("Enter valid contact !");
                }
                else
                {
                    //dr_compulsry = data_en.Encrypt(dr_compulsry);
                    //dr_primary = data_en.Encrypt(dr_primary);
                    Mycmd.CommandText = "update doctors set alternateMobile1='" + dr_compulsry + "',alternateMobile2='" + dr_primary + "' where doctorId='" + tbl_id + "'";
                    //INSERT INTO doctors(radioTitle,radioDoctorId,radioName,radioAddress,radioPhoneRes,radioPhoneOffice,radioPhoneMobile,radioFax,radioCategory,areaId,alternateMobile1,alternateMobile2) values('" + (row1[0].ToString()) + "','" + (row1[1].ToString()) + "','" + value + "','" + (row1[3].ToString()) + "','" + (row1[4].ToString()) + "','" + (row1[5].ToString()) + "','" + (row1[6].ToString()) + "','" + (row1[7].ToString()) + "','" + (row1[8].ToString()) + "','" + (row1[9].ToString()) + "','0000000000','0000000000')";
                    Mycmd.ExecuteNonQuery();
                    MessageBox.Show("Update successfully ..!");
                }
            }
            Mycmd = connect.CreateCommand();
            if (!digit2)
            {
                MessageBox.Show("Enter number only  !");
            }
            else
            {
                long contact2 = Convert.ToInt64(dr_primary);
                if (contact2.ToString().Length != 10)
                {
                    MessageBox.Show("Enter valid contact !");
                }
                else
                {
                    //dr_compulsry = data_en.Encrypt(dr_compulsry);
                    //dr_primary = data_en.Encrypt(dr_primary);
                    Mycmd.CommandText = "update doctors set alternateMobile1='" + dr_compulsry + "',alternateMobile2='" + dr_primary + "' where doctorId='" + tbl_id + "'";
                    //INSERT INTO doctors(radioTitle,radioDoctorId,radioName,radioAddress,radioPhoneRes,radioPhoneOffice,radioPhoneMobile,radioFax,radioCategory,areaId,alternateMobile1,alternateMobile2) values('" + (row1[0].ToString()) + "','" + (row1[1].ToString()) + "','" + value + "','" + (row1[3].ToString()) + "','" + (row1[4].ToString()) + "','" + (row1[5].ToString()) + "','" + (row1[6].ToString()) + "','" + (row1[7].ToString()) + "','" + (row1[8].ToString()) + "','" + (row1[9].ToString()) + "','0000000000','0000000000')";
                    Mycmd.ExecuteNonQuery();
                    MessageBox.Show("Update successfully ..!");
                }
            }
             
         }
        private void grdManagesDoctor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.grdManagesDoctor.CellEnter += new DataGridViewCellEventHandler(grdManagesDoctor_CellEnter);
        
        }
        void grdManagesDoctor_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if ((this.grdManagesDoctor.Columns[e.ColumnIndex] is DataGridViewTextBoxColumn) ||
                (this.grdManagesDoctor.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn))
            {
                this.grdManagesDoctor.BeginEdit(true);
            }
        }
           
        }
        
}

