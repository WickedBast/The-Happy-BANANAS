using HB.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HB.Repository.Repository.Application;
using HB.Repository.Interface.Application;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp.Web.DependencyInjection;

namespace HB.Presentation
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(options => options.UseMySql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IExtraServiceRepository, ExtraServiceRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IRoomImageRepository, RoomImageRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(options =>
                    {
                        options.LoginPath = "/Login/Index";
                    });

            services.AddImageSharp();
            services.AddSession();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddControllersWithViews();

            services.AddMvc(options => options.EnableEndpointRouting = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseAuthentication();
            app.UseSession();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthorization();

            app.UseImageSharp();


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "forgotpassword",
                    template: "/forgot-password",
                    defaults: new { controller = "ForgotPassword", action = "Index" });

                routes.MapRoute(
                 name: "register",
                 template: "/register",
                 defaults: new { controller = "Register", action = "SignUp" });

                routes.MapRoute(
                 name: "login",
                 template: "/log-in",
                 defaults: new { controller = "Login", action = "Login" });

                routes.MapRoute(
                 name: "account",
                 template: "/my-profile",
                 defaults: new { controller = "Account", action = "Index" });

                routes.MapRoute(
                 name: "signout",
                 template: "/sign-out",
                 defaults: new { controller = "Login", action = "Logout" });

                routes.MapRoute(
                 name: "contacts",
                 template: "/contacts",
                 defaults: new { controller = "Contact", action = "Index" });

                routes.MapRoute(
                    name: "reservation",
                    template: "/reservation",
                    defaults: new { controller = "Reservation", action = "Index" }
                    );

                routes.MapRoute(
                    name: "reservationDetail",
                    template: "/reservation/{slug}",
                    defaults: new { controller = "Reservation", action = "Detail" }
                    );

                routes.MapRoute(
                    name: "roomDetail",
                    template: "/room/{slug}",
                    defaults: new { controller = "RoomDetail", action = "Index" }
                    );

                routes.MapRoute(
                    name: "payment",
                    template: "/payment",
                    defaults: new { controller = "Payment", action = "Index" }
                    );

                routes.MapRoute(
                    name: "reservationHistory",
                    template: "/history",
                    defaults: new { controller = "History", action = "Index" }
                    );

                routes.MapRoute(
                    name: "extraService",
                    template: "/extraService",
                    defaults: new { controller = "ExtraService", action = "Index" }
                    );

                routes.MapRoute(
                    name: "comment",
                    template: "/comment",
                    defaults: new { controller = "Comment", action = "Index" }
                    );

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
