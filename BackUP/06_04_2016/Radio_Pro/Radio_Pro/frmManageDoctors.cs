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
    public partial class frmManageDoctors : Form
    {
        //for MySQL connection
        string MyConnectionString = "Server=localhost;Database=radio;Uid=root;Pwd=root;";     
        MySqlDataAdapter mydack;
        DataTable mydt;
        MySqlConnection connect;
        MySqlCommand Mycmd;
        int i;
        public frmManageDoctors()
        {
            InitializeComponent();
        }

        private void frmManageDoctors_Load(object sender, EventArgs e)
        {
            grdManagesDoctor.ColumnCount = 8;
            grdManagesDoctor.Columns[0].Name = "Dr Code";
            grdManagesDoctor.Columns[1].Name = "Dr Name";
            grdManagesDoctor.Columns[2].Name = "Address";
            grdManagesDoctor.Columns[3].Name = "Ph Res";
            grdManagesDoctor.Columns[4].Name = "Ph Off";
            grdManagesDoctor.Columns[5].Name = "Mobile";
            grdManagesDoctor.Columns[6].Name = "Primary Contact";
            grdManagesDoctor.Columns[7].Name = "Secondry Contact";
            grdManagesDoctor.Columns[0].ReadOnly = true;
            grdManagesDoctor.Columns[1].ReadOnly = true;
            grdManagesDoctor.Columns[2].ReadOnly = true;
            grdManagesDoctor.Columns[3].ReadOnly = true;
            grdManagesDoctor.Columns[4].ReadOnly = true;
            grdManagesDoctor.Columns[5].ReadOnly = true;
            //grdManagesDoctor.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
           // grdManagesDoctor.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //grdManagesDoctor.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
               connect = new MySqlConnection(MyConnectionString);
               connect.Open();
                Mycmd = connect.CreateCommand();
                Mycmd.CommandText = "select * from vwPtDetsWithRefDrAndAddresses";
                mydack = new MySqlDataAdapter(Mycmd);
                mydt = new DataTable();
                mydack.Fill(mydt);
                string[] row;
                foreach (DataRow value in mydt.Rows)
                {
                    Data_Decryptioncs data_decrypt = new Data_Decryptioncs();
                    row = new string[] { data_decrypt.Decrypt(value[0].ToString()), data_decrypt.Decrypt(value[1].ToString()), data_decrypt.Decrypt(value[2].ToString()), data_decrypt.Decrypt(value[3].ToString()), data_decrypt.Decrypt(value[4].ToString()), data_decrypt.Decrypt(value[5].ToString()) };
                    grdManagesDoctor.Rows.Add(row);
                   
                }
   
        }
      
        private void btnUpdateInfo_Click(object sender, EventArgs e)
        {
            i= grdManagesDoctor.CurrentCell.RowIndex;
            //MessageBox.Show("rows : " + i);
            Data_Encryption data_en = new Data_Encryption();
            DataGridViewRow row = grdManagesDoctor.Rows[i];
            string dr_code = data_en.Encrypt(row.Cells[0].Value.ToString()); 
            string dr_name = data_en.Encrypt(row.Cells[1].Value.ToString());
            string dr_address = data_en.Encrypt(row.Cells[2].Value.ToString());
            string phres = data_en.Encrypt(row.Cells[3].Value.ToString());
            string phoff = data_en.Encrypt(row.Cells[4].Value.ToString());
            string mobile = data_en.Encrypt(row.Cells[5].Value.ToString());
            string dr_compulsry = (row.Cells[6].Value ?? string.Empty ).ToString();
            string dr_primary = (row.Cells[7].Value ?? string.Empty).ToString();

             Mycmd = connect.CreateCommand();
             if (dr_compulsry != "" && dr_primary != "")
             {
                 dr_compulsry = data_en.Encrypt(dr_compulsry);
                 dr_primary = data_en.Encrypt(dr_primary);
                 Mycmd.CommandText = "insert into doct_manage(Dr_code,Dr_name,Dr_address,PhRes,PhOff,Mobile,Primary_contc,Sec_contc) values('" + dr_code + "','" + dr_name + "','" + dr_address + "','" + phres + "','" + phoff + "','" + mobile + "','" + dr_compulsry + "','" + dr_primary + "')";
                 Mycmd.ExecuteNonQuery();

                 MessageBox.Show("Excecuted successfully ..!");
             }
             
                 
             
        }

        private void btnViewUpdate_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmUpdatedDoctorscs updr=new frmUpdatedDoctorscs();
            updr.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void grdManagesDoctor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
