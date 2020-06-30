using Microsoft.AspNet.Identity;
using ProjectManager.Core.Contracts;
using ProjectManager.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;
using WebGrease.Activities;

namespace ProjectManager.MVCUI.Controllers
{
    public class GalleryManagerController : Controller
    {
        private readonly IRepository<GalleryModel> _galleryModelRepository;
        public GalleryManagerController(IRepository<GalleryModel> galleryModelRepository)
        {
            _galleryModelRepository = galleryModelRepository;
        }
        public ActionResult Index()
        {
            string loggedInUserId = User.Identity.GetUserId();
            List<GalleryModel> galleryModels = _galleryModelRepository.Collection().Where(x => x.ManagerModelId == loggedInUserId).ToList();
            ViewBag.PhotoCount = galleryModels.Count;

            return View(galleryModels);
        }
        [Authorize]
        public ActionResult Create()
        {
            GalleryModel galleryModel = new GalleryModel();

            return View(galleryModel);
        }
        [HttpPost]
        [Authorize]
        public ActionResult Create(GalleryModel galleryModel, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                return View(galleryModel);
            }
            else
            {
                if (file != null)
                {
                    string loggedInuserId = User.Identity.GetUserId();
                    galleryModel.ManagerModelId = loggedInuserId;
                    galleryModel.Url = galleryModel.Id + Path.GetFileNameWithoutExtension(file.FileName) + ".jpg";
                    file.SaveAs(Server.MapPath("//Content//Galleries//") + galleryModel.Url);
                }
                _galleryModelRepository.Insert(galleryModel);
                _galleryModelRepository.Commit();

                return RedirectToAction("Index");
            }
        }
        [Authorize]
        public ActionResult Edit(int id)
        {
            GalleryModel galleryModel = _galleryModelRepository.GetbyId(id);
            if (galleryModel == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(galleryModel);
            }


        }
        [HttpPost]
        [Authorize]
        public ActionResult Edit(GalleryModel galleryModel, int id, HttpPostedFileBase file)
        {
            GalleryModel galleryModelToDelete = _galleryModelRepository.GetbyId(id);
            if (galleryModelToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(galleryModelToDelete);
                }
                else
                {
                    if (file != null)
                    {
                        galleryModelToDelete.Url = galleryModel.Id + Path.GetFileNameWithoutExtension(file.FileName) + ".jpg";
                        file.SaveAs(Server.MapPath("//Content//Galleries//") + galleryModelToDelete.Url);
                    }
                    galleryModelToDelete.Title = galleryModel.Title;

                    _galleryModelRepository.Commit();

                    return RedirectToAction("Index");
                }
            }

        }
        public ActionResult Delete(int id)
        {
            GalleryModel galleryModel = _galleryModelRepository.GetbyId(id);
            if (galleryModel == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(galleryModel);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            GalleryModel galleryModelToDelete = _galleryModelRepository.GetbyId(id);
            if (galleryModelToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                _galleryModelRepository.Delete(id);
                _galleryModelRepository.Commit();

                return RedirectToAction("Index");
            }
        }

    }
}