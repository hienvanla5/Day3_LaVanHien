
using Day3_LaVanHien.Models;
using Microsoft.AspNetCore.Mvc;

namespace Day3_LaVanHien.Controllers
{
    public class ProductController : Controller
    {
        private static readonly List<Product> _products = new List<Product>()
        {
            new Product()
            {
                Id = 1,
                Name = "Laptop Dell",
                Price = 15000000,
                Description = "Dell Inspiron 15",
                CategoryId = 1
            },
            new Product()
            {
                Id = 2,
                Name = "Laptop HP",
                Price = 18000000,
                Description = "HP Pavilion",
                CategoryId = 1
            },
            new Product()
            {
                Id = 3,
                Name = "Mouse Logitech",
                Price = 500000,
                Description = "Logitech Wireless Mouse",
                CategoryId = 2
            }
        };

        // GET: ProductController
        public ActionResult Index()
        {
            return View(_products);
        }

        // GET: ProductController/Details/5
        public ActionResult Details([FromRoute] int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            int newId = _products.Any()
                ? _products.Max(p => p.Id) + 1
                : 1;

            product.Id = newId;

            _products.Add(product);

            return RedirectToAction(nameof(Index));
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit([FromRoute] int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [FromRoute] int id,
            [FromForm] Product updatedProduct)
        {
            if (!ModelState.IsValid)
            {
                return View(updatedProduct);
            }

            var product = _products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            product.Name = updatedProduct.Name;
            product.Price = updatedProduct.Price;
            product.Description = updatedProduct.Description;
            product.CategoryId = updatedProduct.CategoryId;

            return RedirectToAction(nameof(Index));
        }

        // GET: ProductController/Delete/5
        [HttpGet]
        public ActionResult Delete([FromRoute] int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed([FromForm] int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            _products.Remove(product);

            return RedirectToAction(nameof(Index));
        }
    }
}
