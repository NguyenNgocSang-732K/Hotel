using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Center.Models.ModelView
{
    public class BookingView
    {
        public int Id { get; set; }
        public int RoomID { get; set; }
        public string RoomName { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public int CusID { get; set; }
        public string CusName { get; set; }
        public string Status { get; set; }
    }
}
