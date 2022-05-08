using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    static internal class UserData
    {
        private static List<User>  _testUsers;
        public static List<User> TestUsers
        {
            get {
                ResetTestUserData();
                return _testUsers;
            }
            set { }
        }


        private static void ResetTestUserData()
        {
             if (_testUsers == null)
            {
                _testUsers=new List<User>(3);
                _testUsers.Add(new User { Name = "Johnatan", Number = 234, Password = "secret1", Role = (int)UserRoles.ADMIN, Created = DateTime.Now, DateActive = DateTime.MaxValue });
                _testUsers.Add(new User { Name = "Jorge", Number = 235, Password = "secret2", Role = (int)UserRoles.STUDENT, Created = DateTime.Now, DateActive = DateTime.MaxValue });
                _testUsers.Add(new User { Name = "Janis", Number = 236, Password = "secret3", Role = (int)UserRoles.STUDENT, Created = DateTime.Now, DateActive = DateTime.MaxValue });
            }
        }


        public static User? IsUserPassCorrect(string username, string password)
        {

            User u = (from user in TestUsers
                      where (user.Name == username && user.Password == password)
                      select user).First();
           
            if(u == null) return null;
            return u;

        }


        public static void SetUserActiveTo(string username, DateTime dateTime)
        {
            foreach (User u in TestUsers)
            {
                if (u.Name == username)
                {
                    u.DateActive = dateTime;
                }
            }

        }

        public static void AssignUserRole(string username, UserRoles role)
        {
            foreach (User u in TestUsers)
            {
                if (u.Name == username)
                {
                    u.Role=(int) role;
                }
            }

        }
    }
}
