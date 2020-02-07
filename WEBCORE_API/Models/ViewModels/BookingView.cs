using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEBCORE_API.Models.ViewModels
{
    public class BookingView
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public int IdCustomer { get; set; }
        public string CusName { get; set; }
        public string Status { get; set; }
    }
}
