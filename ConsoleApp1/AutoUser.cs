using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;

namespace ConsoleApp1
{
    class AutoUser
    {
        private List<User> Users;
        private string[] FullNames = { "Frolov Vladislav Sergeevich", "Fedotov Ivan Alexeevich", "Fomin Nikolai Maximovich", "Fetisov Albert Jenibekovich" };
        private string[] FullNamesA = { "Misaylova lina Bogdanova","Mindeeva Tifa Sergeevna", "Sinelnikova Mirana Vasilevna","S Ada Loveleis", "Munkueva Lanaya Ivanovna","Melnikova Anya Svatoslavovna", "Baco Tresdin Georgievna", "Bebinskaya Anna TeylorJoy", "Peryshkova Akasha Maximovna", "Praudmur Jaina Deadlinovna"};
        private string[] FullNamesB = { "Shefer Furion Evgenyevich","Sizyh Chipper Gavrilovich", "Umashev Illidan Igorevich","Ugov Ylman Konstantinovich", "Yezdnyh Slardar Ivanovich", "Ystoev Dobrynay Nikitich", "Menitil Arthas Terenovich","Montenegro Vaas Pavlovich", "Dragovich Steave Sergeevich","Dostavalov Semen Svyatoslavevich","Ford Genry Yilamovich","Fedorov Mario Semenovich" };
        public AutoUser(List<User> u)
        {
            this.Users = u;
        }
        public List<User> CreateH()
        {
            for (int i = 0; i < 100; i++)
            {
                Random r = new Random();
                User u = new User(FullNames[r.Next(FullNames.Length)], "2003-03-16", "male");
                Users.Add(u);
            }
            return Users;
        }
        public List<User> CreateM()
        {
            for (int j = 0; j < 1000000; j += 100) {
                Random r = new Random();
                for (int i = j; i < j + 100; i++)
                {
                    if (i % 2 == 0)
                    {
                        int rnd = r.Next(0, FullNamesB.Length);
                        User u = new User(FullNamesB[rnd], "2003-03-16", "male");
                        Users.Add(u);
                    }
                    else if (i % 2 == 1)
                    {
                        int rnd = r.Next(0,FullNamesA.Length);
                        User u = new User(FullNamesA[rnd], "2003-03-16", "female");
                        Users.Add(u);
                    }
                }
            }
            return Users;
        }
        public void WriteM(List<User> u, DB dB)
        {
            
            for (int i = 0; i < Users.Count; i+=10)
            {
                SqlDataAdapter Adapter = new SqlDataAdapter();
                DataTable Table = new DataTable();
                StringBuilder sb = new StringBuilder();
                sb.Clear();
                sb.AppendLine("Insert into NotesForEmployee(FullName, DateOfBurthday, Sex) values");
                for (int j = i;j<i+10;j++)
                {
                    if (j == i+10-1)
                    {

                        sb.Append($"('{u[j].getFullName()}', '{u[j].getDateOfBirthday()}', '{u[j].getSex()}')\n");
                    }
                    else
                    {
                        sb.Append(($"('{u[j].getFullName()}', '{u[j].getDateOfBirthday()}', '{u[j].getSex()}'),\n"));
                    }
                }
                try
                {
                    SqlCommand Command = new SqlCommand(sb.ToString(), dB.getConnection());
                    Adapter.SelectCommand = Command;
                    Adapter.Fill(Table);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine(sb.ToString());
                }
            }
        }
    }
}
