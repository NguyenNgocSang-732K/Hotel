using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBCORE_API.Models.Entities;
using WEBCORE_API.Models.ViewModels;

namespace WEBCORE_API.Models.DTO
{
    public class DTOOrder
    {
        private AceEntities en;
        public DTOOrder()
        {
            en = new AceEntities();
        }

        public int Create(OrderView o)
        {
            try
            {
                Orders orders = new Orders
                {
                    Date = o.Date,
                    DateEnd = o.DateEnd,
                    DateStart = o.DateStart,
                    IdEmp = o.IdEmp,
                    IdRoom = o.IdRoom,
                    IdCus = o.IdCus,
                    Total = o.Total
                };
                en.Orders.Add(orders);
                en.SaveChanges();
                return orders.Id;
            }
            catch
            {
                return -1;
            }
        }

        public List<OrderView> GetData()
        {
            return en.Orders.Select(s => new OrderView
            {
                Id = s.Id,
                CusName = s.IdCusNavigation.Name,
                Date = s.Date,
                DateEnd = (DateTime)s.DateEnd,
                DateStart = (DateTime)s.DateStart,
                EmpName = s.IdEmpNavigation.Name,
                IdCus = (int)s.IdCus,
                IdEmp = (int)s.IdEmp,
                IdRoom = (int)s.IdRoom,
                RoomName = s.IdRoomNavigation.Name + ""
            }).ToList();
        }

        public OrderView GetByID(int id)
        {
            return en.Orders.Where(s => s.Id == id).Select(s => new OrderView
            {
                Id = s.Id,
                CusName = s.IdCusNavigation.Name,
                Date = s.Date,
                DateEnd = (DateTime)s.DateEnd,
                DateStart = (DateTime)s.DateStart,
                EmpName = s.IdEmpNavigation.Name,
                IdCus = (int)s.IdCus,
                IdEmp = (int)s.IdEmp,
                IdRoom = (int)s.IdRoom,
                RoomName = s.IdRoomNavigation.Name + ""
            }).SingleOrDefault();
        }
    }
}
