using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebAppDam.Models
{
    public class ITIContext:IdentityDbContext<ApplicationUser>
    {
        public DbSet<Employee>  Employees { get; set; }
        public DbSet<Department>  Departments { get; set; }

        //Way2 REgister IOC Container
        public ITIContext(DbContextOptions<ITIContext> options) : base(options)//appsetting
        { }

        #region Way1
        public ITIContext()
        {}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=DamDB;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");
        }
        #endregion
        //seeding data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
//            base.OnModelCreating(modelBuilder);//Best
            modelBuilder.Entity<IdentityUserLogin<string>>().HasNoKey();
            modelBuilder.Entity<IdentityUserRole<string>>().HasKey(new string[] { "UserId", "RoleId" });
            modelBuilder.Entity<IdentityUserToken<string>>().HasNoKey();
            modelBuilder.Entity<Department>().HasData(new Department() { Id = 1, Name ="SD",ManagerName="Ahmed"});
            modelBuilder.Entity<Department>().HasData(new Department() { Id = 2, Name ="UI",ManagerName="Mohamed"});
            modelBuilder.Entity<Department>().HasData(new Department() { Id = 3, Name ="OS",ManagerName="Khaled"});

            modelBuilder.Entity<Employee>().HasData(new Employee() { Id = 1, Name = "Ahmed", Salary = 10000, ImageUrl = "m.png", Email = "Ahemd@gmail.com", DepartmentId = 1 });
            modelBuilder.Entity<Employee>().HasData(new Employee() { Id = 2, Name = "Ali", Salary = 20000, ImageUrl = "m.png", Email = "Ahemd@gmail.com", DepartmentId = 2 });
            modelBuilder.Entity<Employee>().HasData(new Employee() { Id = 3, Name = "Sara", Salary = 30000, ImageUrl = "2.jpg", Email = "Ahemd@gmail.com", DepartmentId = 3 });
            modelBuilder.Entity<Employee>().HasData(new Employee() { Id = 4, Name = "Hala", Salary = 40000, ImageUrl = "2.jpg", Email = "Ahemd@gmail.com", DepartmentId = 1 });





        }
    }
}
