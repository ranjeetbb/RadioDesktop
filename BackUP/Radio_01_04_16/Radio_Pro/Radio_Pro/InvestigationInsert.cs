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
    class InvestigationInsert
    {
        public void investigationInsert()
        {
            Data_Encryption data_en = new Data_Encryption();            //code for encryption and decryption
            Data_Decryptioncs data_decrypt = new Data_Decryptioncs();

            Connection_SQL_MySql con_sql_mysql = new Connection_SQL_MySql();
            //Selecting Dept -->investigation from radio 
            string get_conn = con_sql_mysql.getConnectionSql();
            SqlConnection sqlCon = new SqlConnection(get_conn);
            SqlCommand cmd = new SqlCommand();
            // cmd.CommandText = "select Dept_no,Investigation from Dept where Dept_No in(9,10)";
            cmd.Connection = sqlCon;
            sqlCon.Open();
            cmd.CommandText = "select Dept_no,Investigation from Dept ";
           
            SqlDataAdapter da_invest = new SqlDataAdapter(cmd);
            DataTable dt_invest = new DataTable();
            da_invest.Fill(dt_invest);
            //grdShowData.DataSource = dt;
            string get_Myconn = con_sql_mysql.getConnectionMySql();
            MySqlConnection connect = new MySqlConnection(get_Myconn);
            String existValue = "";
            if (dt_invest.Rows.Count > 0)
            {
                //MessageBox.Show("Found");
                //Mysql database connection

                MySqlCommand Mycmd = new MySqlCommand();
                connect.Open();
                Mycmd = connect.CreateCommand();

                foreach (DataRow row in dt_invest.Rows)
                {
                    //existValue = data_en.Encrypt(row[0].ToString());
                    existValue = (row[0].ToString());
                    //MessageBox.Show(existValue);
                    Mycmd.CommandText = "select * from investigation where radioInvestigationId='" + existValue + "'";
                    MySqlDataAdapter myda = new MySqlDataAdapter(Mycmd);
                    DataTable mydt = new DataTable();
                    myda.Fill(mydt);
                    if (mydt.Rows.Count > 0)
                    {
                        // MessageBox.Show("M Found Update");
                        //Mycmd.CommandText = "update investigation set radioInvestigationId ='" +data_en.Encrypt( row[1].ToString()) + "',radioInvestigationName='" + data_en.Encrypt(row[0].ToString()) + "' where investigationId ='" + row[0].ToString() + "'";
                        Mycmd.CommandText = "update investigation set radioInvestigationId ='" + (row[1].ToString()) + "',radioInvestigationName='" + (row[0].ToString()) + "' where investigationId ='" + row[0].ToString() + "'";
                        Mycmd.ExecuteNonQuery();
                    }
                    else
                    {
                        // MessageBox.Show("M No Found Insert");
                        // Mycmd.CommandText = "INSERT INTO investigation(radioInvestigationId,radioInvestigationName) values('" +data_en.Encrypt( row[0].ToString()) + "','" +data_en.Encrypt( row[1].ToString()) + "')";
                        Mycmd.CommandText = "INSERT INTO investigation(radioInvestigationId,radioInvestigationName) values('" + (row[0].ToString()) + "','" + (row[1].ToString()) + "')";
                        Mycmd.ExecuteNonQuery();
                    }
                }
                connect.Close();
            }          
            else
            {
                MessageBox.Show("No New Investigation Found");
            }

            sqlCon.Close();
        }
    }
}
