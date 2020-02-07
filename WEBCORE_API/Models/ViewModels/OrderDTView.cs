using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEBCORE_API.Models.ViewModels
{
    public class OrderDTView
    {
        public int ServicesId { get; set; }
        public string ServicesName { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
    }
}
