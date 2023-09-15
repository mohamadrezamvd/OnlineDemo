using Microsoft.AspNetCore.Mvc;
using OnlineDemo.Helpers;
using OnlineDemo.Models;
using System.Diagnostics;

namespace OnlineDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly OnlineDemoDatabaseContext _context;
        private readonly OnlineUsersHelper _helper;

        public HomeController(OnlineDemoDatabaseContext context,OnlineUsersHelper helper)
        {
            _context = context;
            _helper = helper;
        }

        public void ImOnline()
        {
            int userId = (int)HttpContext.Session.GetInt32("UserId");
            _helper.Update(userId);
        }

        public IActionResult IsOnline()
        {
            return PartialView(_helper.OnlineUsers);
        }

        public IActionResult Index()
        {
            if (!HttpContext.Session.Keys.Contains("UserId"))
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username,string password)
        {
            var user = _context.Users.Where(u => u.Username == username && u.Password == password).FirstOrDefault();
            if (user != null)
            {
                HttpContext.Session.SetInt32("UserId",user.UserId);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}