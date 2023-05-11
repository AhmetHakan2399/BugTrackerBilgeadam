using BugTrackerIdentityProject.Models;
using BugTrackerIdentityProject.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BugTrackerIdentityProject.Controllers
{
    
    public class AccountController : Controller
    {
        private readonly SignInManager<Kullanici> _signInManager;
        private readonly UserManager<Kullanici> _userManager;
        private ApplicationDbContext _context;
        public AccountController(SignInManager<Kullanici> signInManager, UserManager<Kullanici> userManager,ApplicationDbContext context)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
            
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if(ModelState.IsValid)
            {
                var result = _signInManager.PasswordSignInAsync(model.KullaniciAdi, model.Sifre, model.BeniHatirla, lockoutOnFailure: false).Result;
                if(result.Succeeded)
                {
                    return Redirect("/Home/Index");
                }   
                else
                {
                    ViewBag.Hata = "Hatalı Kullanıcı Adı Veya Şifre";
                    return View();
                }
                return Redirect("/Home/Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                Kullanici kullanici = new Kullanici
                {

                    UserName = model.KullaniciAdi,
                    AdiSoyAdi = model.AdiSoyAdi,
                    Email = model.KullaniciAdi,
                    KullaniciRolü = model.KullaniciRolü
                };

                var result = _userManager.CreateAsync(kullanici, model.Sifre).Result;
                if (result.Succeeded)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    ViewBag.Hata = "Hatalı Kullanıcı Bilgisi";
                    return View();
                }
            }

            return View();
        }
    }
}
