using Microsoft.AspNetCore.Mvc;
using WebAppDam.Models;

namespace WebAppDam.Controllers
{
    public class EmployeeController : Controller
    {
        ITIContext context = new ITIContext();
        public IActionResult Index()
        {
            List<Employee> employees = context.Employees.ToList(); ;
            return View("Index",employees);
        }
        #region Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            //Collect
            Employee EmpModel= context.Employees.FirstOrDefault(e=>e.Id== id);
            List<Department> DEptList = context.Departments.ToList();
            if (EmpModel != null)
            {
                
                //Delecte && MApping
                EmpWithDeptListViewModel EmpVM = new EmpWithDeptListViewModel() { 
                    Id=EmpModel.Id,
                    Name=EmpModel.Name,
                    Salary=EmpModel.Salary,
                    ImageUrl=EmpModel.ImageUrl,
                    DepartmentId=EmpModel.DepartmentId,
                    Email=EmpModel.Email,
                    DeptList=DEptList
                };
                //send VM to View
                return View("Edit", EmpVM);
            }
            else
                return NotFound();
        }

        [HttpPost]
        public IActionResult SaveEdit(EmpWithDeptListViewModel EmpFromReq)
        {
            if (EmpFromReq.Name != null)
            {
                //get old ref
                Employee empFromDB = context.Employees.FirstOrDefault(e => e.Id == EmpFromReq.Id);
                //set
                empFromDB.Name = EmpFromReq.Name;
                empFromDB.Salary = EmpFromReq.Salary;
                empFromDB.ImageUrl = EmpFromReq.ImageUrl;
                empFromDB.Email = EmpFromReq.Email;
                empFromDB.DepartmentId = EmpFromReq.DepartmentId;
                context.SaveChanges();
                //return index
                return RedirectToAction("Index", "Employee");
            }
            //ViewModel
            EmpFromReq.DeptList = context.Departments.ToList();
            return View("Edit", EmpFromReq);
        }
        #endregion
    }
}
