using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebAppDam.Filtters;

namespace WebAppDam.Controllers
{
    // [HandelError]
  //  [Authorize]
    public class RouteController : Controller
    {
        //without attribute
        public IActionResult ShowMessage()
        {
            if (User.Identity.IsAuthenticated)//cookie
            {
                 bool iAdmin=User.IsInRole("Admin");//clims.type=="http:///role"


                var list = User.Claims.ToList();
                Claim idClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
               // Claim nameClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);
                string id= idClaim.Value;

                string Address = User.Claims.FirstOrDefault(c => c.Type == "Address").Value;
                // Claim nameClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);
                

                return Content($"Welcome {User.Identity.Name} \t id={id}");

            }
            //autho welcom Ali
            //anonums Wecome Gust
            return Content("Welcome Gust");
        }

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
