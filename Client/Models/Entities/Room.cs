using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Models.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string EmpName { get; set; }
        public int IdEmp { get; set; }
    }
}
