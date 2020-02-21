using System;
using System.Collections.Generic;

namespace Center.Models.Entities
{
    public partial class Booking
    {
        public int Id { get; set; }
        public int? RoomId { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public int? IdCustomer { get; set; }
        public string Status { get; set; }

        public virtual Account IdCustomerNavigation { get; set; }
        public virtual Room Room { get; set; }
    }
}
