using CoreTrainings2021.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreTrainings2021.Controllers
{
    public class ProductController : Controller
    {

        private Context _context = new Context();

        public IActionResult Index()
        {
            var prods = _context.products.ToList();           
            return View(prods);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.products.Add(product);
                _context.SaveChanges();
                return RedirectToAction("Index", "Product");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var item = _context.products.Find(id);
            return View(item);
        }

        [HttpPost]
        public IActionResult Update(Product product)
        {
            _context.products.Update(product);
            _context.SaveChanges();
            return RedirectToAction("Index", "Product");
        }

        public IActionResult Delete(int id)
        {
            var item = _context.products.Find(id);
            _context.products.Remove(item);
            _context.SaveChanges();
            return RedirectToAction("Index", "Product");
        }

        public IActionResult Search(string q)
        {
            var product = _context.products.Where(i => i.ProductName.Contains(q));
            return View(product);
        }
    }
}
