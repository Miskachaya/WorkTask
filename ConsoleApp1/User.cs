using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ConsoleApp1
{
    class User
    {
        private TimeSpan Age { get; set; }
        private DateTime Today_ { get; set; }
        private string FullName { get; set; }
        private DateTime DateOfBirthday { get; set; }
        private string Sex { get; set; }
        public User(string LnFnMn, string date, string sex)
        {
            this.FullName = LnFnMn;
            this.DateOfBirthday=DateTime.Parse(date);
            sex = sex.ToLower();
            switch (sex)
            {
                case "male":
                    this.Sex = "Male";
                    break;
                case "female":
                    this.Sex = "Female";
                    break;
            }
        }
        public string CalculateTheAge()
        {
            this.Today_ = DateTime.Today;
            this.Age = Today_ - this.DateOfBirthday;
            return $"{Age.Days / 365}";
        }
        public void WriteInDB(DB db)
        {
            SqlDataAdapter Adapter = new SqlDataAdapter();
            DataTable Table = new DataTable();
            SqlCommand Command = new SqlCommand($"Insert into NotesForEmployee(FullName, DateOfBurthday, Sex) values('{this.FullName}','{this.DateOfBirthday.ToString("yyyy-MM-dd")}','{Sex}')",db.getConnection());
            Adapter.SelectCommand = Command;
            Adapter.Fill(Table);
        }
        public string getFullName()
        {
            return this.FullName;
        }
        public string getDateOfBirthday()
        {
            return this.DateOfBirthday.ToString("yyyy-MM-dd");
        }
        public string getSex()
        {
            return this.Sex;
        }
        public override string ToString() 
        {
            string s = $"{this.FullName} {this.Sex} {this.DateOfBirthday.ToString("yyyy-MM-dd")}";
            return s;
        }
    }
}
