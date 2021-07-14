using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCOREMVC.Controllers
{
    public class PhotoController : Controller
    {
        public IActionResult UploadPicture()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UploadPicture(IFormFile datei)
        {
            FileInfo fileInfo = new FileInfo(datei.FileName);

            string speicherPfad = AppDomain.CurrentDomain.GetData("BildVerzeichnis") + @"\images\" + fileInfo.Name;

            using (FileStream stream = new FileStream(speicherPfad, FileMode.Create))
            {
                datei.CopyTo(stream);
            }

            return RedirectToAction(nameof(UploadPicture));
        }


        public IActionResult PictureGallery ()
        {
            string path = AppDomain.CurrentDomain.GetData("BildVerzeichnis") + @"\images";
            string[] bilder = Directory.GetFiles(path);

            return View(bilder);
        }

        public IActionResult FormattedPictureGallery()
        {
            string path = AppDomain.CurrentDomain.GetData("BildVerzeichnis") + @"\images";
            string[] bilder = Directory.GetFiles(path);

            return View(bilder);
        }
    }
}
