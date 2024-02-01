using Application.ViewModels;
using AutoMapper;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager
            , IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        //doesnot works
        public async Task<IActionResult> Register(RegisterViewModel userVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("User", "Invalid Credientials");
                return View();
            }

            var user = _userManager.FindByEmailAsync(userVM.Email);
            if (user.Result != null) return BadRequest();

            var appUser = new AppUser()
            {
                Email = userVM.Email,
                

            };

            var singinResult = await _userManager.CreateAsync(appUser, userVM.Password);

            if (singinResult.Succeeded)
            {
                await _signInManager.SignInAsync(appUser, false);
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("user", "Error, could not create user");
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("User", "error login credentials");
                return View();
            }
            var signInResult = await _signInManager.PasswordSignInAsync(loginVM.UserName, loginVM.Password,
                loginVM.RememberMe, false);
            if (signInResult.Succeeded)
            {

                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("SignIn", "Error signing in");
            return View();
        }

    }
}
