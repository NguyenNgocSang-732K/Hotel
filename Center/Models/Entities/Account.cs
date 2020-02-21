using System;
using System.Collections.Generic;

namespace Center.Models.Entities
{
    public partial class Account
    {
        public Account()
        {
            Booking = new HashSet<Booking>();
            OrdersIdCusNavigation = new HashSet<Orders>();
            OrdersIdEmpNavigation = new HashSet<Orders>();
            Room = new HashSet<Room>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int? Roles { get; set; }

        public virtual ICollection<Booking> Booking { get; set; }
        public virtual ICollection<Orders> OrdersIdCusNavigation { get; set; }
        public virtual ICollection<Orders> OrdersIdEmpNavigation { get; set; }
        public virtual ICollection<Room> Room { get; set; }
    }
}
