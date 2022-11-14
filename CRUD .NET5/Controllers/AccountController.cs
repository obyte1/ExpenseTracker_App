using CRUD_.NET5.Data;
using CRUD_.NET5.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Linq;
//using Microsoft.AspNetCore.Http.HttpContext.Current.Session;

namespace CRUD_.NET5.Controllers
{
    public class AccountController : Controller 
    {
        private readonly ApplicationDbContext _db;
        public AccountController(ApplicationDbContext db)
        {
            _db = db;
        }

        //Get: Account
        public IActionResult Index()
        {
            return View(_db.userAccount.ToList());
        }

        //Get: Register
        public ActionResult Register()
        {
            return View();
        }

        //Post: Regiater
        [HttpPost]
        public ActionResult Register(UserAccount account)
        {
            if (ModelState.IsValid)
            {
                _db.userAccount.Add(account);
                _db.SaveChanges();

                ModelState.Clear();
                ViewBag.Message = "Successfully Registered";
                
            }
            return View();
        }

        //Login Get
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserAccount user)
         {
            var usr = _db.userAccount.Where(u => u.Email == user.Email && u.Password == user.Password).FirstOrDefault();
            if (usr != null)
            {
                
                HttpContext.Session.SetString("UserId", usr.UserId.ToString());
                HttpContext.Session.SetString("Email", usr.Email.ToString());
                return View("../Expense/Index");
            }
            else
            {
                ModelState.AddModelError("", "Email or Password is wrong");
            }
            return View();
        }

        public ActionResult LoggedIn()
        {
            if(HttpContext.Session.GetString("UserId") != null)
            {
                ViewBag.Email = HttpContext.Session.GetString("Email");
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
