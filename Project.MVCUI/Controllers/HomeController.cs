using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.ENTITIES.Models;
using Project.MVCUI.Models;
using Project.MVCUI.Models.ViewModels.AppUsers;
using System.Diagnostics;

namespace Project.MVCUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        readonly UserManager<AppUser> _userManager;

        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
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

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterRequestModel model)
        {
            AppUser appUser = new()
            {
                UserName = model.UserName,
                Email = model.Email
            };

            IdentityResult result = await _userManager.CreateAsync(appUser ,model.Password);

            if (result.Succeeded)
            {
                TempData["Message"] = "Kayıt Başarılı Bir Şekilde Tamamlandı";
                return RedirectToAction("Index");
            }
            foreach (IdentityError item in result.Errors)
            {
                ModelState.AddModelError("",item.Description);
            }

            return View(model);
        }
    }
}
