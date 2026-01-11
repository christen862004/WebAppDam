using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAppDam.Models;

namespace WebAppDam.Controllers
{
    //Controller/Action/id
    /*
     1) name of Class End With Controller
     2) must inherit from Controller Class 
     */
    public class HomeController : Controller
    {
        //Home/privacy   "endpoint"
        /*
         * Method called Action
         * 1) method Must be public 
         * 2) method cant be static
         * 3) method cant be overload (only in one cast)
         */
        //Home/showMsg
        //public string showMsg()
        //{
        //    return "Hello From Backendd";
        //}     
        public ContentResult showMsg()
        {
            //logic
            //DEclare
            ContentResult result=new ContentResult();
            //set
            result.Content = "Hello;";
            //return
            return result;
            
        }
        //Home/ShowView
        public ViewResult ShowView()
        {
            //logic
            return View("View1");
         
        }
        //public ViewResult View(string ViewNAme)
        //{
        //    ViewResult result = new ViewResult();
        //    //set viewname
        //    result.ViewName =ViewNAme;
        //    //return view
        //    return result;
        //}
        //Home/ShowMix?val=10&name=ahmed&id=99999
        //Home/ShowMix/888999?val=10&name=ahmed
        public IActionResult  ShowMix(int val,int id,string name)
        {
            if (val > 0)
            {
                //logic
                return View("View1");
            }
            else if (val < 0)
            {
                ContentResult result = new ContentResult();
                //set
                result.Content = "Hello;";
                //return
                return result;
            }
            else
            {
                NotFoundResult result = new NotFoundResult();
                return result;
            }

        }




        
        /*
         return type action can return
        1) Content ==> ContentREsult ==> Content
        2) View    ==> ViewResult    ==> View
        3) Json    ==> JsonREsult    ==> Json
        4) File    ==> FileREsult
        5) NotFount==> NotFountResult
        6) Empty
        7) UnAuthorie
        ................
         */












        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
