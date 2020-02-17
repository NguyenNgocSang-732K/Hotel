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
    public class OrderController : ControllerBase
    {
        private HotelContext db;
        public OrderController(HotelContext _db)
        {
            db = _db;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var list = await db.Orders.AsNoTracking().Select(s => new
                {
                    Id = s.Id,
                    DateCreate = s.Date,
                    Start = s.DateStart,
                    End = s.DateEnd,
                    CusID = s.IdCus,
                    CusName = s.IdCusNavigation.Name,
                    RoomID = s.IdRoom,
                    RoomName = s.IdRoomNavigation.Name,
                    Total = s.Total,
                    EmpID = s.IdEmp,
                    EmpName = s.IdEmpNavigation.Name
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
                var orders = await db.Orders.AsNoTracking().Where(s => s.Id == id).Select(s => new
                {
                    Id = s.Id,
                    DateCreate = s.Date,
                    Start = s.DateStart,
                    End = s.DateEnd,
                    CusID = s.IdCus,
                    CusName = s.IdCusNavigation.Name,
                    RoomID = s.IdRoom,
                    RoomName = s.IdRoomNavigation.Name,
                    Total = s.Total,
                    EmpID = s.IdEmp,
                    EmpName = s.IdEmpNavigation.Name
                }).SingleOrDefaultAsync();
                return Ok(orders);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Orders o)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Orders.Add(o);
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