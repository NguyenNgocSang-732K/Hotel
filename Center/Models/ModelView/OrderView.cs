using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Center.Models.ModelView
{
    public class OrderView
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public int CusID { get; set; }
        public string CusName { get; set; }
        public int RoomID { get; set; }
        public string RoomName { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public decimal Total { get; set; }
    }
}
