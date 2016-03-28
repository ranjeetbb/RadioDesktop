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
        MySqlCommand Mycmd;
        public frmMangeUsers()
        {

            InitializeComponent();
           txtContact.KeyPress += new KeyPressEventHandler(txtContact_KeyPress);
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "" || txtContact.Text == "" || cmbDeviceId.Text=="")
            {
                MessageBox.Show("Please Enter all fields ");
            }
            else if (txtContact.Text.Length != 10)
            {
                MessageBox.Show("Enter Valida contact");
            }
            else
            {
                string get_Myconn = con_sql_mysql.getConnectionMySql();
                MySqlConnection connect = new MySqlConnection(get_Myconn);
                Mycmd = new MySqlCommand();
                connect.Open();
                Mycmd = connect.CreateCommand();
                Mycmd.CommandText = "insert into users(userName,primContact,deviceId) values('" + txtUserName.Text + "','" + txtContact.Text + "','" + cmbDeviceId.Text + "');update serverlocation set status=1 where deviceId='" + cmbDeviceId.Text + "'";
                Mycmd.ExecuteNonQuery();
                connect.Close();
                MessageBox.Show("Account Created Successfully");
                txtContact.Text = "";
                txtUserName.Text = "";
                cmbDeviceId.Items.Clear();
                add_deviceID();
            }
        }

        private void frmMangeUsers_Load(object sender, EventArgs e)
        {
            add_deviceID();
        }

        private void add_deviceID()
        {
            cmbDeviceId.DropDownStyle = ComboBoxStyle.DropDownList;
            string get_Myconn = con_sql_mysql.getConnectionMySql();
            MySqlConnection connect = new MySqlConnection(get_Myconn);
            Mycmd = new MySqlCommand();//for selecting users 
            connect.Open();
            Mycmd = connect.CreateCommand();
            Mycmd.CommandText = "select deviceId from serverlocation where status=0";
            MySqlDataAdapter myda = new MySqlDataAdapter(Mycmd);
            DataTable mydt = new DataTable();
            myda.Fill(mydt);
            if (mydt.Rows.Count > 0)
            {
                // MessageBox.Show("Users Found");
                foreach (DataRow row in mydt.Rows)
                {
                    //MessageBox.Show("Users Found"+row[1].ToString());
                    cmbDeviceId.Items.Add(row[0].ToString());
                }
            }          
        
        }
        private void txtContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8) //The  character represents a backspace
            {
                e.Handled = true; //Do not reject the input
            }     
        }
    }
}
