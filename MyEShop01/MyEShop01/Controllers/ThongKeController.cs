using Microsoft.AspNetCore.Mvc;
using MyEShop01.Entities;

namespace MyEShop01.Controllers
{
	public class ThongKeController : Controller
	{
		private readonly MyEshopContext _context;

		public ThongKeController(MyEshopContext context)
		{
			_context = context;
		}

		const int KHOANG_CACH_NGAY = 30;
		public IActionResult ThongKeTheoLoai(DateTime? TuNgay, DateTime? DenNgay)
		{
			if (!TuNgay.HasValue && !DenNgay.HasValue)
			{
				DenNgay = DateTime.Now;
				TuNgay = DenNgay.Value.AddDays(-KHOANG_CACH_NGAY);
			}
			else if (TuNgay.HasValue && !DenNgay.HasValue)
			{
				DenNgay = TuNgay.Value.AddDays(KHOANG_CACH_NGAY);
			}
			else if (!TuNgay.HasValue && DenNgay.HasValue)
			{
				TuNgay = DenNgay.Value.AddDays(-KHOANG_CACH_NGAY);
			}

			var data = _context.ChiTietHds
				.Where(p => p.MaHdNavigation.NgayDat >= TuNgay && p.MaHdNavigation.NgayDat <= DenNgay)
				.GroupBy(cthd => new
				{
					MaLoai = cthd.MaHhNavigation.MaLoai,
					TenLoai = cthd.MaHhNavigation.MaLoaiNavigation.TenLoai,
				}).Select(p => new
				{
					p.Key.MaLoai,
					p.Key.TenLoai,
					DoanhThu = p.Sum(cthd => cthd.SoLuong * cthd.DonGia)
				});
			return Json(data);
		}


		public IActionResult Index()
		{
			return View();
		}
	}
}
