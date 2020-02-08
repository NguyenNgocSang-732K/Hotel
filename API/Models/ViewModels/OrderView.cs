using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEBCORE_API.Models.ViewModels
{
    public class OrderView
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public int IdEmp { get; set; }
        public int IdCus { get; set; }
        public string CusName { get; set; }
        public string EmpName { get; set; }
        public int IdRoom { get; set; }
        public string RoomName { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public decimal Total { get; set; }
    }
}
