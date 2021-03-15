using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PhotoBoom.Data;
using PhotoBoom.Globals;
using PhotoBoom.Models;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace PhotoBoom.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ViewResult Photos()
        {
            return View(new PhotosViewModel { PhotoList = DBLayer.GetAllPhotos(_db) });
        }

        public async Task<IActionResult> ViewPhoto(int? id)
        {
            int PhotoId = (int)(id == null ? 0 : id);

            return View(new PhotosViewModel { Photo = DBLayer.GetPhoto(_db, PhotoId) });
        }

        public async Task<IActionResult> PhotoDelete(int? id, string photoname)
        {
            int PhotoId = (int)(id == null ? 0 : id);

            if (DBLayer.DeletePhoto(_db, PhotoId))
            {
                var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot/photos",
                        photoname);

                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }

                return RedirectToAction("Photos");
            }
            else
                return Content("The photo could not be deleted! A system problem has occurred.");
        }

        [HttpGet]
        public ViewResult AddPhoto()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddPhoto(IFormFile File, Photo Photo)
        {
            if (File == null || File.Length == 0)
                return Content("File not selected");

            var guid = Guid.NewGuid().ToString();
            string FileName = guid + "=" + File.FileName;

            var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot/photos",
                        FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await File.CopyToAsync(stream);
            }

            Photo.PhotoName = FileName;

            if (Photo.Title == null || Photo.Tags == null)
                return Content("Title/Tags fields cannot be blank");
            else if(Photo.Title.Trim().Equals("") || Photo.Tags.Trim().Equals(""))
                return Content("Title/Tags fields cannot be blank");
            else
            {
                if (DBLayer.InsertPhoto(_db, Photo))
                    return RedirectToAction("Photos");
                else
                    return Content("The photo could not be uploaded! A system problem has occurred.");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
