using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBCORE_API.Models.Entities;
using WEBCORE_API.Models.ViewModels;

namespace WEBCORE_API.Models.DTO
{
    public class DTOOrderDetails
    {
        private AceEntities en;
        public DTOOrderDetails()
        {
            en = new AceEntities();
        }

        public List<OrderDTView> GetDataWithOrder(int id)
        {
            return en.OrderDetails.Where(s => s.OrderId == id).Select(s => new OrderDTView
            {
                Date = (DateTime)s.Date,
                OrderId = s.OrderId,
                Price = (decimal)s.Price,
                Quantity = (int)s.Quantity,
                ServicesId = s.ServicesId,
                ServicesName = s.Services.Name
            }).ToList();
        }

        public int Create(List<OrderDTView> ol)
        {
            try
            {
                List<OrderDetails> oldt = new List<OrderDetails>();
                foreach (OrderDTView item in ol)
                {
                    oldt.Add(new OrderDetails
                    {
                        Date = item.Date,
                        OrderId = item.OrderId,
                        Price = item.Price,
                        Quantity = item.Quantity,
                        ServicesId = item.ServicesId,
                    });
                }
                en.OrderDetails.AddRange(oldt);
                en.SaveChanges();
                return ol[0].OrderId;
            }
            catch
            {
                return -1;
            }
        }
    }
}
