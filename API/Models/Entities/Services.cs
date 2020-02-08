using System;
using System.Collections.Generic;

namespace API.Models.Entities
{
    public partial class Services
    {
        public Services()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
