using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Timers;
using MySql.Data.MySqlClient;

namespace NEW_POS
{
    class DBconnection
    {
        MySqlConnection conn;
        MySqlCommand cmd;
        MySqlDataReader dr;

        private string server;
        private string database;
        private string uid;
        private string password;
        private string charset;

        public void connect()
        {

            server = "127.0.0.1";
            database = "pos_v1";
            uid = "root";
            password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            conn = new MySqlConnection(connectionString);
            conn.Open();
        }


        public MySqlDataReader show(String sql)
        {
            cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteReader();
            return dr;
        }

        public void change(String sql)
        {
            cmd = new MySqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();

        }
    }

  

}
