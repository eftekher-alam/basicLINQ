using BasicLINQweb.Models;
using BasicLINQweb.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BasicLINQweb.Controllers
{
    public class VehicleController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;
        public VehicleController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public IActionResult Index()
        {
            var vehicles = _context.Vehicles.Include(x => x.Category).ToList();
            return View(vehicles);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Category = _context.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(VehicleViewModel vehicle)
        {
            if (ModelState.IsValid)
            {
                Vehicle MainVehicle= new Vehicle()
                {
                    vehicleId = vehicle.vehicleId,
                    EngId= vehicle.EngId,
                    PurchaseDate = vehicle.PurchaseDate,
                    CurrStatus = vehicle.CurrStatus,
                    Picture = "Picture\\default.jpg",
                    CategoryId = vehicle.CategoryId
                };
                
                if (vehicle.Picture != null)
                {
                    var root = _environment.WebRootPath;
                    var picPath = "Picture\\" + Guid.NewGuid().ToString() + vehicle.Picture.FileName.ToString();                    
                    MainVehicle.Picture = picPath;
                    var fullPath = Path.Combine(root, picPath);
                    FileStream fc = new FileStream(fullPath, FileMode.Create);
                    vehicle.Picture.CopyTo(fc);
                    fc.Close();
                }
                _context.Vehicles.Add(MainVehicle);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Category = _context.Categories.ToList();
                return View(vehicle);
            }
        }
        [HttpGet]
        public IActionResult Edit(int vehicleId)
        {
            ViewBag.Category = _context.Categories.ToList();
            Vehicle vehicle = _context.Vehicles.Find(vehicleId);
            ViewBag.Picture = vehicle.Picture;
            VehicleViewModel vmVehicle = new VehicleViewModel()
            {
                vehicleId = vehicle.vehicleId,
                EngId = vehicle.EngId,
                PurchaseDate = vehicle.PurchaseDate,
                CurrStatus = vehicle.CurrStatus,
                CategoryId = vehicle.CategoryId
            };
            return View(vmVehicle);
        }

        [HttpPost]
        public IActionResult Edit(VehicleViewModel vehicle)
        {
            if (ModelState.IsValid)
            {
                Vehicle MainVehicle= new Vehicle()
                {
                    vehicleId = vehicle.vehicleId,
                    EngId= vehicle.EngId,
                    PurchaseDate = vehicle.PurchaseDate,
                    CurrStatus = vehicle.CurrStatus,
                    CategoryId = vehicle.CategoryId
                };
                
                if (vehicle.Picture != null)
                {
                    var root = _environment.WebRootPath;
                    var picPath = "Picture\\" + Guid.NewGuid().ToString() + vehicle.Picture.FileName.ToString();
                    MainVehicle.Picture = picPath;
                    var fullPath = Path.Combine(root, picPath);
                    FileStream fc = new FileStream(fullPath, FileMode.Create);
                    vehicle.Picture.CopyTo(fc);
                    fc.Close();
                }
                _context.Vehicles.Update(MainVehicle);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Category = _context.Categories.ToList();
                return View(vehicle);
            }
        }

        [HttpGet]
        public IActionResult Delete(int vehicleId)
        {
            ViewBag.Category = _context.Categories.ToList();
            Vehicle vehicle = _context.Vehicles.Find(vehicleId);
            return View(vehicle);
        }

        [HttpPost]
        public IActionResult Delete(Vehicle vehicle)
        {
            _context.Vehicles.Remove(vehicle);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
