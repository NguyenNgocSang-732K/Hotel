using System;
using System.Collections.Generic;

namespace WEBCORE_API.Models.Entities
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
        public int? IdRoom { get; set; }
        public DateTime? DtaeStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public decimal? Total { get; set; }

        public virtual Account IdNavigation { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
