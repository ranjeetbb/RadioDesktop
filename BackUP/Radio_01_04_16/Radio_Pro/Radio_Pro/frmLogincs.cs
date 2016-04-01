using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Diagnostics;
namespace Radio_Pro
{
    public partial class frmLogincs : Form
    {
        //string MyConnectionString = "Server=localhost;Database=radio;Uid=root;Pwd=root;";
        Connection_SQL_MySql con_sql_mysql = new Connection_SQL_MySql();
        public frmLogincs()
        {
            InitializeComponent();
        }

        private void frmLogincs_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            lblMsgUserPass.Text = "";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            
            
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            if (txtUserName.Text == "" || txtPassword.Text == "")
            {
                lblMsgUserPass.Text = "Please Enter User Name\nand Password !!";
            }
            else
            {
                string get_Myconn = con_sql_mysql.getConnectionMySql();
                MySqlConnection connect = new MySqlConnection(get_Myconn);
                MySqlCommand cmd;          
                try
                {
                    connect.Open();
                    cmd = connect.CreateCommand();
                    //cmd.CommandText = "insert into login(username,password) values(@username,@password)";
                    MySqlDataAdapter mad = new MySqlDataAdapter("select count(*) from admin where username='" + txtUserName.Text + "' and password='" + txtPassword.Text + "'", connect);
                    //cmd.Parameters.AddWithValue("@username",txtUserName.Text);
                    //cmd.Parameters.AddWithValue("@password",txtPassword.Text);
                    DataTable dt = new DataTable();
                    mad.Fill(dt);
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        this.Hide();
                        var frmRadioDesktop = new frmRadioDesktop();
                        frmRadioDesktop.Show();
                        //MessageBox.Show("Login successfully !");
                        ProcessStartInfo sInfo = new ProcessStartInfo("chrome.exe", "http://localhost/Test_Local_Server_Db/getelement.php");
                        Process.Start(sInfo);
                        ProcessStartInfo sInfo1 = new ProcessStartInfo("chrome.exe", "http://localhost/Test_Local_Server_Db/local_access.php");
                        Process.Start(sInfo1);
                    }
                    else
                    {
                        //MessageBox.Show("Login Invalidated !");
                        lblMsgUserPass.Text = "Login Invalidated ...";
                    }
                    //cmd.ExecuteNonQuery();                
                }
                catch (Exception)
                {
                    MessageBox.Show("Error : ");
                }
                connect.Close();
                //lblMsgUserPass.Text = "";
            }

        }
    }
}
