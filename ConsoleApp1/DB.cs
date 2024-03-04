using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ConsoleApp1
{
    class DB
    {
        SqlConnection SqlConnection = new SqlConnection(@"Server=STARKILLER\SQLEXPRESS;Database=DBWorkTask;User Id=Admin;Password=1032;");
        public void OpenConnection()
        {
            if(SqlConnection.State == System.Data.ConnectionState.Closed)
            {
                SqlConnection.Open();
                if(SqlConnection.State == System.Data.ConnectionState.Closed) { Console.WriteLine("NotConnected"); }
                else { Console.WriteLine("Connected"); }
            }
        }
        public void CloseConnection()
        {
            if (SqlConnection.State == System.Data.ConnectionState.Open)
            {
                SqlConnection.Close();
            }
        }
        public SqlConnection getConnection()
        {
            return SqlConnection;
        }
    }
}
