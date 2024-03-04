using System.Data;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            DB dB = new DB();
            dB.OpenConnection();
            

            switch (args[0])
            {
                case "1":
                    TableCreator tableCreator = new TableCreator();
                    tableCreator.Do(dB);
                    break;
                case "2":
                    User us = new User(args[1], args[2], args[3]);
                    us.WriteInDB(dB);
                    Console.WriteLine(us);
                    Console.WriteLine("Возраст сотрудника: " + us.CalculateTheAge());
                    break;
                case "3":
                    TableViewer tableViewer = new TableViewer();
                    tableViewer.Do3(dB);
                    break;
                case "4":
                    List<User> users = new List<User>();
                    AutoUser AU = new AutoUser(users);
                    users = AU.CreateM();
                    AU.WriteM(users, dB);
                    break;
                case "5":
                    tableViewer = new TableViewer();
                    tableViewer.Do5(dB);
                    break;
                case "6":
                    tableViewer = new TableViewer();
                    tableViewer.Do5Upgrade(dB);
                    break;
            }
        }
    }
}

