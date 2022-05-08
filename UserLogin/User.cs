using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public class User
    {

        public string? Name
        { get; set; }
        public string? Password
        { get; set; }
        public int? Number
        { get; set; }
        public int? Role
        { get; set; }
        public DateTime? Created
        { get; set; }
        public DateTime? DateActive
        { get; set; }
        public int UserId
        { get; set; }
    }
}
