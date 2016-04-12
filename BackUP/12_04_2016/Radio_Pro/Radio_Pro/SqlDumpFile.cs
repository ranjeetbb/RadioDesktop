using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using MySql.Data.MySqlClient;
namespace Radio_Pro
{
    class SqlDumpFile
    {
        Methods methods = new Methods();

        Encoding utf8WithoutBOM = new UTF8Encoding(false);

        TextReader textReader;
        TextWriter textWriter;

        public string FileName;

        public Dictionary<string, string> dicTableCustomSql;
        public long max_allowed_packet;
        public string DatabaseName;
        public bool BackupRows;
        public bool BackupTableStructure;
        public bool EnableEncryption;
        public string EncryptKey;

        int saltSize;

        public void Restore(ref MySqlCommand cmd)
        {
            saltSize = methods.GetSaltSize(EncryptKey);

            cmd.Connection.Open();

            textReader = new StreamReader(FileName, true);

            StringBuilder sb = new StringBuilder();

            string line = "";

            while (line != null)
            {

                line = textReader.ReadLine();
                if (line == null)
                {
                    continue;
                }
                if (line.Trim().Length == 0)
                    continue;

                line = Read(line);

                if (line.Trim() + "" == "")
                    continue;
                if (line == "\r\n")
                    continue;
                if (line.StartsWith("--"))
                    continue;

                sb.Append(line);

                if (line.EndsWith(";"))
                {
                    cmd.CommandText = sb.ToString();
                    cmd.ExecuteNonQuery();

                    // Log Executed SQL
                    //textWriter = new StreamWriter("D:\\Log.txt",true, utf8WithoutBOM);
                    //textWriter.Write(Write(sb.ToString() + "\r\n");
                    //textWriter.Close();

                    sb = new StringBuilder();
                }
            }

            textReader.Close();
            cmd.Connection.Close();
        }

        public void Backup(ref MySqlCommand cmd)
        {
            saltSize = methods.GetSaltSize(EncryptKey);

            cmd.Connection.Open();

            if (dicTableCustomSql == null || dicTableCustomSql.Count == 0)
            {
                string[] tables = methods.GetTableNames(ref cmd);
                dicTableCustomSql = new Dictionary<string, string>();
                foreach (string s in tables)
                {
                    dicTableCustomSql.Add(s, "SELECT * FROM `" + s + "`;");
                }
            }

            #region Document Header

            textWriter = new StreamWriter(FileName, false, utf8WithoutBOM);

            textWriter.WriteLine(Write("-- MySqlBackup dump " + MySqlBackup.Version));
            textWriter.WriteLine(Write("-- Dump time: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
            textWriter.WriteLine(Write("-- ------------------------------------------------------"));
            textWriter.WriteLine(Write("-- Server version	" + methods.GetServerVersion(ref cmd)));
            textWriter.WriteLine(Write(""));
            textWriter.WriteLine(Write(""));
            textWriter.WriteLine(Write("/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;"));
            textWriter.WriteLine(Write("/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;"));
            textWriter.WriteLine(Write("/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;"));
            textWriter.WriteLine(Write("/*!40101 SET NAMES utf8 */;"));
            textWriter.WriteLine(Write(""));
            textWriter.WriteLine(Write("/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;"));
            textWriter.WriteLine(Write("/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;"));
            textWriter.WriteLine(Write("/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;"));
            textWriter.WriteLine(Write(""));
            textWriter.WriteLine(Write(""));
            textWriter.WriteLine(Write("--"));
            textWriter.WriteLine(Write("-- Create schema " + DatabaseName));
            textWriter.WriteLine(Write("--"));
            textWriter.WriteLine(Write(""));
            textWriter.WriteLine(Write("CREATE DATABASE IF NOT EXISTS " + DatabaseName + ";"));
            textWriter.WriteLine(Write("USE " + DatabaseName + ";"));

            textWriter.Close();

            #endregion

            foreach (KeyValuePair<string, string> kv in dicTableCustomSql)
            {
                string table = kv.Key;

                #region Table Header

                textWriter = new StreamWriter(FileName, true, utf8WithoutBOM);

                if (BackupTableStructure)
                {
                    textWriter.WriteLine(Write(""));
                    textWriter.WriteLine(Write(""));
                    textWriter.WriteLine(Write("--"));
                    textWriter.WriteLine(Write("-- Definition of table `" + table + "`"));
                    textWriter.WriteLine(Write("--"));
                    textWriter.WriteLine(Write(""));
                    textWriter.WriteLine(Write("DROP TABLE IF EXISTS `" + table + "`;"));
                    textWriter.WriteLine(Write(methods.GetCreateTableSql(table, ref cmd)));
                }

                if (BackupRows)
                {
                    textWriter.WriteLine(Write(""));
                    textWriter.WriteLine(Write("--"));
                    textWriter.WriteLine(Write("-- Dumping data for table `" + table + "`"));
                    textWriter.WriteLine(Write("--"));
                    textWriter.WriteLine(Write(""));
                    textWriter.WriteLine(Write("/*!40000 ALTER TABLE `" + table + "` DISABLE KEYS */;"));
                }
                textWriter.Close();

                #endregion

                if (BackupRows)
                    BackupTable(table, ref cmd);

                #region Table Footer

                if (BackupRows)
                {
                    textWriter = new StreamWriter(FileName, true, utf8WithoutBOM);
                    textWriter.WriteLine(Write("/*!40000 ALTER TABLE `" + table + "` ENABLE KEYS */;"));
                    textWriter.Close();
                }
                #endregion
            }

            #region Document Footer

            textWriter = new StreamWriter(FileName, true, utf8WithoutBOM);

            textWriter.WriteLine(Write(""));
            textWriter.WriteLine(Write(""));
            textWriter.WriteLine(Write(""));
            textWriter.WriteLine(Write(""));
            textWriter.WriteLine(Write("/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;"));
            textWriter.WriteLine(Write("/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;"));
            textWriter.WriteLine(Write("/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;"));
            textWriter.WriteLine(Write("/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;"));
            textWriter.WriteLine(Write("/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;"));
            textWriter.WriteLine(Write("/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;"));
            textWriter.WriteLine(Write("/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;"));

            textWriter.Close();

            #endregion

            cmd.Connection.Close();
        }

        private void BackupTable(string table, ref MySqlCommand cmd)
        {
            //string[] ColumnNames = methods.GetColumnNames(table, ref cmd);

            //string InsertStatementHeader = GetInsertStatementHeader(table, ColumnNames);

            string InsertStatementHeader = null;

            cmd.CommandText = dicTableCustomSql[table];

            MySqlDataReader rdr = cmd.ExecuteReader();

            StringBuilder sb = new StringBuilder();

            while (rdr.Read())
            {
                if (InsertStatementHeader == null)
                {
                    int fc = rdr.FieldCount;
                    string[] ColumnNames = new string[fc];
                    for (int ci = 0; ci < rdr.FieldCount; ci++)
                    {
                        ColumnNames[ci] = rdr.GetName(ci);
                    }
                    InsertStatementHeader = GetInsertStatementHeader(table, ColumnNames);
                }

                object[] objectArray = new object[rdr.FieldCount];

                for (int i = 0; i < rdr.FieldCount; i++)
                {
                    objectArray[i] = rdr[i];
                }

                string ValueString = GetSqlValueString(objectArray);

                if (sb.Length == 0)
                {
                    sb.Append(InsertStatementHeader + "\r\n" + ValueString);
                }
                else if (((long)sb.Length + ValueString.Length + 10) < max_allowed_packet)
                {
                    sb.Append(",\r\n" + ValueString);
                }
                else if (((long)sb.Length + ValueString.Length) >= max_allowed_packet)
                {
                    sb.Append(";");

                    string readyText = Write(sb.ToString());

                    textWriter = new StreamWriter(FileName, true, utf8WithoutBOM);
                    textWriter.WriteLine(readyText);
                    textWriter.Close();

                    sb = new StringBuilder();
                    sb.Append(InsertStatementHeader + "\r\n" + ValueString);
                }


            }
            rdr.Close();

            if (sb.Length > 0)
                sb.Append(";");

            textWriter = new StreamWriter(FileName, true, utf8WithoutBOM);
            textWriter.WriteLine(Write(sb.ToString()));
            textWriter.Close();
        }

        private string GetInsertStatementHeader(string table, string[] columnNames)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO `" + table + "` (");
            foreach (string s in columnNames)
            {
                sb.Append("`" + s + "`,");
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append(") VALUES");
            return sb.ToString();
        }

        private string GetSqlValueString(object[] obs)
        {
            StringBuilder sbData = new StringBuilder();

            sbData.Append("(");

            foreach (object ob in obs)
            {
                sbData.Append(GetDataString(ob) + ",");
            }
            sbData.Remove(sbData.Length - 1, 1);
            sbData.Append(")");
            return sbData.ToString();
        }

        private string GetDataString(object ob)
        {
            if (ob is System.DBNull)
            {
                return "NULL";
            }
            else if (ob is System.DateTime)
            {
                return "'" + ((DateTime)ob).ToString("yyyy-MM-dd HH:mm:ss") + "'";
            }
            else if (ob is System.Boolean)
            {
                return Convert.ToInt32(ob) + "";
            }
            else if (ob is System.Byte[])
            {
                return methods.GetBLOBSqlDataStringFromBytes(((byte[])ob));
            }
            else if (ob is System.String)
            {
                string data = ob.ToString();

                EscapeStringSequence(ref data);

                return ("'" + data + "'");
            }
            else
            {
                string a = ob.ToString();
                double d = 0;
                if (double.TryParse(a, out d))
                {
                    return a;
                }
                else
                {
                    EscapeStringSequence(ref a);
                    return "'" + a + "'";
                }
            }
        }

        private void EscapeStringSequence(ref string data)
        {
            data = data.Replace("\\", "\\\\"); // Backslash
            data = data.Replace("\r", "\\r");  // Carriage return
            data = data.Replace("\n", "\\n");  // New Line
            data = data.Replace("\a", "\\a");  // Vertical tab
            data = data.Replace("\b", "\\b");  // Backspace
            data = data.Replace("\f", "\\f");  // Formfeed
            data = data.Replace("\t", "\\t");  // Horizontal tab
            data = data.Replace("\v", "\\v");  // Vertical tab
            data = data.Replace("\"", "\\\""); // Double quotation mark
            data = data.Replace("'", "\\'");   // Single quotation mark
        }

        private string Write(string input)
        {
            if (EnableEncryption)
            {
                if (input == null || input.Length == 0)
                    return methods.Encrypt("-- ||||" + methods.RandomString(methods.random.Next(40, 151)), EncryptKey, saltSize);
                return methods.Encrypt(input, EncryptKey, saltSize);
            }
            else
                return input;
        }

        private string Read(string input)
        {
            if (input == null || input.Length == 0)
                return input;
            if (EnableEncryption)
                return methods.Decrypt(input, EncryptKey, saltSize);
            else
                return input;
        }

        public void EncryptTextFile(string originalFile, string newFile)
        {
            saltSize = methods.GetSaltSize(EncryptKey);

            if (!File.Exists(originalFile))
                throw new Exception("Original file is not exists.");

            textReader = new StreamReader(originalFile, utf8WithoutBOM);

            if (File.Exists(newFile))
            {
                File.Delete(newFile);
            }

            string line = "";

            bool firstWrite = true;

            while (line != null)
            {
                line = textReader.ReadLine();
                if (line == null)
                    continue;
                if (line + "" == "")
                    line = "-- ||||" + methods.RandomString(methods.random.Next(50, 300));
                line = methods.Encrypt(line, EncryptKey, saltSize);
                TextWriter textWriter = new StreamWriter(newFile, !firstWrite, utf8WithoutBOM);
                textWriter.WriteLine(line);
                textWriter.Close();

                firstWrite = false;
            }
        }

        public void DecryptTextFile(string originalFile, string newFile)
        {
            saltSize = methods.GetSaltSize(EncryptKey);

            if (!File.Exists(originalFile))
                throw new Exception("Original file is not exists.");

            textReader = new StreamReader(originalFile, utf8WithoutBOM);

            if (File.Exists(newFile))
            {
                File.Delete(newFile);
            }

            string line = "";

            bool firstWrite = true;

            while (line != null)
            {
                line = textReader.ReadLine();
                if (line == null)
                    continue;
                line = methods.Decrypt(line, EncryptKey, saltSize);
                if (line.StartsWith("-- ||||"))
                    line = "";
                TextWriter textWriter = new StreamWriter(newFile, !firstWrite, utf8WithoutBOM);
                textWriter.WriteLine(line);
                textWriter.Close();

                firstWrite = false;
            }
        }
    }
}
