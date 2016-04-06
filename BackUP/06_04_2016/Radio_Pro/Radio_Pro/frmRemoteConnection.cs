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
    public partial class frmRemoteConnection : Form
    {
        public frmRemoteConnection()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //try
            //{
            string MyConnectionString = "Server=192.168.0.109:8081; Database=radio; Uid=root; Pwd=12345; Pooling=false;";
                MySqlConnection con = new MySqlConnection(MyConnectionString);
                MySqlCommand cmd = new MySqlCommand();
                con.Open();
                MessageBox.Show("Conect");
                cmd = con.CreateCommand();
                cmd.CommandText = "insert into admin(username,password) values('r','r');";
                cmd.ExecuteNonQuery();
                con.Close();
            //}
            //catch (Exception ex)
            //{
                //MessageBox.Show("Error "+ex);
           // }
        }
    }
}
