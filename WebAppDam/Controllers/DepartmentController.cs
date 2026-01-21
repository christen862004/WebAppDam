using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebAppDam.Models;
using WebAppDam.Repository;
//using WebAppDam.ViewModels;

namespace WebAppDam.Controllers
{
    public class DepartmentController : Controller
    {
        // ITIContext context = new();
        IDepartmentRepository departmentRepo;
        public DepartmentController(IDepartmentRepository _deptRepo)//ask Inject
        {
            departmentRepo =_deptRepo;// new DepartmentRepository();//depence
        }
        //Department/index
        public IActionResult Index()
        {
            
            List<Department> Depts= departmentRepo.GetAll();//Day8
            return View("Index",Depts);//List<department>
        }

        #region New Departemnt
        public IActionResult New()
        {
            return View("New");//Model = Null
        }
        //Department/SaveNew?Name=&ManagerName=
        //public IActionResult SaveNew(string Name,string ManagerName)

        //Action by defual handel Get|POST Req
        [HttpPost]
        public IActionResult SaveNew(Department DeptFromReq)//Create object
        {
           
            //if(this.Request.Method=="POST"){}
           //valiadtion server side C#
           if(DeptFromReq.Name != null) {
                //save db
                departmentRepo.Add(DeptFromReq);
                departmentRepo.Save();
                //go to another action
                return RedirectToAction("Index", "Department");
            }
            //opne the same view
            return View("New", DeptFromReq);
            //View New
            //Model Department
        }
        #endregion





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

            Department deptModel = departmentRepo.GetById(id);
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
            Department deptModel = departmentRepo.GetById(id);

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
