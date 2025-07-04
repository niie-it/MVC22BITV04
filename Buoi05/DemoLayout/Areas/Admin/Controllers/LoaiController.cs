using Microsoft.AspNetCore.Mvc;

namespace DemoLayout.Areas.Admin.Controllers
{
	[Area("admin")]
	public class LoaiController : Controller
	{
		// host/admin/Loai/Index
		public IActionResult Index()
		{
			return View();
		}
	}
}
