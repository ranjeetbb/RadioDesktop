using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.IO;
using System.Data;
using System.Windows.Forms;

namespace Radio_Pro
{
    class AreaInsert
    {
        public void AreasInsert()
        {
            //Selecting Area from radio
            Connection_SQL_MySql con_sql_mysql = new Connection_SQL_MySql();
            //Selecting Dept -->investigation from radio 
            string get_conn = con_sql_mysql.getConnectionSql();
            SqlConnection sqlCon = new SqlConnection(get_conn);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlCon;
            sqlCon.Open();      
  
            cmd.CommandText = "select * from tblAreaMaster";
          
            SqlDataAdapter da_Area = new SqlDataAdapter(cmd);
            DataTable dt_Area = new DataTable();
            da_Area.Fill(dt_Area);

            string get_Myconn = con_sql_mysql.getConnectionMySql();
            MySqlConnection connect = new MySqlConnection(get_Myconn);
            String existValue = "";
            if (dt_Area.Rows.Count > 0)
            {
                //MessageBox.Show("Found");
                //Mysql database connection

                MySqlCommand Mycmd = new MySqlCommand();
                connect.Open();
                Mycmd = connect.CreateCommand();
                foreach (DataRow row in dt_Area.Rows)
                {
                    //existValue = data_en.Encrypt(row[4].ToString());
                    existValue = (row[4].ToString());
                    //MessageBox.Show(existValue);
                    Mycmd.CommandText = "select * from MasterArea where radioAreaId='" + existValue + "'";
                    MySqlDataAdapter myda = new MySqlDataAdapter(Mycmd);
                    DataTable mydt = new DataTable();
                    myda.Fill(mydt);
                    if (mydt.Rows.Count > 0)
                    {
                        // MessageBox.Show("M Found Area Update");
                        //Mycmd.CommandText = "update MasterArea set radioAreaId ='" + data_en.Encrypt(row[4].ToString()) + "',radioArea='" + data_en.Encrypt(row[0].ToString()) + "',radioSuburb='" + data_en.Encrypt(row[1].ToString()) + "',radioCity='" + data_en.Encrypt(row[2].ToString()) + "',radioPincode='" + data_en.Encrypt(row[3].ToString()) + "' where areaId ='" + row[0].ToString() + "'";
                        Mycmd.CommandText = "update MasterArea set radioAreaId ='" + (row[4].ToString()) + "',radioArea='" + (row[0].ToString()) + "',radioSuburb='" + (row[1].ToString()) + "',radioCity='" + (row[2].ToString()) + "',radioPincode='" + (row[3].ToString()) + "' where areaId ='" + row[0].ToString() + "'";
                        Mycmd.ExecuteNonQuery();
                    }
                    else
                    {
                        // MessageBox.Show("M No Found Area Insert");
                        //Mycmd.CommandText = "INSERT INTO MasterArea(radioAreaId,radioArea,radioSuburb,radioCity,radioPincode) values('" + data_en.Encrypt(row[4].ToString()) + "','" + data_en.Encrypt(row[0].ToString()) + "','" + data_en.Encrypt(row[1].ToString()) + "','" + data_en.Encrypt(row[2].ToString()) + "','" + data_en.Encrypt(row[3].ToString()) + "')";
                        Mycmd.CommandText = "INSERT INTO MasterArea(radioAreaId,radioArea,radioSuburb,radioCity,radioPincode) values('" + (row[4].ToString()) + "','" + (row[0].ToString()) + "','" + (row[1].ToString()) + "','" + (row[2].ToString()) + "','" + (row[3].ToString()) + "')";
                        Mycmd.ExecuteNonQuery();
                    }
                }
                connect.Close();
            }
            else
            {
                MessageBox.Show("No New Area Found");
            }
            sqlCon.Close();
        }
    }
}
