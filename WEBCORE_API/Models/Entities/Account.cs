using System;
using System.Collections.Generic;

namespace WEBCORE_API.Models.Entities
{
    public partial class Account
    {
        public Account()
        {
            BookingIdCustomerNavigation = new HashSet<Booking>();
            BookingIdEmpNavigation = new HashSet<Booking>();
            Room = new HashSet<Room>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int? Roles { get; set; }

        public virtual Orders Orders { get; set; }
        public virtual ICollection<Booking> BookingIdCustomerNavigation { get; set; }
        public virtual ICollection<Booking> BookingIdEmpNavigation { get; set; }
        public virtual ICollection<Room> Room { get; set; }
    }
}
