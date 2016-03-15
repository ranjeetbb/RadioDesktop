using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace Radio_Pro
{
    public partial class frmMangeUsers : Form
    {
        //for MySQL connection
        //string MyConnectionString = "Server=localhost;Database=radio;Uid=root;Pwd=root;";
        Connection_SQL_MySql con_sql_mysql = new Connection_SQL_MySql();
        public frmMangeUsers()
        {
            InitializeComponent();
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "" || txtContact.Text == "" || cmbDeviceId.Text=="")
            {
                MessageBox.Show("Please Enter all fields ");
            }            
            else
            {
                string get_Myconn = con_sql_mysql.getConnectionMySql();
                MySqlConnection connect = new MySqlConnection(get_Myconn);
                MySqlCommand Mycmd = new MySqlCommand();
                connect.Open();
                Mycmd = connect.CreateCommand();
                Mycmd.CommandText = "insert into users(userName,primContact,deviceId) values('" + txtUserName.Text + "','" + txtContact.Text + "','" + cmbDeviceId.Text + "')";
                Mycmd.ExecuteNonQuery();
                connect.Close();
                MessageBox.Show("Account Created Successfully");
            }
        }

        private void frmMangeUsers_Load(object sender, EventArgs e)
        {
            cmbDeviceId.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDeviceId.Items.Add("1001");
            cmbDeviceId.Items.Add("1002");
            cmbDeviceId.Items.Add("1003");
        }


        private void txtContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
