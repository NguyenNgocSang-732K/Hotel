using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Models.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int CusID { get; set; }
        public string CusName { get; set; }
        public int RoomID { get; set; }
        public string RoomName { get; set; }
        public decimal Total { get; set; }
        public int EmpID { get; set; }
        public string EmpName { get; set; }

    }
}
