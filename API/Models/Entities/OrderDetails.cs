using System;
using System.Collections.Generic;

namespace API.Models.Entities
{
    public partial class OrderDetails
    {
        public int ServicesId { get; set; }
        public int OrderId { get; set; }
        public int? Quantity { get; set; }
        public DateTime? Date { get; set; }
        public decimal? Price { get; set; }

        public virtual Orders Order { get; set; }
        public virtual Services Services { get; set; }
    }
}
