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
    public class RoomController : ControllerBase
    {
        private HotelContext db;
        public RoomController(HotelContext _db)
        {
            db = _db;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var list = await db.Room.AsNoTracking().Select(s => new
                {
                    Id = s.Id,
                    Name = s.Name,
                    Price = s.Price,
                    IdEmp = s.IdEmp,
                    NameEmp = s.IdEmpNavigation.Name
                }).ToListAsync();
                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{start}/{end}")]
        public async Task<IActionResult> Get(DateTime start, DateTime end)
        {
            try
            {
                var list = await db.Booking.AsNoTracking().Where(s => !(s.DateStart >= start || start <= s.DateStart || end >= s.DateEnd || end <= s.DateEnd || start <= s.DateStart || end >= s.DateEnd)).Select(s => new
                {

                }).ToListAsync();
                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var room = await db.Room.Where(s => s.Id == id).Select(s => new
                {
                    Id = s.Id,
                    Name = s.Name,
                    Price = s.Price,
                    IdEmp = s.IdEmp,
                    NameEmp = s.IdEmpNavigation.Name
                }).SingleOrDefaultAsync();
                if (room == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(room);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Room r)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Room.Add(r);
                    await db.SaveChangesAsync();
                    return Ok();
                }
                return BadRequest("Dữ liệu không hợp lệ");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Modify(int id, [FromBody]Room r)
        {
            try
            {
                Room room = db.Room.Find(id);
                if (!ModelState.IsValid)
                {
                    return BadRequest("Dữ liệu không hợp lệ");
                }
                if (room == null)
                {
                    return NotFound();
                }
                db.Room.Attach(r);
                db.Entry(r).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return Ok();

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                Room r = db.Room.Find(id);
                if (r == null)
                {
                    return NotFound();
                }
                db.Room.Remove(r);
                await db.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}