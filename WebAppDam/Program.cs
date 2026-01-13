namespace WebAppDam
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Configure web app
            
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession(sessionOption => {
                sessionOption.IdleTimeout = TimeSpan.FromMinutes(30);
            });//
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

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            #endregion
            app.Run();
        }
    }
}
