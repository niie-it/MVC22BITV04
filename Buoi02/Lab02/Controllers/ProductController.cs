using Lab02.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab02.Controllers
{
	public class ProductController : Controller
	{
		static List<Product> products = new List<Product>()
		{ 
			new Product { Id = 1, Name = "Macbook Pro 18", Price = 29900000},
			new Product { Id = 2, Name = "IPhone Pro 18", Price = 31900000},
			new Product { Id = 3, Name = "IPad Pro 13", Price = 21900000},
		};
		public IActionResult Index()
		{
			return View(products);
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Product model)
		{
			products.Add(model);
			return RedirectToAction("Index");
		}
	}
}
