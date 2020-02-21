using Client.Models.ModelView;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace Client.Sercuriry
{
    public class SercurityManager
    {

        public void Login(HttpContext httpContext, Account account)
        {
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(GetUserClaim(account), CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);
        }

        public void Logout(HttpContext httpContext)
        {
            httpContext.SignOutAsync();
        }

        private IEnumerable<Claim> GetUserClaim(Account acc)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, acc.Name));
            claims.Add(new Claim(ClaimTypes.Email, acc.Email));
            claims.Add(new Claim("Phone", acc.Phone));
            claims.Add(new Claim(ClaimTypes.Role, acc.Role + ""));
            return claims;
        }
    }
}
