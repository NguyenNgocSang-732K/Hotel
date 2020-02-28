using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private HotelContext db;
        public BookingController(HotelContext _db)
        {
            db = _db;
        }
        [Consumes("application/json")]
        [HttpGet("get")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var bookList = await db.Booking.AsNoTracking().Select(s => new
                {
                    Id = s.Id,
                    RoomName = s.Room.Name,
                    DateStart = s.DateStart,
                    DateEnd = s.DateEnd,
                    CustomerName = s.IdCustomerNavigation.Name,
                    Status = s.Status
                }).ToListAsync();
                return Ok(bookList);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("get/{id}")]
        [Consumes("application/json")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var s = await db.Booking.AsNoTracking().FirstAsync(s => s.Id == id);
                if (s == null)
                {
                    return NotFound("Không tìm thấy");
                }
                var book = new
                {
                    Id = s.Id,
                    RoomName = s.Room.Name,
                    DateStart = s.DateStart,
                    DateEnd = s.DateEnd,
                    CustomerName = s.IdCustomerNavigation.Name,
                    Status = s.Status
                };
                return Ok(book);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("modify/{id}")]
        [Consumes("application/json")]
        public async Task<IActionResult> Modify(int id, [FromBody]int status)
        {
            try
            {
                string stt = status == 0 ? "Đang đặt phòng" : (status == 1 ? "Đang ở" : (status == 2 ? "Đã thanh toán" : "Đã huỷ"));
                Booking b = db.Booking.Find(id);
                if (b == null)
                {
                    return NotFound("Không tìm thấy");
                }
                b.Status = stt;
                await db.SaveChangesAsync();
                return Ok(b);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody]Booking b)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (CheckDate((DateTime)b.DateStart, (DateTime)b.DateEnd))
                    {
                        db.Booking.Add(b);
                        await db.SaveChangesAsync();
                        return Ok(b);
                    }
                    else
                    {
                        return BadRequest("Đã có người thuê");
                    }
                }
                else
                {
                    return BadRequest("Dữ liệu không hợp lệ");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
       

        private bool CheckDate(DateTime start, DateTime end)
        {
            return db.Booking.Any(s =>
                (start >= s.DateStart && start <= s.DateEnd) ||
                (s.DateStart >= start && s.DateStart <= end)
            );
        }
    }
}