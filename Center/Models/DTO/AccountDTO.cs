using Center.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Center.Models.ModelView;
using Microsoft.EntityFrameworkCore;
using API.Supports;

namespace Center.Models.Dao
{
    public class AccountDTO
    {
        private static AceEntities db;

        public static List<AccountView> Get()
        {
            db = new AceEntities();
            return db.Account.AsNoTracking().Select(s => new AccountView
            {
                Id = s.Id,
                Email = s.Email,
                Address = s.Address,
                Name = s.Name,
                Password = s.Password,
                Phone = s.Phone
            }).ToList();
        }

        public static AccountView GetByID(int id)
        {
            db = new AceEntities();
            return db.Account.AsNoTracking().Where(s => s.Id == id).Select(s => new AccountView
            {
                Id = s.Id,
                Email = s.Email,
                Address = s.Address,
                Name = s.Name,
                Password = s.Password,
                Phone = s.Phone,
                Role = (int)s.Roles
            }).SingleOrDefault();
        }

        public static int Create(AccountView acc)
        {
            db = new AceEntities();
            Account account = new Account
            {
                Name = acc.Name,
                Email = acc.Email,
                Address = acc.Address,
                Password = acc.Password,
                Phone = acc.Phone,
                Roles = acc.Role
            };
            db.Account.Add(account);
            db.SaveChanges();
            return account.Id;
        }

        public static bool Modify(AccountView acc)
        {
            try
            {
                db = new AceEntities();
                Account account = new Account
                {
                    Name = acc.Name,
                    Email = acc.Email,
                    Address = acc.Address,
                    Password = acc.Password,
                    Phone = acc.Phone,
                    Roles = acc.Role
                };
                db.Account.Attach(account);
                db.Entry(account).State = EntityState.Modified;
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
                db.Account.Remove(db.Account.Find(id));
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static AccountView Login(string email, string password)
        {
            try
            {
                db = new AceEntities();
                string passHash = MD5_Sang.Encrypt(password);
                Account acc = db.Account.SingleOrDefault(s => s.Email.Equals(email) && s.Password.Equals(passHash));
                if (acc != null)
                {
                    return new AccountView
                    {
                        Id = acc.Id,
                        Email = acc.Email,
                        Address = acc.Address,
                        Name = acc.Name,
                        Password = acc.Password,
                        Phone = acc.Phone,
                        Role = (int)acc.Roles
                    };
                }
                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
