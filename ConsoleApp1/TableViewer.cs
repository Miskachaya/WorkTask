using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleApp1
{
    class TableViewer
    {
        SqlDataAdapter Adapter = new SqlDataAdapter();
        DataTable Table = new DataTable();
        public TableViewer()
        {
        }
        public void Do3(DB dB)
        {
            SqlCommand CreateTable = new SqlCommand(
                "select distinct FullName, DateOfBurthday from DBWorkTask.dbo.NotesForEmployee order by FullName", dB.getConnection());
            SqlDataReader Reader = CreateTable.ExecuteReader();
            while (Reader.Read())
            {
                User u = new User(Reader.GetString(0), Reader.GetValue(1).ToString(), Reader.GetString(2));
                Console.WriteLine($"{u} Возраст:{u.CalculateTheAge()}");
            }
            Reader.Close();
        }
        public void Do5(DB dB)
        {
            Stopwatch sw = Stopwatch.StartNew();
            SqlCommand CreateTable = new SqlCommand(
                "select * from NotesForEmployee where Sex ='Male' and left(FullName,1)='F'", dB.getConnection());
            SqlDataReader Reader = CreateTable.ExecuteReader();
            while (Reader.Read())
            {
                User u = new User(Reader.GetString(0), Reader.GetValue(1).ToString(), Reader.GetString(2));
                //Console.WriteLine(u);
            }
            Reader.Close();
            sw.Stop();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(sw.ElapsedMilliseconds);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" милисекунд");
        }
        public void Do5Upgrade(DB dB)
        {
            Stopwatch sw = Stopwatch.StartNew();
            SqlCommand CreateTable = new SqlCommand(
                "select * from NotesForEmployee where FullName='F%' and Sex='M%'", dB.getConnection());
            SqlDataReader Reader = CreateTable.ExecuteReader();
            while (Reader.Read())
            {
                User u = new User(Reader.GetString(0), Reader.GetValue(1).ToString(), Reader.GetString(2));
                //Console.WriteLine(u);
            }
            Reader.Close();
            sw.Stop();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(sw.ElapsedMilliseconds);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" милисекунд");
        }
    }
}
