using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBCORE_API.Models.Entities;
using WEBCORE_API.Models.ViewModels;

namespace WEBCORE_API.Models.DTO
{
    public class DTORoom
    {
        private AceEntities en;
        public DTORoom()
        {
            en = new AceEntities();
        }

        public int Create(RoomView r)
        {
            try
            {
                Room room = new Room
                {
                    IdEmp = r.IdEmp,
                    Name = r.Name,
                    Price = r.Price
                };
                en.Room.Add(room);
                en.SaveChanges();
                return room.Id;
            }
            catch
            {
                return -1;
            }
        }

        public List<RoomView> GetData()
        {
            return en.Room.Select(s => new RoomView
            {
                Id = s.Id,
                EmpName = s.IdEmpNavigation.Name,
                Name = s.Name ?? 0,
                IdEmp = s.IdEmpNavigation.Id,
                Price = s.Price ?? 0
            }).ToList();
        }

        public RoomView GetByID(int id)
        {
            return en.Room.Where(s => s.Id == id).Select(s => new RoomView
            {
                Id = s.Id,
                EmpName = s.IdEmpNavigation.Name,
                Name = s.Name ?? 0,
                IdEmp = s.IdEmpNavigation.Id,
                Price = s.Price ?? 0
            }).SingleOrDefault();
        }

        public bool Modify(RoomView room)
        {
            try
            {
                Room r = en.Room.Find(room.Id);
                r.IdEmp = room.IdEmp;
                r.Name = room.Name;
                r.Price = room.Price;
                en.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool Remove(int id)
        {
            try
            {
                en.Room.Remove(en.Room.Find(id));
                en.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
