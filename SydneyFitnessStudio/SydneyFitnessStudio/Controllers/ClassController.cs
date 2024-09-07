using Microsoft.AspNetCore.Mvc;
using SydneyStudio.DataAccess.Data;
using SydneyStudio.Models.Models;

namespace SydneyFitnessStudio.Controllers
{
    public class ClassController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ClassController(ApplicationDbContext db)
        {
            _db = db;   
        }
        public IActionResult Index()
        {
            List<Class> objClassList = _db.Classes.ToList();
            return View(objClassList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Class obj)
        {
            if (obj.Name == obj.Description.ToString())
            {
                ModelState.AddModelError("name", "The Description cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _db.Classes.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
                
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Class? classFromDb = _db.Classes.Find(id);

            if (classFromDb == null)
            {
                return NotFound();
            }

            return View(classFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // Helps to prevent CSRF attacks
        public IActionResult Edit(Class obj)
        {
            // Custom validation: Description cannot match the Name
            if (obj.Name == obj.Description)
            {
                ModelState.AddModelError("Name", "The Description cannot exactly match the Name.");
            }

            if (ModelState.IsValid)
            {
                _db.Classes.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            // If validation fails, return the form with the data
            return View(obj);
        }

        // GET: Delete Class
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            // Fetch the class from the database
            Class? classFromDb = _db.Classes.Find(id);

            if (classFromDb == null)
            {
                return NotFound();
            }

            return View(classFromDb);
        }

        // POST: Delete Class
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken] // Prevent CSRF attacks
        public IActionResult DeletePOST(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Find the class in the database
            Class? classFromDb = _db.Classes.Find(id);

            if (classFromDb == null)
            {
                return NotFound();
            }

            // Remove the class from the database
            _db.Classes.Remove(classFromDb);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }

}

