using System.Text;

namespace UserLogin
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string username, password;
            Console.WriteLine("Please enter username:");
            username=Console.ReadLine();
            Console.WriteLine("Please enter password:");
            password=Console.ReadLine();
            User? user = null;
            LoginValidation validation = new LoginValidation(username,password, Error);
            if (validation.ValidateUserInput(ref user))
            {
                Console.WriteLine(user.Name);
                Console.WriteLine(user.Password);
                Console.WriteLine(user.Number);

                switch (LoginValidation.currentUserRole)
                {
                    case UserRoles.ANONYMOUS:
                        Console.WriteLine("Anonymous role");
                        break;
                    case UserRoles.ADMIN:
                        Console.WriteLine("Administrator role");
                        break;
                    case UserRoles.INSPECTOR:
                        Console.WriteLine("Inspector role");
                        break;
                    case UserRoles.PROFESSOR:
                        Console.WriteLine("Professor role");
                        break;
                    case UserRoles.STUDENT:
                        Console.WriteLine("Student role");
                        break;



                }

                Console.WriteLine(user.Created);
                AdminMenu();

            }
        }


        private static void Error(string errorMsg)
        {
            Console.WriteLine("!!! " + errorMsg + " !!!");
        }

        private static void AdminMenu()
        {
            Console.WriteLine("Изберете опция:");
            Console.WriteLine("0: Изход");
            Console.WriteLine("1: Промяна на роля на потребител");
            Console.WriteLine("2: Промяна на активност на потребител");
            Console.WriteLine("3: Списък на потребителите");
            Console.WriteLine("4: Преглед на лог на активност");
            Console.WriteLine("5: Преглед на текущата активност");
            int choise = Int32.Parse(Console.ReadLine());
            switch (choise)
            {
                case 0:
                    return;
                case 1:
                    AssignRole();
                    break;
                case 2:
                    Active();
                    break;
                case 3:
                    break;
                case 4:
                    ViewLog();
                    break;
                case 5:
                    PrintCurrentSessionActivities();
                    break;

                default:
                    Console.WriteLine("Въведете валиден избор");
                    AdminMenu();
                    break;



            }

        }

        private static void AssignRole()
        {
            string name = ReadUsername();
            Console.WriteLine("Въведете потребителска роля 0-4:");
            UserRoles role= (UserRoles) Int32.Parse(Console.ReadLine());
            UserData.AssignUserRole(name,role);
            Logger.LogActivity("Промяна на роля на "+name, name);

        }

        private static void Active()
        {
            string name = ReadUsername();
            Console.WriteLine("Въведете дата на край на активността:");
            DateTime finalDate = DateTime.Parse(Console.ReadLine());
            UserData.SetUserActiveTo(name,finalDate);
            Logger.LogActivity("Промяна на активност на " + name, name);


        }

        private static string ReadUsername()
        {
            Console.WriteLine("Въведете потребителско име:");
            string name = Console.ReadLine();
            return name;
        }

        private static void PrintCurrentSessionActivities()
        {
            IEnumerable<string> currentSessionActivities =Logger.GetCurrentSessionActivities(ReadActivityFilter());
            ViewActivityCollection(currentSessionActivities);
            

        }

        private static void ViewLog()
        {
            IEnumerable<string> logActivities = Logger.GetLogActivities();
            ViewActivityCollection(logActivities);


        }

        private static void ViewActivityCollection(IEnumerable<string> logLines)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (string activityLine in logLines)
            {
                stringBuilder.Append(activityLine);
            }
            Console.WriteLine(stringBuilder.ToString());
        }

        private static string ReadActivityFilter()
        {
            string? filter;
            Console.WriteLine("Въведете филтър на логовете:");
            filter = Console.ReadLine();
            if (filter == null)
            {
                filter = new string("");
            }
            return filter;
        }

    }


}
