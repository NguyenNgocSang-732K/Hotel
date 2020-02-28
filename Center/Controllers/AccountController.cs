using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Center.Models.Dao;
using Center.Models.ModelView;
using Center.Supports;
using Microsoft.AspNetCore.Mvc;

namespace Center.Controllers
{
    [Route("account")]
    public class AccountController : Controller
    {
        [HttpGet("login")]
        public IActionResult Login()
        {
            AccountView account = new AccountView();
            return View(account);
        }

        [HttpPost("login")]
        public IActionResult Login(AccountView account)
        {
            AccountView accountView = AccountDTO.Login(account.Email, account.Password);
            if (accountView != null)
            {
                SercurityManager.Login(this.HttpContext, accountView);
                return RedirectToAction("index", "home"); // Chỗ quan trọng: bắt buộc return Redirect để refresh lại trang (refresh lại httpContext, nó mới nhận được cookie, nhiều người chỉ để return View() => ko nhận được cookie)
            }
            else
            {
                ViewBag.Error = "Error: Sai tên tài khoản hoặc mật khẩu.";
                return View("login");
            }
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            SercurityManager.Logout(this.HttpContext);
            return RedirectToAction("index", "home");
        }
    }
}