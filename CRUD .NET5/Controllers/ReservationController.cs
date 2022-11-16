using CRUD_.NET5.Data;
using CRUD_.NET5.Migrations;
using CRUD_.NET5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_.NET5.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ReservationController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.reservationModel.ToList());
        }

        public IActionResult Create()
        {
            List<SelectListItem> rooms = new List<SelectListItem>();
            rooms.Add(new SelectListItem() { Text = "Room", Value = "Room" });
            rooms.Add(new SelectListItem() { Text = "Standard Double Room", Value = "Standard Double Room" });
            rooms.Add(new SelectListItem() { Text = "Standard Family Room", Value = "Standard Family Room" });
            rooms.Add(new SelectListItem() { Text = "Garden Family Room", Value = "Garden Family Room" });
            rooms.Add(new SelectListItem() { Text = "Deluxe Double Room", Value = "Deluxe Double Room" });
            rooms.Add(new SelectListItem() { Text = "Executive Junior Suite", Value = "Executive Junior Suite" });
            rooms.Add(new SelectListItem() { Text = "Maisonette", Value = "Maisonette" });
            ViewBag.rooms = rooms;

            List<SelectListItem> peoples = new List<SelectListItem>();
            peoples.Add(new SelectListItem() { Text = "Persons", Value = "Persons" });
            peoples.Add(new SelectListItem() { Text = "1 Person", Value = "1 Person" });
            peoples.Add(new SelectListItem() { Text = "2 Person", Value = "2 Person" });
            peoples.Add(new SelectListItem() { Text = "3 Person", Value = "3 Person" });
            peoples.Add(new SelectListItem() { Text = "4 Person", Value = "4 Person" });
            peoples.Add(new SelectListItem() { Text = "5 Person", Value = "5 Person" });
            peoples.Add(new SelectListItem() { Text = "more", Value = "more" });
            ViewBag.peoples = peoples;

            return View(new ReservationViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReservationViewModel model)
        {            
            if (ModelState.IsValid)
            {
                ReservationModel obj = new ReservationModel()
                {
                    Name = model.Name,
                    Email = model.Email,
                    ArrivalDateTime = model.ArrivalDateTime,
                    DepartureDateTime = model.DepartureDateTime,
                    Room = model.Room,
                    NumberOfPeople = model.NumberOfPeople
                    
                };
                _db.reservationModel.Add(obj);
                await _db.SaveChangesAsync();
                
            }
            return RedirectToAction("Index");
        }
    }
}
