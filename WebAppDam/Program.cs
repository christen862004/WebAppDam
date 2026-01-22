using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebAppDam.Filtters;
using WebAppDam.Models;
using WebAppDam.Repository;

namespace WebAppDam
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Configure web app
            
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //1) Built in service ,already register
            //2) Built in service ,need to  register

            builder.Services.AddControllersWithViews();
            //builder.Services.AddControllersWithViews(options =>
            //{
            //    options.Filters.Add(new HandelErrorAttribute());//global attribute
            //});
            builder.Services.AddSession(sessionOption => {
                sessionOption.IdleTimeout = TimeSpan.FromMinutes(30);
            });
            builder.Services.AddDbContext<ITIContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
            });//REgsiter DbContextOption ,ITIContext paremeter Constructor

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(option =>
            {
                option.Password.RequiredLength = 4;
                option.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<ITIContext>();
           
            
            //3) cutom Service and need to register
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();//register
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();//register
            builder.Services.AddScoped<ITestRepository, TestRepository>();//register
            //build
            var app = builder.Build();
            #region Custom Middleware
            //inline Middleware
            //app.Use(async (httpContext,nextMiddleware) => {
            //    await httpContext.Response.WriteAsync("1- Middleware 1 \n");//write response
            //    await nextMiddleware.Invoke(); //Call NExt Middleware
            //    await httpContext.Response.WriteAsync("1-1 Middleware 1-1 \n");//write response
            //});

            //app.Use(async (httpContext, nextMiddleware) => {
            //   // 
            //    await httpContext.Response.WriteAsync("2- Middleware 2 \n");//write response
            //    await nextMiddleware.Invoke(); //Call NExt Middleware
            //    await httpContext.Response.WriteAsync("2-2 Middleware 2-2 \n");//write response

            //});

            //app.Run(async (httpcontext) => {
            //    await httpcontext.Response.WriteAsync("3- Terminate\n");
            //});//treminate

            #endregion

            #region Configure the HTTP request pipeline.Middleware Day2
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");//First - Last
            }
            app.UseStaticFiles();//Req serach for req in wwwroot

            app.UseRouting();//Map Contoller + Action
            
            app.UseSession();

            app.UseAuthorization();
            //R1=>Route/MEthod1 Route Constarint
            //app.MapControllerRoute("Route1", "R1/{age:int:range(20,60)}/{name?}", new { controller="Route" ,action="Method1" });
            //app.MapControllerRoute("Route1", "{controller}/{action}/{id?}", new { controller="Route" ,action="Method1" });
           // app.MapControllerRoute("Route2", "R2", new { controller="Route" ,action="Method2" });

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            #endregion
            app.Run();
        }
    }
}
