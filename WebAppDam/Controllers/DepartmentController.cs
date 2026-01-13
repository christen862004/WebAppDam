using Microsoft.AspNetCore.Mvc;
using WebAppDam.Models;
//using WebAppDam.ViewModels;

namespace WebAppDam.Controllers
{
    public class DepartmentController : Controller
    {
        ITIContext context = new();
        public DepartmentController()
        {
            
        }
        //Department/index
        public IActionResult Index()
        {
            List<Department> Depts= context.Departments.ToList();//Day8
            return View("Index",Depts);//List<department>
        }

        public IActionResult Details(int id)
        {
            //Extra Info
            string message = "hello";
            int temp = 10;
            List<string> branches=new List<string>() { "Alx","Smart","New Capital"};
            //Set ViewData
            ViewData["Msg"] = message;//boxing to object
            ViewData["Temp"] = temp;//box to obj
            ViewData["Branches"] = branches;
            ViewData["Color"] = "yellow";

            ViewBag.test = "hhhhhhh";//ViewData["test"]="hhhhhh";
            ViewBag.Color = "Blue";  //ViewData["Color"]="" override

            Department deptModel = context.Departments.FirstOrDefault(d => d.Id == id);
            //1
            return View("Details", deptModel);
            //go View ,Mode Department,ViewData 
        }
        
        public IActionResult DetailsVM(int id)
        {
            //Collect Inof
            string message = "hello";
            int temp = 10;
            List<string> branches=new List<string>() { "Alx","Smart","New Capital"};
            string Color = "red";
            Department deptModel = context.Departments.FirstOrDefault(d => d.Id == id);

            //Decalre VM
            DeptNameWithBranchesColorMsgTempViewModel deptVM = new();
            
            //Map 
            deptVM.DeptID = deptModel.Id;
            deptVM.DeptName = deptModel.Name;
            deptVM.Message = message;
            deptVM.Color = "red";
            deptVM.Temp = 10;
            deptVM.Brancehes= branches;


            //send ViewModel To View
            return View("DetailsVM", deptVM);
            //go View ,Mode DeptNameWithBranchesColorMsgTempViewModel
        }
    }
}
