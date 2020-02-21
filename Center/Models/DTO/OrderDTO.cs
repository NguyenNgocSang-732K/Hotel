using Center.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Center.Models.ModelView;
using Microsoft.EntityFrameworkCore;

namespace Center.Models.Dao
{
    public class OrderDTO
    {
        private static AceEntities db;

        public static List<OrderView> Get()
        {
            db = new AceEntities();
            return db.Orders.AsNoTracking().Select(s => new OrderView
            {
                CusID = (int)s.IdCus,
                CusName = s.IdCusNavigation.Name,
                Date = (DateTime)s.Date,
                DateEnd = (DateTime)s.DateEnd,
                DateStart = (DateTime)s.DateStart,
                EmpID = (int)s.IdEmp,
                EmpName = s.IdEmpNavigation.Name,
                RoomID = (int)s.IdRoom,
                RoomName = s.IdRoomNavigation.Name + "",
                Total = (int)s.Total,
                Id = s.Id
            }).ToList();
        }

        public static OrderView GetByID(int id)
        {
            db = new AceEntities();
            return db.Orders.AsNoTracking().Where(s => s.Id == id).Select(s => new OrderView
            {
                CusID = (int)s.IdCus,
                CusName = s.IdCusNavigation.Name,
                Date = (DateTime)s.Date,
                DateEnd = (DateTime)s.DateEnd,
                DateStart = (DateTime)s.DateStart,
                EmpID = (int)s.IdEmp,
                EmpName = s.IdEmpNavigation.Name,
                RoomID = (int)s.IdRoom,
                RoomName = s.IdRoomNavigation.Name + "",
                Total = (int)s.Total,
                Id = s.Id
            }).SingleOrDefault();
        }

        public static int Create(OrderView o)
        {
            try
            {
                db = new AceEntities();
                Orders orders = new Orders
                {
                    Date = o.Date,
                    DateEnd = o.DateEnd,
                    DateStart = o.DateStart,
                    IdCus = o.CusID,
                    IdEmp = o.EmpID,
                    IdRoom = o.RoomID,
                    Total = o.Total
                };
                db.Orders.Add(orders);
                db.SaveChanges();
                return orders.Id;
            }
            catch
            {
                return -1;
            }
        }
    }
}
