using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Center.Models.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Center
{
    public class Startup
    {

        private IConfiguration Configuration;
        public Startup(IConfiguration _Configuration)
        {
            Configuration = _Configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.LoginPath = "/account/login"; // Truy cập link khi chưa đăng nhập sẽ trở ra trang này
                options.LogoutPath = "/account/logout";
                options.AccessDeniedPath = "/account/accessDenied"; //Truy cập link ko đủ quyền sẽ trở ra trang này
                options.Cookie.Name = "CookieCuaNguyenNgocSang";
            });
            services.AddControllersWithViews();
            services.AddDbContext<AceEntities>(option => option.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("ConnectCuaSang")));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseStaticFiles();
            app.UseAuthentication(); //Xác nhận đã đăng nhập
            app.UseAuthorization(); // Xác nhận đủ quyền truy cập
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=home}/{action=index}/{id?}"
                    );
            });
        }
    }
}
