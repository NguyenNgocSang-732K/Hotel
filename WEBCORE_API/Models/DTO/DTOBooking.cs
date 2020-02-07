using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBCORE_API.Models.Entities;
using WEBCORE_API.Models.ViewModels;

namespace WEBCORE_API.Models.DTO
{
    public class DTOBooking
    {
        private AceEntities en;
        public DTOBooking()
        {
            en = new AceEntities();
        }

        public int Create(BookingView b)
        {
            try
            {
                Booking book = new Booking
                {
                    DateEnd = b.DateEnd,
                    DateStart = b.DateStart,
                    IdCustomer = b.IdCustomer,
                    RoomId = b.RoomId,
                    Status = b.Status
                };
                en.Booking.Add(book);
                en.SaveChanges();
                return book.Id;
            }
            catch
            {
                return -1;
            }
        }

        public List<BookingView> GetData()
        {
            return en.Booking.Select(s => new BookingView
            {
                Id = s.Id,
                CusName = s.IdCustomerNavigation.Name,
                DateEnd = (DateTime)s.DateEnd,
                DateStart = (DateTime)s.DateStart,
                IdCustomer = (int)s.IdCustomer,
                RoomId = (int)s.RoomId,
                RoomName = s.Room.Name + "",
                Status = s.Status
            }).ToList();
        }

        public BookingView GetByID(int id)
        {
            return en.Booking.Where(s => s.Id == id).Select(s => new BookingView
            {
                Id = s.Id,
                CusName = s.IdCustomerNavigation.Name,
                DateEnd = (DateTime)s.DateEnd,
                DateStart = (DateTime)s.DateStart,
                IdCustomer = (int)s.IdCustomer,
                RoomId = (int)s.RoomId,
                RoomName = s.Room.Name + "",
                Status = s.Status
            }).SingleOrDefault();
        }

        public bool Modify(BookingView b)
        {
            try
            {
                Booking book = en.Booking.Find(b.Id);
                book.DateEnd = b.DateEnd;
                book.DateStart = b.DateStart;
                book.RoomId = b.RoomId;
                book.Status = b.Status;
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
                en.Booking.Remove(en.Booking.Find(id));
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
