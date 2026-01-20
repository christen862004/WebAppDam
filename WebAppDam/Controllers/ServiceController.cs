using Microsoft.AspNetCore.Mvc;
using WebAppDam.Repository;

namespace WebAppDam.Controllers
{
    public class ServiceController : Controller
    {
        private readonly ITestRepository testREpo;

        public ServiceController(ITestRepository testREpo)//con
        {
            this.testREpo = testREpo;
        }
        //Service/index
        public IActionResult Index()
        {
            //sebd service id to view
            ViewData["Id"] = testREpo.Id;
            return View("Index");
        }
    }
}
