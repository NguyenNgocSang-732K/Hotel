using System;
using System.Collections.Generic;

namespace API.Models.Entities
{
    public partial class Orders
    {
        public Orders()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public int? IdEmp { get; set; }
        public int? IdCus { get; set; }
        public int? IdRoom { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public decimal? Total { get; set; }

        public virtual Account IdCusNavigation { get; set; }
        public virtual Room IdRoomNavigation { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
