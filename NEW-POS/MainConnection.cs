using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;
namespace NEW_POS
{
    class MainConnection
    {
        string connectionString;
        public int rowAffected = 0;
        public String getConnection()
        {
            connectionString = @"datasource=localhost;username=root;password=;database=pos_v1; charset=utf8; pooling=false;";
            return connectionString;
        }
        
        //select
        public DataTable GetData(string sql)
        {
            //connection
            MySqlConnection Sqlcon = new MySqlConnection(getConnection());
            //checking if the connection is close
            if (Sqlcon.State == ConnectionState.Closed) Sqlcon.Open();
            //creating a command using the connection and the sql query
            MySqlCommand SQLcom = new MySqlCommand(sql, Sqlcon);
            //creating the adapter using the created sql command
            MySqlDataAdapter SQLadap = new MySqlDataAdapter(SQLcom);
            DataSet ds = new DataSet();
            //fill the dataset using the adapter
            SQLadap.Fill(ds);
            Sqlcon.Close();
            return ds.Tables[0];
            
        }
        //insert, update, delete
        public void executeSQL(string sql)
        {
            //connection
            MySqlConnection Sqlcon = new MySqlConnection(getConnection());
            //open the connection
            if (Sqlcon.State == ConnectionState.Closed) Sqlcon.Open();
            //build the sql command using the sql statement and the connection
            MySqlCommand SQLcom = new MySqlCommand(sql, Sqlcon);
            //execute the sql command
            rowAffected = SQLcom.ExecuteNonQuery();
            Sqlcon.Close();
        }
        public string ConnectionString { get; set; }

        public bool checkConnection(string conn)
        {
            bool result = false;
            MySqlConnection connection = new MySqlConnection(conn);
            try
            {
                connection.Open();
                result = true;
                connection.Close();
            }
            catch
            {
                result = false;
            }
            return result;
        }
    }
}
