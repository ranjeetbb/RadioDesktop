using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
namespace Radio_Pro
{
    class Methods
    {
        XCrypt.XCryptEngine xe = new XCrypt.XCryptEngine(XCrypt.XCryptEngine.AlgorithmType.Rijndael);

        public string GetCreateTableSql(string table, ref MySqlCommand cmd)
        {
            cmd.CommandText = "SHOW CREATE TABLE `" + table + "`;";
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            da = null;
            return dt.Rows[0][1].ToString().Replace("CREATE TABLE", "CREATE TABLE IF NOT EXISTS") + ";";
        }

        public string[] GetColumnNames(string table, ref MySqlCommand cmd)
        {
            cmd.CommandText = "SHOW COLUMNS FROM `" + table + "`;";
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            da = null;
            string[] sa = new string[dt.Rows.Count];
            int count = -1;
            foreach (DataRow dr in dt.Rows)
            {
                count += 1;

                sa[count] = dr[0].ToString();
            }
            return sa;
        }

        public string[] GetTableNames(ref MySqlCommand cmd)
        {
            cmd.CommandText = "SHOW TABLES;";
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            da = null;
            string[] sa = new string[dt.Rows.Count];
            int count = -1;

            foreach (DataRow dr in dt.Rows)
            {
                count += 1;
                sa[count] = dr[0] + "";
            }

            return sa;
        }

        public string GetServerVersion(ref MySqlCommand cmd)
        {
            cmd.CommandText = "SHOW variables WHERE Variable_name = 'version';";
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt.Rows[0][1].ToString();
        }

        public long GetServerMaxAllowedPacket(ref MySqlCommand cmd)
        {
            cmd.CommandText = "SHOW variables WHERE Variable_name = 'max_allowed_packet';";
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return Convert.ToInt64(dt.Rows[0][1]);
        }

        public string GetDatabaseName(string ConnectionString)
        {
            string[] sa = ConnectionString.Split(';');
            foreach (string s in sa)
            {
                if (s.ToLower().StartsWith("database"))
                {
                    string[] sb = s.Split('=');
                    return sb[1];
                }
            }
            throw new Exception("Database Name is not detected in Connection String.");
        }

        public string GetBLOBSqlDataStringFromBytes(byte[] ba)
        {
            // Method 1 (slower)
            //return "0x"+ BitConverter.ToString(bytes).Replace("-", string.Empty);

            // Method 2 (faster)
            char[] c = new char[ba.Length * 2 + 2];
            byte b;
            c[0] = '0'; c[1] = 'x';
            for (int y = 0, x = 2; y < ba.Length; ++y, ++x)
            {
                b = ((byte)(ba[y] >> 4));
                c[x] = (char)(b > 9 ? b + 0x37 : b + 0x30);
                b = ((byte)(ba[y] & 0xF));
                c[++x] = (char)(b > 9 ? b + 0x37 : b + 0x30);
            }
            return new string(c);
        }

        public string Encrypt(string input, string key, int saltSize)
        {
            string salt = Salt(saltSize);
            return salt + xe.Encrypt(input, key + salt);
        }

        public string Decrypt(string input, string key, int saltSize)
        {
            try
            {
                string salt = input.Substring(0, saltSize);
                string data = input.Substring(saltSize);
                return xe.Decrypt(data, key + salt);
            }
            catch
            {
                string a = input;
                throw new Exception("Invalid Key.");
            }
        }

        public Random random = new Random((int)DateTime.Now.Ticks);

        public string RandomString(int size)
        {
            StringBuilder sb = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                sb.Append(ch);
            }
            return sb.ToString();
        }

        public int GetSaltSize(string key)
        {
            int a = key.GetHashCode();
            string b = Convert.ToString(a);
            char[] ca = b.ToCharArray();
            int c = 0;
            foreach (char cc in ca)
                c += Convert.ToInt32(cc.ToString());
            return c;
        }

        public string Salt(int saltSize)
        {
            string op = xe.Encrypt(RandomString(30)).Substring(0, saltSize);
            return op;
        }

        public string Sha1Hash(string input)
        {
            SHA1CryptoServiceProvider sha = new SHA1CryptoServiceProvider();
            byte[] ba = Encoding.UTF8.GetBytes(input);
            byte[] ba2 = sha.ComputeHash(ba);
            return BitConverter.ToString(ba2).Replace("-", string.Empty).ToLower();
        }
    }
}
