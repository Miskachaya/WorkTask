using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ConsoleApp1
{
    class TableCreator
    {
        SqlDataAdapter Adapter = new SqlDataAdapter();
        DataTable Table = new DataTable();
        public TableCreator() 
        {
        }
        public void Do(DB dB) {
            try
            {
                SqlCommand CreateTable = new SqlCommand(
                "create table NotesForEmployee(" +
                "FullName varchar(50)," +
                "DateOfBurthday date," +
                "Sex varchar(6));", dB.getConnection());
                Adapter.SelectCommand = CreateTable;
                Adapter.Fill(Table);
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
            }
        }
        
    }
}
