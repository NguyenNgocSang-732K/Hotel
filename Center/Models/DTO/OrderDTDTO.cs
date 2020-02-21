using Center.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Center.Models.ModelView;
using Microsoft.EntityFrameworkCore;

namespace Center.Models.Dao
{
    public class OrderDTDTO
    {
        private static AceEntities db;

        public static List<OrderDetailsView> Get(int id)
        {
            db = new AceEntities();
            return db.OrderDetails.AsNoTracking().Where(s => s.OrderId == id).Select(s => new OrderDetailsView
            {
                OrdID = id,
                Date = (DateTime)s.Date,
                Price = (decimal)s.Price,
                Quantity = (int)s.Quantity,
                SvID = s.ServicesId,
                SvName = s.Services.Name
            }).ToList();
        }

        public static int Create(List<OrderDetailsView> list)
        {
            try
            {
                db = new AceEntities();
                List<OrderDetails> listDT = new List<OrderDetails>();
                foreach (OrderDetailsView item in list)
                {
                    listDT.Add(new OrderDetails
                    {
                        Date = item.Date,
                        OrderId = item.OrdID,
                        Price = item.Price,
                        Quantity = item.Quantity,
                        ServicesId = item.SvID
                    });
                }
                db.OrderDetails.AddRange(listDT);
                db.SaveChanges();
                return list[0].OrdID;
            }
            catch
            {
                return -1;
            }
        }
    }
}
