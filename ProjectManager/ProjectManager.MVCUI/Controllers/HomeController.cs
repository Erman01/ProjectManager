using ProjectManager.Core.Contracts;
using ProjectManager.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectManager.MVCUI.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly IRepository<GalleryModel> _galleryRepository;
        public HomeController(IRepository<GalleryModel> galleryRepository)
        {
            _galleryRepository = galleryRepository;
        }
        public ActionResult Index()
        {
            List<GalleryModel> galleryList = _galleryRepository.Collection().OrderBy(x => x.CreatedAt).ToList();
          
            foreach (var item in galleryList)
            {
                DateTime today = DateTime.Now;
                DateTime createdDate = item.CreatedAt;
                TimeSpan timeSpan = today.Subtract(createdDate);

                if (timeSpan.TotalDays <1)
                {
                    ViewBag.CreatedAt = "Created Today";
                }
                else if (timeSpan.TotalDays==1)
                {
                    ViewBag.CreatedAt = "Created Yesterday";
                }
                else
                {
                    ViewBag.CreatedAt =timeSpan.TotalDays + " Days Ago Created";
                }
            }

            return View(galleryList);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}