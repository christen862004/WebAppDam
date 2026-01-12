using Microsoft.AspNetCore.Mvc;
using WebAppDam.Models;

namespace WebAppDam.Controllers
{
    public class DepartmentController : Controller
    {
        ITIContext context = new();
        public IActionResult Index()
        {
            List<Department> Depts= context.Departments.ToList();//Day8
            return View("Index",Depts);//List<department>
        }
    }
}
