using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Center.Models.ModelView
{
    public class OrderDetailsView
    {
        public int SvID { get; set; }
        public int OrdID { get; set; }
        public string SvName { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
    }
}
