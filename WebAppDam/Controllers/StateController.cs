using Microsoft.AspNetCore.Mvc;

namespace WebAppDam.Controllers
{
    public class StateController : Controller
    {
        public IActionResult SetSession(string name,int age)
        {
            //logic
            //State
            HttpContext.Session.SetString("Name", name);
            HttpContext.Session.SetInt32("Age", age);
            //logic
            return Content("Session Save");
        }
        //at any controller you can read from session
        public IActionResult GetSession() {
            //logic 
            string? n= HttpContext.Session.GetString("Name");
            int? a= HttpContext.Session.GetInt32("Age");

            return Content($"Name={n}\tAge={a}");
        }

        //Cookie per Site and Client and Browser
        public IActionResult SetCookie(string name,int age)
        {
            //logic
            //server send infon to cient inside cookie
            //Session Cookie
            HttpContext.Response.Cookies.Append("Name", name);

            //Presistent Cookie
            CookieOptions options = new CookieOptions();
            options.Expires = DateTimeOffset.Now.AddHours(1);
            HttpContext.Response.Cookies.Append("Age", age.ToString(),options);

            return Content("Cookie Save");
        }

        //at any Contoller server Read Cookie
        public IActionResult GetCookie()
        {
            string n = HttpContext.Request.Cookies["Name"];
            string a = HttpContext.Request.Cookies["Age"];
            return Content($"Cookie {n}\t{a}");

        }
    }
}
