using InternetShop.Models;
using InternetShop.Services;
using Microsoft.AspNetCore.Mvc;

namespace InternetShop.Controllers
{
    public class CategoryController : Controller
    {
        public AppDbContext _db;
        public CategoryController(AppDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {

            IEnumerable<Category> categories = _db.Category;
            return View(categories);
        }


        //get 
        public IActionResult Create()
        {
            return View();
        }



        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {

            //if (ModelState.IsValid)    html ida client validation script yozilgan
            //{
            //    _db.Category.Add(category);
            //    _db.SaveChanges();
            //    return RedirectToAction("Index");

            //}

            _db.Category.Add(category);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

        //public IActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();

        //    }

        //    var category = _db.Category.FirstOrDefault(c => c.Id == id);
        //    if (category == null)
        //    {
        //        return NotFound();
        //    }
        //    _db.Category.Remove(category);
        //    _db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var category = _db.Category.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var category = _db.Category.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }

             _db.Category.Remove(category);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var category = _db.Category.FirstOrDefault(c => c.Id == id);
            if(category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {

            _db.Category.Update(category);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
        //"Delete
    }
}
