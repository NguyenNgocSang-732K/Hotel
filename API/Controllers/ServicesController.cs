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
    public class ServicesController : ControllerBase
    {
        private HotelContext db;
        public ServicesController(HotelContext _db)
        {
            db = _db;
        }
        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpGet("get")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var list = await db.Services.AsNoTracking().Select(s => new
                {
                    Id = s.Id,
                    Name = s.Name,
                    Price = s.Price
                }).ToListAsync();
                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var list = await db.Services.AsNoTracking().Where(s => s.Id == id).Select(s => new
                {
                    Id = s.Id,
                    Name = s.Name,
                    Price = s.Price
                }).SingleOrDefaultAsync();
                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Services sv)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Services.Add(sv);
                    await db.SaveChangesAsync();
                    return Ok(sv);
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

        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPut("modify")]
        public async Task<IActionResult> Modify([FromBody] Services sv)
        {
            try
            {
                Services services = db.Services.Find(sv.Id);
                if (services == null)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    db.Services.Attach(services);
                    db.Entry(services).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return Ok(sv);
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

        [HttpDelete("remove/{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                Services services = db.Services.Find(id);
                if (services == null)
                {
                    return NotFound();
                }
                db.Services.Remove(services);
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