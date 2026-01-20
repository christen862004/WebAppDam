using WebAppDam.Models;

namespace WebAppDam.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        ITIContext context;
        public EmployeeRepository(ITIContext _ctx)
        {
            context = _ctx;//new ITIContext();
        }
        public void Add(Employee Obj)
        {
            context.Employees.Add(Obj);
        }

        public void Delete(int id)
        {
            Employee emp = GetById(id);
            context.Employees.Remove(emp);
        }

        public void Edit(Employee Obj)
        {
            Employee empFromDb = GetById(Obj.Id);
            empFromDb.Name = Obj.Name;
            empFromDb.Salary = Obj.Salary;
            empFromDb.ImageUrl = Obj.ImageUrl;
            empFromDb.Email = Obj.Email;
            empFromDb.DepartmentId = Obj.DepartmentId;
            
        }

        public List<Employee> GetAll()
        {
            return context.Employees.ToList();
        }

        public Employee GetById(int id)
        {
            return context.Employees.FirstOrDefault(e => e.Id == id);
        }

        public int Save()
        {
            return context.SaveChanges();
        }
    }
}
