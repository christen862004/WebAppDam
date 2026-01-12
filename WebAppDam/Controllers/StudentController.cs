using Microsoft.AspNetCore.Mvc;
using WebAppDam.Models;

namespace WebAppDam.Controllers
{
    
    public class StudentController : Controller
    {
        StudentBL bl=new StudentBL();
        public IActionResult All()
        {
            List<Student> students = bl.GetAll();//ask ,get
            return View("ShowAll",students);//send Mode
            //View : Showall "/Views/Student/ShowAll.cshtml
            //Model : List<student>
        }
        //endpint take id return student
        //Student/DEtails
        public IActionResult Details(int id)
        {
            Student stdModel= bl.GetById(id);
            return View("Details", stdModel);
            //go To View DEtails
            //send <model type Student
        }
    }
}
