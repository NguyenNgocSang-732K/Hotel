using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBCORE_API.Models.Entities;
using WEBCORE_API.Models.ViewModels;

namespace WEBCORE_API.Models.DTO
{
    public class DTOServices
    {
        private AceEntities en;
        public DTOServices()
        {
            en = new AceEntities();
        }

        public int Create(ServicesView s)
        {
            try
            {
                Services services = new Services
                {
                    Name = s.Name,
                    Price = s.Price
                };
                en.Services.Add(services);
                en.SaveChanges();
                return services.Id;
            }
            catch
            {
                return -1;
            }
        }

        public List<ServicesView> GetData()
        {
            return en.Services.Select(s => new ServicesView
            {
                Id = s.Id,
                Name = s.Name,
                Price = (decimal)s.Price
            }).ToList();
        }

        public ServicesView GetByID(int id)
        {
            return en.Services.Where(s => s.Id == id).Select(s => new ServicesView
            {
                Id = s.Id,
                Name = s.Name,
                Price = (decimal)s.Price
            }).SingleOrDefault();
        }

        public bool Modify(ServicesView s)
        {
            try
            {
                Services services = en.Services.Find(s.Id);
                services.Name = s.Name;
                services.Price = s.Price;
                en.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool Remove(ServicesView s)
        {
            try
            {
                en.Services.Remove(en.Services.Find(s.Id));
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
