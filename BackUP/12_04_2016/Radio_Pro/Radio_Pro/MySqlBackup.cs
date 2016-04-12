using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using MySql.Data.MySqlClient;
namespace Radio_Pro
{
    public class MySqlBackup
    {
        public const string Version = "1.2";

        #region Public Properties
        public string DatabaseName { get; set; }
        public MySqlCommand Command
        {
            get
            {
                return _cmd;
            }
            set
            {
                _cmd = value;
                if (_cmd != null)
                    if (_cmd.Connection != null)
                        DatabaseName = methods.GetDatabaseName(_cmd.Connection.ConnectionString);
            }
        }
        public string ConnectionString
        {
            get
            {
                return _cmd.Connection.ConnectionString;
            }
            set
            {
                Connection = new MySqlConnection(value);
            }
        }
        public MySqlConnection Connection
        {
            get
            {
                return _cmd.Connection;
            }
            set
            {
                if (_cmd == null)
                    _cmd = new MySqlCommand();
                _cmd.Connection = value;
                DatabaseName = methods.GetDatabaseName(_cmd.Connection.ConnectionString);
            }
        }
        public string FileName { get; set; }
        public string[] TableNames
        {
            get
            {
                if (TableCustomSql == null)
                    return null;
                else
                {
                    string[] sa = new string[TableCustomSql.Count];
                    int count = -1;
                    foreach (KeyValuePair<string, string> kv in TableCustomSql)
                    {
                        count += 1;
                        sa[count] = kv.Key;
                    }
                    return sa;
                }
            }
            set
            {
                string[] sa = value;
                TableCustomSql = new Dictionary<string, string>();
                foreach (string s in sa)
                {
                    TableCustomSql.Add(s, "SELECT * FROM `" + s + "`;");
                }
            }
        }
        public bool UseServerMaxAllowedPacket { get { return _useServerMaxAllowedPacket; } set { _useServerMaxAllowedPacket = value; } }
        public long max_allowed_packet { get { return _maxallowedpacket; } set { _maxallowedpacket = value; } }
        public bool BackupRowsData { get { return _backupRowsData; } set { _backupRowsData = value; } }
        public bool EnableEncryption { get { return _enableEncryption; } set { _enableEncryption = value; } }
        public string EncryptionKey { get { return _encryptionKey; } set { _encryptionKey = methods.Sha1Hash(value); } }
        public bool BackupTableStructure { get { return _backupTableStructure; } set { _backupTableStructure = value; } }
        public Dictionary<string, string> TableCustomSql { get { return _dicTableCustomSql; } set { _dicTableCustomSql = value; } }
        #endregion

        string _encryptionKey = "abcd";
        bool _enableEncryption = false;
        MySqlCommand _cmd = new MySqlCommand();
        bool _backupRowsData = true;
        bool _backupTableStructure = true;
        long _maxallowedpacket = 1 * 1024 * 1024; // 1MB, Default MySql Server Value
        bool _useServerMaxAllowedPacket = false;
        Dictionary<string, string> _dicTableCustomSql;

        Methods methods = new Methods();

        /// <summary>
        /// Backup and Restore MySQL database.
        /// </summary>
        public MySqlBackup()
        { }

        /// <summary>
        /// Backup and Restore MySQL database.
        /// </summary>
        /// <param name="mySqlConnectionString">MySqlConnection String.</param>
        public MySqlBackup(string mySqlConnectionString)
        {
            if (mySqlConnectionString + "" == "")
                throw new Exception("MySql connection string is blank.");

            Connection = new MySqlConnection(mySqlConnectionString);
        }

        /// <summary>
        /// Backup and Restore MySQL database.
        /// </summary>
        /// <param name="mySqlConnection">Object of MySqlConnection.</param>
        public MySqlBackup(MySqlConnection mySqlConnection)
        {
            Connection = mySqlConnection;
            DatabaseName = methods.GetDatabaseName(mySqlConnection.ConnectionString);
            _cmd = new MySqlCommand();
            _cmd.Connection = Connection;
        }

        /// <summary>
        /// Backup and Restore MySQL database.
        /// </summary>
        /// <param name="mySqlCommand">Object of MySqlCommand.</param>
        public MySqlBackup(MySqlCommand mySqlCommand)
        {
            _cmd = new MySqlCommand();
            DatabaseName = methods.GetDatabaseName(_cmd.Connection.ConnectionString);
        }

        /// <summary>
        /// Export (Backup) all tables from MySQL Database to SQL Dump File.
        /// </summary>
        /// <param name="fileName">The full path and file name of the SQL Dump File.</param>
        public void Export(string fileName)
        {
            Export(fileName, _dicTableCustomSql);
        }

        /// <summary>
        /// Export (Backup) selected tables from MySQL Database to SQL Dump File.
        /// </summary>
        /// <param name="fileName">The full path and file name of the SQL Dump File.</param>
        /// <param name="tableNames">Collection of table names that will be exported.</param>
        public void Export(string fileName, string[] tableNames)
        {
            TableNames = tableNames;
            Export(fileName, _dicTableCustomSql);
        }

        /// <summary>
        /// Export (Backup) selected tables and selected columns and rows from MySQL Database to SQL Dump File.
        /// </summary>
        /// <param name="fileName">The full path and file name of the SQL Dump File.</param>
        /// <param name="tableCustomSelectSql">Collection of table names and custom SELECT statements.</param>
        public void Export(string fileName, Dictionary<string, string> tableCustomSelectSql)
        {
            if (Connection == null)
            {
                throw new Exception("MySqlConnection is not initialize. Object reference not set to an instance of an object.");
            }

            if (UseServerMaxAllowedPacket)
            {
                _maxallowedpacket = methods.GetServerMaxAllowedPacket(ref _cmd);
            }

            FileName = fileName;
            TableCustomSql = tableCustomSelectSql;

            SqlDumpFile stf = new SqlDumpFile();

            stf.FileName = FileName;
            stf.dicTableCustomSql = TableCustomSql;
            stf.max_allowed_packet = max_allowed_packet;
            stf.DatabaseName = DatabaseName;
            stf.BackupTableStructure = BackupTableStructure;
            stf.BackupRows = BackupRowsData;
            stf.EnableEncryption = EnableEncryption;
            stf.EncryptKey = EncryptionKey;

            stf.Backup(ref _cmd);
        }

        /// <summary>
        /// Import (Restore) data from SQL Dump File to MySQL Database.
        /// </summary>
        /// <param name="fileName">The full path and file name of the SQL Dump File.</param>
        public void Import(string fileName)
        {
            if (!System.IO.File.Exists(fileName))
                throw new Exception("File not exists.\r\n" + fileName);

            FileName = fileName;

            SqlDumpFile stf = new SqlDumpFile();

            stf.FileName = FileName;
            stf.DatabaseName = DatabaseName;
            stf.EnableEncryption = EnableEncryption;
            stf.EncryptKey = EncryptionKey;

            stf.Restore(ref _cmd);
        }

        /// <summary>
        /// Decrypt a SQL Dump File and save as new file.
        /// </summary>
        /// <param name="originalFile">The source of Encrypted SQL Dump File.</param>
        /// <param name="newFile">The new file of Decrypted SQL Dump File.</param>
        public void DecryptSqlTextFile(string originalFile, string newFile)
        {
            SqlDumpFile stf = new SqlDumpFile();
            stf.EncryptKey = _encryptionKey;
            stf.DecryptTextFile(originalFile, newFile);
            stf = null;
        }

        /// <summary>
        /// Encrypt a SQL Dump File and save as new file.
        /// </summary>
        /// <param name="originalFile">The source of SQL Dump File.</param>
        /// <param name="newFile">The new file of Encrypted SQL Dump File.</param>
        public void EncryptSqlTextFile(string originalFile, string newFile)
        {
            SqlDumpFile stf = new SqlDumpFile();
            stf.EncryptKey = _encryptionKey;
            stf.EncryptTextFile(originalFile, newFile);
            stf = null;
        }

        /// <summary>
        /// Get all tables in MySQL database.
        /// </summary>
        /// <returns>Collections of table names.</returns>
        public string[] GetAllTableNames()
        {
            return methods.GetTableNames(ref _cmd);
        }
    }
}
