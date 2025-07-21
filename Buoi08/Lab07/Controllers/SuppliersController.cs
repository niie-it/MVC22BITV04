using Lab07.Data;
using Microsoft.AspNetCore.Mvc;

namespace Lab07.Controllers
{
	public class SuppliersController : Controller
	{
		private readonly MvcNiieLabContext _context;

		public SuppliersController(MvcNiieLabContext context)
		{
			_context = context;
		}

		public IActionResult Index(string? Keyword)
		{
			var data = _context.Suppliers.AsQueryable();
			if (Keyword != null)
			{
				data = data.Where(p => p.Name.Contains(Keyword) || p.Phone.Contains(Keyword) || p.Email.Contains(Keyword));
			}
			return View(data.ToList());
		}
	}
}
