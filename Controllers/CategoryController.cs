using Day3_LaVanHien.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day3_LaVanHien.Controllers
{
    public class CategoryController : Controller
    {
        private static readonly List<Category> _categories = new List<Category>()
        {
            new Category() {Id = 1, Name = "Hihi"},
            new Category() {Id = 2, Name = "Haha"},
            new Category() {Id = 3, Name = "Hehe"}
        };

        // GET: CategoryController
        public ActionResult Index()
        {
            return View(_categories);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            var category = _categories.AsQueryable().FirstOrDefault(c => c.Id == id);

            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] Category category)
        {
            if (ModelState.IsValid)
            {
                int newId = _categories.Any() ? _categories.Max(c => c.Id) + 1 : 1;
                category.Id = newId;
                _categories.Add(category);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit([FromRoute] int id)
        {
            var category = _categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([FromRoute] int id, [FromForm] Category updatedCategory)
        {
            if (!ModelState.IsValid)
            {
                return View(updatedCategory);
            }

            var category = _categories.FirstOrDefault(c => c.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            category.Name = updatedCategory.Name;

            return RedirectToAction(nameof(Index));
        }

        // GET: CategoryController/Delete/5
        [HttpGet]
        public ActionResult Delete([FromRoute] int id)
        {
            var category = _categories.FirstOrDefault(c => c.Id == id);
            if (category == null) return NotFound();

            return View(category);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed([FromForm] int id)
        {
            var category = _categories.FirstOrDefault(c => c.Id == id);
            if (category == null) return NotFound();

            _categories.Remove(category);
            return RedirectToAction(nameof(Index));
        }
    }
}
