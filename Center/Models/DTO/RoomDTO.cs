using Center.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Center.Models.ModelView;
using Microsoft.EntityFrameworkCore;

namespace Center.Models.Dao
{
    public class RoomDTO
    {
        private static AceEntities db;

        public static List<RoomView> Get()
        {
            db = new AceEntities();
            return db.Room.AsNoTracking().Select(s => new RoomView
            {
                EmpID = (int)s.IdEmp,
                EmpName = s.IdEmpNavigation.Name,
                Name = s.Name + "",
                Id = s.Id,
                Price = (decimal)s.Price
            }).ToList();
        }

        public static RoomView GetByID(int id)
        {
            db = new AceEntities();
            return db.Room.AsNoTracking().Where(s => s.Id == id).Select(s => new RoomView
            {
                EmpID = (int)s.IdEmp,
                EmpName = s.IdEmpNavigation.Name,
                Name = s.Name + "",
                Id = s.Id,
                Price = (decimal)s.Price
            }).SingleOrDefault();
        }

        public static int Create(RoomView r)
        {
            try
            {
                db = new AceEntities();
                Room room = new Room
                {
                    IdEmp = r.EmpID,
                    Name = Convert.ToInt32(r.Name.Trim()),
                    Price = r.Price,
                };
                db.SaveChanges();
                return room.Id;
            }
            catch
            {
                return -1;
            }
        }

        public static bool Modify(RoomView r)
        {
            try
            {
                db = new AceEntities();
                Room room = new Room
                {
                    IdEmp = r.EmpID,
                    Name = Convert.ToInt32(r.Name.Trim()),
                    Price = r.Price,
                };
                db.Room.Attach(room);
                db.Entry(room).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool Remove(int id)
        {
            try
            {
                db = new AceEntities();
                db.Room.Remove(db.Room.Find(id));
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
