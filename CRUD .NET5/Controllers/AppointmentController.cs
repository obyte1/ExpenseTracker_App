using Microsoft.AspNetCore.Mvc;
using System;

namespace CRUD_.NET5.Controllers
{
    public class AppointmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
            //string todaydate = DateTime.Now.ToString();
            //return Ok(todaydate);  
        }

        public IActionResult Details(string id)
        {
            return Ok("You have entered an ID of:" + id);
        }
    }
}
