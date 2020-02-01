using System;
using System.Collections.Generic;

namespace WEBCORE_API.Models.Entities
{
    public partial class Room
    {
        public Room()
        {
            Booking = new HashSet<Booking>();
        }

        public int Id { get; set; }
        public int? Name { get; set; }
        public decimal? Price { get; set; }
        public int? IdEmp { get; set; }

        public virtual Account IdEmpNavigation { get; set; }
        public virtual ICollection<Booking> Booking { get; set; }
    }
}
