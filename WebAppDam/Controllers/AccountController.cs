using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebAppDam.Models;

namespace WebAppDam.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController
            (UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager )
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        #region Register
        
        [HttpGet]//open view
        public IActionResult Register()
        {
            return View("Register");
        }
        
        [HttpPost]//open view
        [ValidateAntiForgeryToken]//create user and assign role
        public async Task<IActionResult> Register(RegisterUserViewModel userVM)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser UserModel = new ApplicationUser()
                {
                    UserName = userVM.UserName,
                    PasswordHash = userVM.Password,
                    Address = userVM.Address
                };
                IdentityResult result= await  userManager.CreateAsync(UserModel,userVM.Password);
                if(result.Succeeded)
                {
                    //Assign to Admin Role
                    await userManager.AddToRoleAsync(UserModel, "Admin");//
                    //create cookie
                    await signInManager.SignInAsync(UserModel, false);//session - presitent
                    return RedirectToAction("Index", "Employee");
                }
                foreach (var errorItem in result.Errors)
                {
                    ModelState.AddModelError("", errorItem.Description);
                }
            }
            return View("Register",userVM);
        }
        #endregion

        #region Login
        [HttpGet]
        public IActionResult Login()
        {
            return View("Login");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUserViewModel userVM)
        {
            if(ModelState.IsValid)
            {
                ApplicationUser UserModel=await userManager.FindByNameAsync(userVM.UserName);
                if (UserModel != null)
                {
                    //check pass
                    bool found=await userManager.CheckPasswordAsync(UserModel, userVM.Password);
                    if (found)
                    {
                        //create cooke
                        List<Claim> addClaim = new List<Claim>();
                        addClaim.Add(new Claim("Address", UserModel.Address));
                        await signInManager.SignInWithClaimsAsync(UserModel, userVM.RememberMe,addClaim);//id,name,role,email 
                        //await  signInManager.SignInAsync(UserModel, userVM.RememberMe);//id,name,role,email 
                        return RedirectToAction("Index", "Employee");
                    }
                }
                ModelState.AddModelError("", "Invalid Account");
            }
            return View("Login",userVM);
        }
        #endregion

        public async Task<IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login","Account");
        }
    }
}
