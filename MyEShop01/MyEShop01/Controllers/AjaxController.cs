using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyEShop01.Entities;
using MyEShop01.Models;

namespace MyEShop01.Controllers
{
	public class AjaxController : Controller
	{
		private readonly MyEshopContext _context;

		public AjaxController(MyEshopContext context)
		{
			_context = context;
		}

		[HttpGet]
		public IActionResult Search()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Search(string Keyword)
		{
			var data = _context.HangHoas
				.Include(p => p.MaLoaiNavigation)
				.Where(p => p.TenHh.Contains(Keyword))
				.Select(p => new KetQuaTimKiemVM
				{
					MaHh = p.Id,
					TenHh = p.TenHh,
					DonGia = p.DonGia.Value,
					Hinh = p.Hinh,
					Loai = p.MaLoaiNavigation.TenLoai,
					NgaySX = p.NgaySx
				})
				.ToList();
			return PartialView("SearchPartial", data);
		}
	}
}
