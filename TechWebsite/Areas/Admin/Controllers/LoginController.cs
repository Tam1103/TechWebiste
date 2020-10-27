using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TechWebsite.Models;
using TechWebsite.Security;

namespace TechWebsite.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/login")]
    public class LoginController : Controller
    {
        private DatabaseContext db = new DatabaseContext();
        private SecurityManager securityManager = new SecurityManager();

        public LoginController(DatabaseContext _db)
        {
            db = _db;
        }

        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [Route("process")]
        public IActionResult Process(string username, string password)
        {
            var account = processLogin(username, password);
            if(account != null)
            {
                securityManager.SignIn(this.HttpContext, account);
                return RedirectToAction("","dashboard", "admin");
            }
            else
            {
                ViewBag.error = "Invalid Account";
                return View("Index");
            }
        }

       
        private Account processLogin(string username, string password)
        {
            var account = db.Accounts.SingleOrDefault(a => a.Username.Equals(username) && a.Status == true);
            if (account != null)
            {
                if (BCrypt.Net.BCrypt.Verify(password, account.Password))
                {
                    return account;
                }
            }
            return null;
        }


        [Route("signout")]
        public IActionResult SignOut()
        {
            securityManager.SignOut(this.HttpContext);
            return RedirectToAction("index","login", new { area = "admin" });
        }


        [Route("accessdenied")]
        public IActionResult AccessDenied()
        {
            return View("AccessDenied");
        }
    }
}