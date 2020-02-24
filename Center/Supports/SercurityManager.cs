using Center.Models.ModelView;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Center.Supports
{
    public class SercurityManager
    {

        public static void Login(HttpContext httpContext, AccountView account)
        {
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(GetUserClaim(account), CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);
        }

        public static void Logout(HttpContext httpContext)
        {
            httpContext.SignOutAsync();
        }

        private static IEnumerable<Claim> GetUserClaim(AccountView account)
        {
            List<Claim> list = new List<Claim>();
            list.Add(new Claim(ClaimTypes.Name, account.Name));
            list.Add(new Claim(ClaimTypes.Email, account.Email));
            list.Add(new Claim(ClaimTypes.Role, account.Role + ""));
            return list;
        }
    }
}
