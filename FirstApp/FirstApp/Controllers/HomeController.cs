using FirstApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FirstApp.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Profile()
		{
			return View();
		}

		// host/Home/Random
		public int Random()
		{
			return new Random().Next(100, 1000);
		}

		public string Chao(string ten = "Admin")
		{
			return $"Xin chào {ten}";
		}

		public IActionResult Info()
		{
			return Json(new { Name = "NIIE", Age = 17 });
		}


		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
