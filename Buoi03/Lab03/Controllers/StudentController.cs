using Lab03.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Lab03.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        string jsonPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Student.json");
        public IActionResult Manage(Student model, IFormFile Photo, string FileType)
        {
            if (Photo != null)
            {
                var photoPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", Photo.FileName);
                using (var myfile = new FileStream(photoPath, FileMode.Create))
                {
                    Photo.CopyTo(myfile);
                }
                model.Photo = Photo.Name;
            }
            if (FileType == "Lưu JSON")
            {
                var jsonStr = JsonSerializer.Serialize(model);
                System.IO.File.WriteAllText(jsonPath, jsonStr);
            }
            return View("Index", model);
        }
    }
}
