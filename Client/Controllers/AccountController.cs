using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Client.Models.DTO;
using Client.Models.Entities;
using Client.Sercuriry;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    [Route("acount")]
    public class AccountController : Controller
    {
        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("login")]
        public IActionResult Login(Account account)
        {

            Claim name = User.FindFirst(ClaimTypes.Name);
            Account acc = AccountDTO.LoginAsync(account);
            if (acc != null)
            {
                SercurityManager.Login(this.HttpContext, acc);
                return RedirectToAction("", "home");
            }
            TempData["error"] = "Sai tên tài khoản hoặc mật khẩu";
            return View();
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            SercurityManager.Logout(this.HttpContext);
            return RedirectToAction("login", "account");
        }
    }
}