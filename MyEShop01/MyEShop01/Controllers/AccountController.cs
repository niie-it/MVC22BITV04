using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyEShop01.Entities;
using MyEShop01.Models;
using System.Security.Claims;

namespace MyEShop01.Controllers
{
	public class AccountController : Controller
	{
		private readonly MyEshopContext _context;
		public AccountController(MyEshopContext context)
		{
			_context = context;
		}

		public IActionResult Login(string? ReturnUrl)
		{
			ViewBag.ReturnUrl = ReturnUrl;
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginVM model, string? ReturnUrl)
		{
			var kh = _context.KhachHangs.SingleOrDefault(p => p.TenDangNhap == model.Username && p.MatKhau == model.Password);
			if (kh != null)
			{
				var claims = new List<Claim>
				{
					new Claim(ClaimTypes.Name, model.Username),
					new Claim(ClaimTypes.Email, kh.Email),
					new Claim("CustomerId", kh.Id.ToString()),
					new Claim(ClaimTypes.Role, "Admin"),//dynamic?
				};
				var identity = new ClaimsIdentity(claims, "MyCookieAuth");
				var principal = new ClaimsPrincipal(identity);
				await HttpContext.SignInAsync("MyCookieAuth", principal);
				if (ReturnUrl != null)
				{
					return Redirect(ReturnUrl);
				}
				return RedirectToAction("Index", "Home");
			}
			ViewBag.Message = "Sai thông tin đăng nhập";
			ViewBag.ReturnUrl = ReturnUrl;
			return View();
		}

		[Authorize]
		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync("MyCookieAuth");
			return RedirectToAction("Login");
		}

		[Authorize]
		public IActionResult AccessDenied()
		{
			return View("AccessDenied");
		}

		[Authorize]
		public IActionResult Profile()
		{
			return View();
		}
	}
}
