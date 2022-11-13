using CRUD_.NET5.Data;
using CRUD_.NET5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
//using Microsoft.AspNetCore.Http.HttpContext.Current.Session;

namespace CRUD_.NET5.Controllers
{
    public class AccountController : Controller 
    {
        

        //Get: Account
        public IActionResult Index()
        {
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                return View(db.userAccount.ToList());
            }
            return View();
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
                using(ApplicationDbContext db = new ApplicationDbContext())
                {
                    db.userAccount.Add(account);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = account.FirstName + " " + account.LastName + "Successfully Registered";
                
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
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                var usr = db.userAccount.Single(u => u.Email == user.Email && u.Password == user.Password);
                if(usr != null)
                {
                    Session["UserId"] = usr.UserId.ToString();
                    Session["Email"] = usr.Email.ToString();
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "Email or Password is wrong");
                }
            }
            return View();
        }

        public ActionResult LoggedIn()
        {
            if (Session["UserId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}
