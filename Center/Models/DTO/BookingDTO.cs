using Center.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Center.Models.ModelView;
using Microsoft.EntityFrameworkCore;

namespace Center.Models.Dao
{
    public class BookingDTO
    {
        private static AceEntities db;

        public static List<BookingView> Get()
        {
            db = new AceEntities();
            return db.Booking.AsNoTracking().Select(s => new BookingView
            {
                CusID = (int)s.IdCustomer,
                CusName = s.IdCustomerNavigation.Name,
                DateEnd = (DateTime)s.DateEnd,
                DateStart = (DateTime)s.DateStart,
                Id = s.Id,
                RoomID = (int)s.RoomId,
                RoomName = s.Room.Name + "",
                Status = s.Status
            }).ToList();
        }

        public static BookingView GetByID(int id)
        {
            db = new AceEntities();
            return db.Booking.AsNoTracking().Where(s => s.Id == id).Select(s => new BookingView
            {
                CusID = (int)s.IdCustomer,
                CusName = s.IdCustomerNavigation.Name,
                DateEnd = (DateTime)s.DateEnd,
                DateStart = (DateTime)s.DateStart,
                Id = s.Id,
                RoomID = (int)s.RoomId,
                RoomName = s.Room.Name + "",
                Status = s.Status
            }).SingleOrDefault();
        }

        public static int Create(BookingView b)
        {
            try
            {
                Booking book = new Booking
                {
                    DateEnd = b.DateEnd,
                    DateStart = b.DateStart,
                    IdCustomer = b.CusID,
                    RoomId = b.RoomID,
                    Status = b.Status
                };
                db.Booking.Add(book);
                db.SaveChanges();
                return book.Id;
            }
            catch
            {
                return -1;
            }
        }

        public static bool Update(BookingView b)
        {
            try
            {
                db = new AceEntities();
                Booking book = db.Booking.Find(b.Id);
                book.IdCustomer = b.CusID;
                book.RoomId = b.RoomID;
                book.Status = b.Status;
                book.DateEnd = b.DateEnd;
                book.DateStart = b.DateStart;
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
                db.Booking.Remove(db.Booking.Find(id));
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
