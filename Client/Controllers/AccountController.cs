using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Client.Models.DTO;
using Client.Models.ModelView;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    [Route("acount")]
    public class AccountController : Controller
    {
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {

            return View();
        }

        [Route("login")]
        public IActionResult Login(Account account)
        {
            var acc = AccountDTO.LoginAsync("nguyenngocsang0868@gmail.com", "123");
            return View();
        }
    }
}