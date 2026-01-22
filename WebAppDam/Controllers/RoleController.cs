using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.DependencyResolver;

namespace WebAppDam.Controllers
{
    [Authorize(Roles ="Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(RoleViewModel rolevm)
        {
            if (ModelState.IsValid)
            {
                //add db
                IdentityRole roleModel = new IdentityRole()
                {
                    Name = rolevm.RoleName
                };

                IdentityResult result=await roleManager.CreateAsync(roleModel);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "Employee");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View("Add",rolevm);
        }
    }
}
