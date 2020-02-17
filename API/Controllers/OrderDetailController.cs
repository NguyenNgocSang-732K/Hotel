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
    public class OrderDetailController : ControllerBase
    {
        private HotelContext db;
        public OrderDetailController(HotelContext _db)
        {
            db = _db;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var list = await db.OrderDetails.AsNoTracking().Where(s => s.OrderId == id).Select(s => new
                {
                    SvID = s.ServicesId,
                    SvName = s.Services.Name,
                    Quantity = s.Quantity,
                    Date = s.Date,
                    Price = s.Price,
                }).ToListAsync();
                if (list == null)
                {
                    return NotFound("Không có mã hoá đơn này");
                }
                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(List<OrderDetails> list)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.OrderDetails.AddRange(list);
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
    }
}