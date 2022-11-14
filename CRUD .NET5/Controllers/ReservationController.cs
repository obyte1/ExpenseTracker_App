using CRUD_.NET5.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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
    }
}
