using Lab04_Validation.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab04_Validation.Controllers
{
	public class EmployeeController : Controller
	{
		public IActionResult IsExistedEmployee(string EmployeeNo)
		{
			var emps = new List<string> { "Thai", "Dung", "Ad" };
			if (emps.Contains(EmployeeNo))
			{
				return Json($"Mã {EmployeeNo} đã có");
			}
			return Json(true);
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Employee model)
		{
			return View();
		}
	}
}
