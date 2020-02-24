using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Models.Entities
{
    public class OrderDetail
    {
        public int SvID { get; set; }
        public string SvName { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
    }
}
