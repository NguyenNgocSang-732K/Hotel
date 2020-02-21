using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Center.Models.ModelView
{
    public class AccountView
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string  Password { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int Role { get; set; }
    }
}
