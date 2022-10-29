using InternetShop.Models;
using InternetShop.Services;
using Microsoft.AspNetCore.Mvc;

namespace InternetShop.Controllers
{
    public class ApplicationType : Controller
    {
        public readonly AppDbContext appDbContext;

        public ApplicationType(AppDbContext db)
        {
            appDbContext = db;
        }

        public IActionResult Index()
        {
            IEnumerable<HomeWork> works = appDbContext.homeWorks;
            return View(works);
        }

       // get

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(HomeWork homeWork)
        {
            appDbContext.Add(homeWork);
            appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var homework = appDbContext.homeWorks.Where(x => x.Id == id).FirstOrDefault();
            if (homework == null)
            {
                return NotFound();
            }

            return View(homework);
        }

        [HttpPost]
        public IActionResult EditPost(HomeWork hWork)
        {
            if (hWork.Id == null)
            {
                return NotFound();
            }

            var homework = appDbContext.homeWorks.Where(x => x.Id == hWork.Id).FirstOrDefault();
            if (homework == null)
            {
                return NotFound();
            }

            homework.Name = hWork.Name;
            appDbContext.homeWorks.Update(homework);
            appDbContext.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var homework = appDbContext.homeWorks.Where(x => x.Id == id).FirstOrDefault();
            if (homework == null)
            {
                return NotFound();
            }

            return View(homework);
        }

        [HttpPost]
        public IActionResult DeletePost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var homework = appDbContext.homeWorks.Where(x => x.Id == id).FirstOrDefault();
            if (homework == null)
            {
                return NotFound();
            }

            appDbContext.homeWorks.Remove(homework);
            appDbContext.SaveChanges();
            return RedirectToAction("index");

        }
    }
}
