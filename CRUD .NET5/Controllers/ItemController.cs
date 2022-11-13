using CRUD_.NET5.Data;
using CRUD_.NET5.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;

namespace CRUD_.NET5.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ItemController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Item> objList = _db.items;
            return View(objList);
        }

        //get
        public IActionResult Create()
        {           
            return View();
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Item obj)
        {
            _db.items.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
