using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEBCORE_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAccount()
        {
            List<string> list = new List<string>
            {
                "Nguyễn Ngọc Sáng",
                "Nguyễn Thị Huỳnh Như",
                "D. Ace"
            };
            return new ObjectResult(list);
        }
    }
}