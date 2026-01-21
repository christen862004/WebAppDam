using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAppDam.Filtters;

namespace WebAppDam.Controllers
{
    // [HandelError]
  //  [Authorize]
    public class RouteController : Controller
    {
        //[HandelError]
        //[MyAction]
        [AllowAnonymous]
        public IActionResult TestFilter1()
        {
            throw new Exception("Some Exception Throw");
        }
        
        public IActionResult TestFilter2()
        {
            throw new Exception("Some Exception Throw");
        }

        //[HttpGet]
        //[Route("r1/{age:int}/{name?}",Name ="Route1")]//the only way reach to this endpoint
        [HttpGet("r1/{age}/{name}")]
        public IActionResult Method1()//int age,string name)
        {
            return Content("MEthod1");
        }
        //r1/MEthod2
        public IActionResult Method2()
        {
            return Content("MEthod2");
        }
    }
}
