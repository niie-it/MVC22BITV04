using Lab07.Data;
using Lab07.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Lab07.Controllers
{
	public class ProductController : Controller
	{
		private readonly MvcNiieLabContext _context;

		public ProductController(MvcNiieLabContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			var data = _context.Products
						.Include(p => p.Category)
						.Include(p => p.Supplier);
			return View(data.ToList());
		}


		#region Create_Product
		[HttpGet]
		public IActionResult Create()
		{
			ViewBag.Categories = new SelectList(_context.Categories.ToList(), "Id", "NameVn");
			ViewBag.Suppliers = new SelectList(_context.Suppliers.ToList(), "Id", "Name");
			return View();
		}

		[HttpPost]
		public IActionResult Create(Product model, IFormFile Image)
		{
			if (Image != null)
			{
				model.Image = MyTool.UploadImageToFolder(Image, "Products");
			}
			else
			{
				model.Image = "noimage.png";
			}
			try
			{
				_context.Add(model);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			catch
			{
				ViewBag.Message = "Có lỗi thêm mới";
				ViewBag.Categories = new SelectList(_context.Categories.ToList(), "Id", "NameVn", model.CategoryId);
				ViewBag.Suppliers = new SelectList(_context.Suppliers.ToList(), "Id", "Name", model.SupplierId);
				return View(model);
			}
		}
		#endregion


		#region Edit_Product
		[HttpGet]
		public IActionResult Edit(int id)
		{
			var product = _context.Products.SingleOrDefault(p => p.Id == id);
			if (product == null)
			{
				return NotFound();
			}
			ViewBag.Categories = new SelectList(_context.Categories.ToList(), "Id", "NameVn", product.CategoryId);
			ViewBag.Suppliers = new SelectList(_context.Suppliers.ToList(), "Id", "Name", product.SupplierId);
			return View(product);
		}

		[HttpPost]
		public IActionResult Edit(int id, IFormFile NewImage, Product model)
		{
			var product = _context.Products.SingleOrDefault(p => p.Id == id);
			if (product == null)
			{
				return NotFound();
			}
			if (NewImage != null)
			{
				model.Image = MyTool.UploadImageToFolder(NewImage, "Products");
			}
			try
			{
				_context.Update(model);
				_context.SaveChanges();
				return RedirectToAction("Edit", new {Id = id});
			}
			catch
			{
				ViewBag.Categories = new SelectList(_context.Categories.ToList(), "Id", "NameVn", product.CategoryId);
				ViewBag.Suppliers = new SelectList(_context.Suppliers.ToList(), "Id", "Name", product.SupplierId);
				return View(product);
			}
		}
		#endregion
	}
}
