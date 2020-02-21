using Center.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Center.Models.ModelView;
using Microsoft.EntityFrameworkCore;

namespace Center.Models.Dao
{
    public class ServicesDTO
    {
        private static AceEntities db;

        public static List<ServicesView> Get()
        {
            db = new AceEntities();
            return db.Services.AsNoTracking().Select(s => new ServicesView
            {
                Id = s.Id,
                Name = s.Name,
                Price = (decimal)s.Price
            }).ToList();
        }

        public static ServicesView GetByID(int id)
        {
            db = new AceEntities();
            return db.Services.AsNoTracking().Where(s => s.Id == id).Select(s => new ServicesView
            {
                Id = s.Id,
                Name = s.Name,
                Price = (decimal)s.Price
            }).SingleOrDefault();
        }

        public static int Create(ServicesView s)
        {
            try
            {
                db = new AceEntities();
                Services services = new Services
                {
                    Name = s.Name,
                    Price = s.Price
                };
                db.Services.Add(services);
                db.SaveChanges();
                return services.Id;
            }
            catch
            {
                return -1;
            }
        }

        public static bool Modify(ServicesView s)
        {
            try
            {
                db = new AceEntities();
                Services services = new Services
                {
                    Name = s.Name,
                    Price = s.Price
                };
                db.Services.Attach(services);
                db.Entry(services).State = EntityState.Modified;
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
                db.Services.Remove(db.Services.Find(id));
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
