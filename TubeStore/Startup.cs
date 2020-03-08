using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ModalNofications;
using ReflectionIT.Mvc.Paging;
using TubeStore.DataLayer;
using TubeStore.Hubs;
using TubeStore.Middleware;
using TubeStore.Models;
using TubeStore.Services;

namespace TubeStore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddAuthentication();

            services.AddIdentity<Customer, IdentityRole>(x=>
            {
                x.Lockout.MaxFailedAccessAttempts = 3;
            })
                .AddEntityFrameworkStores<TubeStoreDbContext>();
            
            services.AddDbContext<TubeStoreDbContext>(options => options.UseSqlServer(
                Configuration.GetConnectionString("DefaultConnection")));

            services.AddDistributedMemoryCache();
            services.AddSession();

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddRazorPages();

            services.AddSignalR(o =>
            {
                o.EnableDetailedErrors = true;
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IModalNotification, ModalNotification>();
            services.AddTransient<IEmailSender, EmailSender>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSession();
            app.UseStaticFiles();
            app.UseRouting();            
            
            app.UseCookiePolicy();            
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMiddleware(typeof(VisitorCounterMiddleware));
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=home}/{action=index}/{id?}");

                endpoints.MapAreaControllerRoute(
                    name: "areaAdmin",
                    areaName: "Admin",
                    pattern: "{area}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapHub<ChatHub>("/chatHub",
                    options => {
                        options.ApplicationMaxBufferSize = 64;
                        options.TransportMaxBufferSize = 64;
                        options.LongPolling.PollTimeout = TimeSpan.FromMinutes(1);
                        options.Transports = HttpTransportType.LongPolling | HttpTransportType.WebSockets;
                    });
            });
        }
    }
}
