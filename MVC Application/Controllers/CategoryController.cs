using Microsoft.AspNetCore.Mvc;
using MVC_Application.Data;
using MVC_Application.Models;
using System.ComponentModel;

namespace MVC_Application.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objcategory = _db.categories;
            return View(objcategory);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if(obj.Name==obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "Name and DisplayOrder can't be the same");
            }
            if(ModelState.IsValid)
            {
                _db.categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Created Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if(id==null || id == 0)
                return NotFound();
            var edited = _db.categories.Find(id);
            if(edited==null)
                return NotFound();
            return View(edited);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "Name and DisplayOrder can't be the same");
            }
            if (ModelState.IsValid)
            {
                _db.categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Updated Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            var edited = _db.categories.Find(id);
            if (edited == null)
                return NotFound();
            return View(edited);
        }
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var del = _db.categories.Find(id);
            if(del == null)
            {
                return NotFound();
            }
            
            _db.categories.Remove(del);
            _db.SaveChanges();
            TempData["success"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
