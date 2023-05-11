using BugTrackerIdentityProject.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BugTrackerIdentityProject.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private ApplicationDbContext Context;
        private readonly UserManager<Kullanici> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public HomeController(ApplicationDbContext context, UserManager<Kullanici> userManager)
        {
			Context = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var liste = Context.Hatalar.Include(x => x.User).ToList();
            List<HataViewModel> viewModels = new List<HataViewModel>();
            foreach (var item in liste)
            {
                viewModels.Add(new HataViewModel
                {
                    
                    HataBaslik = item.HataBaslik,
                    HataDetay = item.HataDetay,
                    HataId = item.Id,
					KullaniciAdi = item.User.UserName,
					KullaniciId = item.UserId


                });
            }
            return View(viewModels);
        }
        [HttpGet]
        public IActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Ekle(Hata hata)
        {

			hata.UserId = _userManager.GetUserId(HttpContext.User);
			Context.Hatalar.Add(hata);
			Context.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public IActionResult Detay(int id)
        {
            var detay = Context.Hatalar.Include(x => x.User ).Where(x => x.Id == id);
            List<DetayViewModel> viewModels = new List<DetayViewModel>();
            foreach (var item in detay)
            {
                viewModels.Add(new DetayViewModel
                {
                   
                    KayıtTarihi = item.KayitTarihi,
                    HataId = item.Id,
                    KullaniciAdi = item.User.UserName,
                    KullaniciId = item.User.Id,
					HataBaslik = item.HataBaslik,
					HataDetay = item.HataDetay,
					HataDurum = item.HataDurum,


				});
            }
           
            return View(viewModels);
        }
        public IActionResult Sil(int id)
        {
            var result = Context.Hatalar.FirstOrDefault(x => x.Id == id);
			Context.Hatalar.Remove(result);
			Context.SaveChanges();
            return RedirectToAction("Index");
        }
		[HttpGet]
		public IActionResult Guncelle(int id)
		{
			var result = Context.Hatalar.First(x => x.Id == id);
			return View(result);
		}

		[HttpPost]
		public IActionResult Guncelle(Hata hata)
		{
			Context.Update(hata);
			Context.SaveChanges();
			return RedirectToAction("Index");
		}
		[HttpGet]
        public IActionResult Profil(string Id)
        {
            var result = Context.Users.First(x => x.Id == Id);
            return View(result);
        }

    }
}