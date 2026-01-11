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
            //build
            var app = builder.Build();
            
            // Configure the HTTP request pipeline.Middleware Day2
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            //runa pp
            app.Run();
        }
    }
}
