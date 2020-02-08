using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private HotelContext db;
        public WeatherForecastController(HotelContext _db)
        {
            db = _db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var account = db.Account.Select(s => new
            {
                Id = s.Id,
                Name = s.Name,
                Phone = s.Phone,
                Address = s.Address,
                Email = s.Email
            });
            return new ObjectResult(account);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var account = db.Account.Where(s => s.Id == id).Select(s => new
            {
                Id = s.Id,
                Name = s.Name,
                Phone = s.Phone,
                Address = s.Address,
                Email = s.Email
            }); ;
            return new ObjectResult(account);
        }

        [HttpPost]
        public IActionResult Create()
    }
}
