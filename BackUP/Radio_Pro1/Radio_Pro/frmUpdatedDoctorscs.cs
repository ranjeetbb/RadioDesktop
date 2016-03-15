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
        string MyConnectionString = "Server=localhost;Database=radio;Uid=root;Pwd=root;";     
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
            frmManageDoctors dctr = new frmManageDoctors();
            dctr.Show();
        }

        private void frmUpdatedDoctorscs_Load(object sender, EventArgs e)
        {
            grdManagesDoctor.ColumnCount = 9;
            grdManagesDoctor.Columns[0].Name = "Key";
            grdManagesDoctor.Columns[1].Name = "Dr Code";
            grdManagesDoctor.Columns[2].Name = "Dr Name";
            grdManagesDoctor.Columns[3].Name = "Address";
            grdManagesDoctor.Columns[4].Name = "Ph Res";
            grdManagesDoctor.Columns[5].Name = "Ph Off";
            grdManagesDoctor.Columns[6].Name = "Mobile";
            grdManagesDoctor.Columns[7].Name = "Primary Contact";
            grdManagesDoctor.Columns[8].Name = "Secondry Contact";
            grdManagesDoctor.Columns[0].Visible = false;
            
            connect = new MySqlConnection(MyConnectionString);
            connect.Open();
            Mycmd = connect.CreateCommand();
            Mycmd.CommandText = "select * from doct_manage";

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
                row = new string[] { value[0].ToString(),data_decrypt.Decrypt(value[1].ToString()), data_decrypt.Decrypt(value[2].ToString()), data_decrypt.Decrypt(value[3].ToString()), data_decrypt.Decrypt(value[4].ToString()), data_decrypt.Decrypt(value[5].ToString()), data_decrypt.Decrypt(value[6].ToString()), data_decrypt.Decrypt(value[7].ToString()), data_decrypt.Decrypt(value[8].ToString()) };
                /*row = new string[] { data_decrypt.Decrypt(value[0].ToString()), data_decrypt.Decrypt(value[1].ToString()), data_decrypt.Decrypt(value[2].ToString()), data_decrypt.Decrypt(value[3].ToString()), data_decrypt.Decrypt(value[4].ToString())
                    , data_decrypt.Decrypt(value[5].ToString()), data_decrypt.Decrypt(value[6].ToString()), data_decrypt.Decrypt(value[7].ToString()) };*/
                grdManagesDoctor.Rows.Add(row);

            }
        }

        private void btnUpdateContact_Click(object sender, EventArgs e)
        {
            Data_Encryption data_en = new Data_Encryption();
            i = grdManagesDoctor.CurrentCell.RowIndex;
            DataGridViewRow row = grdManagesDoctor.Rows[i];
            string tbl_id = (row.Cells[0].Value ?? string.Empty).ToString(); 
            string dr_compulsry = (row.Cells[7].Value ?? string.Empty).ToString();
            string dr_primary = (row.Cells[8].Value ?? string.Empty).ToString();
            //MessageBox.Show(tbl_id);
            Mycmd = connect.CreateCommand();
            if (dr_compulsry != "" && dr_primary != "")
            {
                dr_compulsry = data_en.Encrypt(dr_compulsry);
                dr_primary = data_en.Encrypt(dr_primary);
                Mycmd.CommandText = "update doct_manage set Primary_contc='" + dr_compulsry + "',Sec_contc='" + dr_primary + "' where tbl_id='" + tbl_id + "'";
                Mycmd.ExecuteNonQuery();

                MessageBox.Show("Excecuted successfully ..!");
            }            
        }
    }
}
