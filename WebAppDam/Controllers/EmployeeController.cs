using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAppDam.Models;
using WebAppDam.Repository;

namespace WebAppDam.Controllers
{
    public class EmployeeController : Controller
    {
        // ITIContext context = new ITIContext();
        IEmployeeRepository empRepo;
        IDepartmentRepository departmentRepo;
        public EmployeeController(IEmployeeRepository _EmpRepo, IDepartmentRepository _deptRepo)//Primary Contrsutor
        {
            empRepo = _EmpRepo;// new EmployeeRepository();
            departmentRepo = _deptRepo;// new DepartmentRepository();
        }
        [Authorize]//Check Cookie
        public IActionResult Index()    
        {
            List<Employee> employees = empRepo.GetAll();
            return View("Index",employees);
        }

        #region Valiadtion REmote   

        public IActionResult CheckSalary(int Salary,string Name)
        {
            if (Salary > 9000)
                return Json(true);//valia
            return Json(false);//invali
        }
        #endregion

        #region NEw Using Tage
        [HttpGet]
        public IActionResult New()
        {
            ViewData["DeptList"] = departmentRepo.GetAll();//List<Department>
            return View("New");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]//check req.formData["__Verifi...."]
        public IActionResult SaveNew(Employee EmpFromReq)
        {
            //Server Side
            if(ModelState.IsValid)
            {
                try
                {
                    empRepo.Add(EmpFromReq);
                    empRepo.Save();
                    return RedirectToAction("Index", "Employee");
                }catch(Exception ex)//sl exception
                {
                    ModelState.AddModelError("exception", ex.InnerException.Message);
                }
            }
            ViewData["DeptList"] = departmentRepo.GetAll();
            return View("New",EmpFromReq);
        }
        #endregion
        #region Details
        public IActionResult Details(int id,string name)
        {
            return Content($"Id={name}");
        }
        #endregion

        #region Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            //Collect
            Employee EmpModel= empRepo.GetById(id);
            List<Department> DEptList = departmentRepo.GetAll();
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
                Employee emp = new();
                emp.Id=EmpFromReq.Id;
                emp.Name = EmpFromReq.Name;
                emp.Salary = EmpFromReq.Salary;
                emp.ImageUrl = EmpFromReq.ImageUrl;
                emp.Email = EmpFromReq.Email;
                emp.DepartmentId = EmpFromReq.DepartmentId;
                empRepo.Edit(emp);
                empRepo.Save();
                //return index
                return RedirectToAction("Index", "Employee");
            }
            //ViewModel
            EmpFromReq.DeptList = departmentRepo.GetAll();
            return View("Edit", EmpFromReq);
        }
        #endregion
    }
}
