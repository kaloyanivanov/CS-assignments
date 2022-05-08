using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLogin;


namespace StudentInfoSystem
{
    internal class StudentValidation
    {
        public Student GetStudentDataByUser(User u)
        {
            if(u.Name == null)
            {
                return null;
            }
            return new Student();
        }
    }
}
