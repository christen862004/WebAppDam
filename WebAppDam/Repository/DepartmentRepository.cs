using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using WebAppDam.Models;

namespace WebAppDam.Repository
{
    public class DepartmentRepository:IDepartmentRepository
    {
        ITIContext context;

        public DepartmentRepository(ITIContext _ctx)
        {
            context = _ctx;// new ITIContext();
        }
        public void Add(Department Obj)
        {
            context.Departments.Add(Obj);
        }

        public void Delete(int id)
        {
            Department dept=GetById(id);
            context.Departments.Remove(dept);
        }

        public void Edit(Department Obj)
        {
            Department deptFRomDb = GetById(Obj.Id);
            deptFRomDb.Name = Obj.Name;
            deptFRomDb.ManagerName = Obj.ManagerName;
        }

        //CRUD min
        public List<Department> GetAll()
        {
            return context.Departments.ToList();
        }
        

        public Department GetById(int id)
        {
            return context.Departments.FirstOrDefault(d => d.Id == id);
        }

        public int Save()
        {
            return context.SaveChanges();
        }
        
    }
}
