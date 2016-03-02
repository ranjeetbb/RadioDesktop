using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.IO;

namespace Radio_Pro
{
    public partial class Form1 : Form
    {
        //for SQL connection
        string connectionString = "Data Source=RANJEETBB;Initial Catalog=radio;Integrated Security=True;";
        //for MySQL connection
        string MyConnectionString = "Server=localhost;Database=radio;Uid=root;Pwd=root;";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblMsgData.Text = "";
            lblExist.Text = "";
        }

        private void btnPull_Click(object sender, EventArgs e)
        {
            if (txtStartDate.Text == "" || txtEndDate.Text == "")
            {
                lblMsgData.ForeColor = System.Drawing.Color.Red;
                lblMsgData.Text = "Please Enter StartDate and EndDate !!";
            }
            else
            {
                lblMsgData.ForeColor = System.Drawing.Color.Green;
                lblMsgData.Text = "Please wait while data pulling !!";

                //for SQL connection
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.CommandText = "select * from vwPtDetsWithRefDrAndAddresses_2 where Pt_Rep_Date between'" + txtStartDate.Text + "' and '" + txtEndDate.Text + "'";

                        cmd.Connection = sqlCon;

                        sqlCon.Open();

                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        DataTable dt = new DataTable();

                        da.Fill(dt);

                        //int rows = dt.Rows.Count;
                        // MessageBox.Show("rows "+rows);
                        if (dt.Rows.Count > 0)
                        {

                            //for MySQL connection

                            using (MySqlConnection connect = new MySqlConnection(MyConnectionString))
                            {
                                string start_Date = "", end_Date = "", record_date="";
                                DateTime fethc_Date = DateTime.Now;
                                MySqlCommand Mycmd;
                                connect.Open();
                                Mycmd = connect.CreateCommand();
                                Mycmd.CommandText = "select  start_date,end_date,fethc_Date from fetch_date_data where start_date='" + txtStartDate.Text + "' and  end_date='" + txtEndDate.Text + "'";
                                MySqlDataReader dr = Mycmd.ExecuteReader();
                                while (dr.Read())
                                {
                                    start_Date = dr[0].ToString();
                                    end_Date = dr[1].ToString();
                                    record_date = dr[2].ToString();

                                    //MessageBox.Show("Start Date" + treatment);
                                }
                                connect.Close();
                                    
                               if (start_Date.ToString() == txtStartDate.Text.ToString() || end_Date.ToString() == txtEndDate.Text.ToString())
                                {
                                    lblExist.ForeColor = System.Drawing.Color.Blue;
                                    lblExist.Text = "Date Detaile: Start Date " + start_Date + " End Date " + end_Date + " On Day->" + record_date;
                                    MessageBox.Show("Sorry you have already pulled in between date ! ");

                                }
                                else
                                {
                                    connect.Open();
                                    Mycmd = connect.CreateCommand();
                                    Mycmd.CommandText = "insert into fetch_date_data(start_date,end_date,fethc_Date) values('" + txtStartDate.Text + "','" + txtEndDate.Text + "','"+fethc_Date+"')";
                                    Mycmd.ExecuteNonQuery();

                                    string sql = "INSERT INTO vwPtDetsWithRefDrAndAddresses(Entry_No,FP,address,PhRes,PhOff,Mobile,Pt_RegNo,Cut,Coll_Amt,Coll_Extra,Coll_Concession,Coll_Sp_Conc,Pending_Amt,Pt_Rep_Date,Recoverable,Cut_Given,Amt_Mod_On) VALUES(@A,@B,@C,@D,@E,@F,@G,@H,@I,@J,@K,@L,@M,@N,@O,@P,@Q)";
                                    foreach (DataRow row in dt.Rows)
                                    {

                                        Mycmd = connect.CreateCommand();
                                        Mycmd.CommandText = sql;

                                        Data_Encryption data_en = new Data_Encryption();
                                        string Entry_No = data_en.Encrypt(row[0].ToString());
                                        string FP = data_en.Encrypt(row[1].ToString());
                                        string Address = data_en.Encrypt(row[2].ToString());


                                        string  PhRes= data_en.Encrypt(row[3].ToString());
                                        string  PhOff= data_en.Encrypt(row[4].ToString());
                                        string  Mobile= data_en.Encrypt(row[5].ToString());
                                        string  Pt_RegNo= data_en.Encrypt(row[6].ToString());
                                        string  Cut= data_en.Encrypt(row[7].ToString());
                                        string  Coll_Amt= data_en.Encrypt(row[8].ToString());

                                        string  Coll_Extra= data_en.Encrypt(row[9].ToString());
                                        string  Coll_Concession= data_en.Encrypt(row[10].ToString());
                                        string  Coll_Sp_Conc= data_en.Encrypt(row[11].ToString());
                                        string  Pending_Amt= data_en.Encrypt(row[12].ToString());
                                        string  Pt_Rep_Date= data_en.Encrypt(row[13].ToString());

                                        string Recoverable = data_en.Encrypt(row[14].ToString());
                                        string Cut_Given = data_en.Encrypt(row[15].ToString());
                                        string Amt_Mod_On = data_en.Encrypt(row[16].ToString());

                                        Mycmd.Parameters.AddWithValue("@A", Entry_No);
                                        Mycmd.Parameters.AddWithValue("@B", FP);                                     
                                        Mycmd.Parameters.AddWithValue("@C", Address);
                                        Mycmd.Parameters.AddWithValue("@D", PhRes);
                                        Mycmd.Parameters.AddWithValue("@E", PhOff);
                                        Mycmd.Parameters.AddWithValue("@F", Mobile);
                                        Mycmd.Parameters.AddWithValue("@G", Pt_RegNo);
                                        Mycmd.Parameters.AddWithValue("@H", Cut);
                                        Mycmd.Parameters.AddWithValue("@I", Coll_Amt);
                                        Mycmd.Parameters.AddWithValue("@J", Coll_Extra);
                                        Mycmd.Parameters.AddWithValue("@K", Coll_Concession);
                                        Mycmd.Parameters.AddWithValue("@L", Coll_Sp_Conc);
                                        Mycmd.Parameters.AddWithValue("@M", Pending_Amt);
                                        Mycmd.Parameters.AddWithValue("@N", Pt_Rep_Date);
                                        Mycmd.Parameters.AddWithValue("@O", Recoverable);
                                        Mycmd.Parameters.AddWithValue("@P", Cut_Given);
                                        Mycmd.Parameters.AddWithValue("@Q", Amt_Mod_On);
                                       
                                        Mycmd.ExecuteNonQuery();
                                    }
                                    Mycmd = connect.CreateCommand();
                                    Mycmd.CommandText = "select *from vwPtDetsWithRefDrAndAddresses";
                                    MySqlDataAdapter mydack = new MySqlDataAdapter(Mycmd);
                                    DataTable mydt = new DataTable();
                                    mydack.Fill(mydt);
                                    dataGridView2.DataSource = mydt.DefaultView;
                                    connect.Close();
                                    MessageBox.Show("Pulled Successfully ! ");
                                    lblMsgData.Text = "";

                                }

                            }


                        }

                        else
                        {
                            MessageBox.Show("No Selection");
                            lblMsgData.Text = "";
                        }

                        sqlCon.Close();
                    }
                }
            }

 
        }

    
    }
}
