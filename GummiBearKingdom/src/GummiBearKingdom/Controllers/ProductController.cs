using GummiBearKingdom.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GummiBearKingdom.Controllers
{
    public class ProductController : Controller
    {
        private GBKContext db = new GBKContext();
        public IActionResult Index()
        {
            return View(db.Products);
        }

        public IActionResult Details(int id)
        {
            Product product = db.Products.FirstOrDefault(prod => prod.ProductId == id);
            return View(product);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Product product = db.Products.FirstOrDefault(prod => prod.ProductId == id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Product product = db.Products.FirstOrDefault(prod => prod.ProductId == id);
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.FirstOrDefault(prod => prod.ProductId == id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}