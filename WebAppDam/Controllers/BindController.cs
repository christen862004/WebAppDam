using Microsoft.AspNetCore.Mvc;
using WebAppDam.Models;

namespace WebAppDam.Controllers
{
    public class BindController : Controller
    {
        //Model Bind (action paremet value ==> requset)
        /*
            <form action ="/Bind/TestPrimitive" method="get">
                <input name="age">
                <input name="name">
                <input type="sumbit">
            </fomr>
         */
        //Bind/TestPrimitive?name=ahmed&age=13&id=999&color=red&color=blue   <id queryStrin>
        //Bind/TestPrimitive/999?name=ahmed&age=13      <id Route Vlaues>
        public IActionResult TestPrimitive(string[] color,int age ,string name,int id)
        {
            return Content("hiii");
        }

        //Test Collection list | Dictionary
        //Bind/TestDic?name=christen&Phones[ahmed]=123&Phones[mohamed]=456
        public IActionResult TestDic(string name,Dictionary<string,string> Phones)
        {
            return Content("hiii");
        }

        //Custom Class "object"
        //bind/Testobj?id=1&name=sd&managername=ahmed&Employees[0].Name=xyz
        public IActionResult TestObj(Department dept)
      //  public IActionResult TestObj(int Id, string Name, string ManagerName, List<Employee> Employees)
        {
            return Content("hiii");

        }
    }
}
