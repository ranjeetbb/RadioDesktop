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
    class Connection_SQL_MySql
    {
        public string getConnectionSql()
        {
            //for MySQL connection
            string connectionString = "Data Source=ADMIN;Initial Catalog=radio;Integrated Security=True;";
            //string connectionString = "Data Source=RANJEETBB;Initial Catalog=radio;Integrated Security=True;";
            return connectionString;
        }

        public string getConnectionMySql()
        {
            //for MySQL connection
            string MyConnectionString = "Server=localhost;Database=radio;Uid=root;Pwd='';";
            //string MyConnectionString = "Server=localhost;Database=radio;Uid=root;Pwd=root;";
            return MyConnectionString;
        }
    }
}
