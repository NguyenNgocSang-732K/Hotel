using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEBCORE_API.Models.ViewModels
{
    public class RoomView
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public decimal Price { get; set; }
        public int IdEmp { get; set; }
        public string EmpName { get; set; }
    }
}
