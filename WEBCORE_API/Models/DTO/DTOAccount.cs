using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBCORE_API.Library;
using WEBCORE_API.Models.Entities;
using WEBCORE_API.Models.ViewModels;

namespace WEBCORE_API.Models.DTO
{
    public class DTOAccount
    {
        private AceEntities en;
        public DTOAccount()
        {
            en = new AceEntities();
        }

        public int Create(AccountView acc)
        {
            try
            {
                Account account = new Account
                {
                    Address = acc.Address,
                    Email = acc.Email,
                    Id = acc.Id,
                    Name = acc.Name,
                    Password = MD5S.Encrypt(acc.Password),
                    Phone = acc.Phone,
                    Roles = acc.Roles
                };
                en.Account.Add(account);
                en.SaveChanges();
                return account.Id;
            }
            catch
            {
                return -1;
            }
        }

        public List<AccountView> GetData()
        {
            return en.Account.Select(s => new AccountView
            {
                Address = s.Address,
                Email = s.Email,
                Id = s.Id,
                Name = s.Name,
                Password = s.Password,
                Phone = s.Phone,
                Roles = s.Roles ?? -1
            }).ToList();
        }

        public AccountView GetByID(int id)
        {
            return en.Account.Where(s => s.Id == id).Select(s => new AccountView
            {
                Address = s.Address,
                Email = s.Email,
                Id = s.Id,
                Name = s.Name,
                Password = s.Password,
                Phone = s.Phone,
                Roles = (int)s.Roles
            }).SingleOrDefault();
        }

        public bool Modify(AccountView acc)
        {
            try
            {
                Account account = en.Account.Find(acc.Id);
                account.Name = acc.Name;
                account.Password = acc.Password;
                account.Phone = acc.Phone;
                acc.Roles = acc.Roles;
                account.Address = acc.Address;
                account.Email = acc.Email;
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
                en.Account.Remove(en.Account.Find(id));
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
