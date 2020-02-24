using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Models.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public string RoomName { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string CustomerName { get; set; }
        public bool Status { get; set; }
    }
}
