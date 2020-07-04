using Microsoft.AspNet.Identity;
using ProjectManager.Core.Contracts;
using ProjectManager.Core.Models;
using ProjectManager.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectManager.MVCUI.Controllers
{
    [Authorize]
    public class GalleryImageController : Controller
    {
        private readonly IRepository<GalleryImageModel> _galleryImageRepository;
        private readonly IRepository<GalleryModel> _galleryRepository;
        public GalleryImageController(IRepository<GalleryImageModel> galleryImageRepository, IRepository<GalleryModel> galleryRepository)
        {
            _galleryImageRepository = galleryImageRepository;
            _galleryRepository = galleryRepository;
        }
        public ActionResult Index()
        {

            string loggedInUserId = User.Identity.GetUserId();
            List<GalleryImageModel> imageList = _galleryImageRepository.Collection().Where(x => x.ManagerModelId == loggedInUserId).ToList();
            ViewBag.PhotoCount = imageList.Count;
            return View(imageList);
        }
        public ActionResult Create()
        {
            string loggedInUserGallery = User.Identity.GetUserId();
            GalleryImageViewModel galleryImageViewModel = new GalleryImageViewModel()
            {
               
                GalleryImageModel = new GalleryImageModel(),
                GalleryModels = _galleryRepository.Collection().Where(x=>x.ManagerModelId==loggedInUserGallery).ToList()
            };
            return View(galleryImageViewModel);
        }
        [HttpPost]
        public ActionResult Create(GalleryImageModel galleryImageModel, HttpPostedFileBase file)
        {
            MessageViewModel viewModel = new MessageViewModel();

            if (!ModelState.IsValid)
            {
                viewModel.Message = "An Error Occured";
                viewModel.Status = false;
                return View(galleryImageModel);
            }
           
            else
            {
               
                if (file != null)
                {
                    string LoggedInUserId = User.Identity.GetUserId();
                    galleryImageModel.ManagerModelId = LoggedInUserId;

                    galleryImageModel.Url = galleryImageModel.Id + Path.GetFileNameWithoutExtension(file.FileName) + ".jpg";
                    file.SaveAs(Server.MapPath("//Content//GalleryImages//") + galleryImageModel.Url);
                    
                }
                _galleryImageRepository.Insert(galleryImageModel);
                viewModel.Message = "Added Successfully";

                _galleryImageRepository.Commit();
                viewModel.Status = true;
                viewModel.LinkText = "Back to Gallery";
                viewModel.Url = "/GalleryManager/Index";

                return View("_Message",viewModel);
            }
        }
        public ActionResult Edit(int id)
        {
            GalleryImageModel galleryImageModel = _galleryImageRepository.GetbyId(id);
            if (galleryImageModel == null)
            {
                return HttpNotFound();
            }
            else
            {
                string loggedInUserGallery = User.Identity.GetUserId();
                GalleryImageViewModel galleryImageViewModel = new GalleryImageViewModel()
                {
                    GalleryImageModel = galleryImageModel,
                    GalleryModels = _galleryRepository.Collection().Where(x=>x.ManagerModelId==loggedInUserGallery).ToList()
                };
                return View(galleryImageViewModel);
            }
        }
        [HttpPost]
        public ActionResult Edit(int id, GalleryImageModel galleryImageModel, HttpPostedFileBase file)
        {
            GalleryImageModel galleryImageModelToEdit = _galleryImageRepository.GetbyId(id);
            if (galleryImageModelToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                MessageViewModel viewModel = new MessageViewModel();//Ajax begin form used

                if (!ModelState.IsValid)
                {
                    viewModel.Message = "An Error Occured";
                    viewModel.Status = false;
                    return View(galleryImageModelToEdit);
                   
                }
                if (file != null)
                {
                    galleryImageModelToEdit.Url = galleryImageModel.Id + Path.GetFileNameWithoutExtension(file.FileName) + ".jpg";
                    file.SaveAs(Server.MapPath("//Content//GalleryImages//") + galleryImageModelToEdit.Url);
                }
                galleryImageModelToEdit.Description = galleryImageModel.Description;
                galleryImageModelToEdit.GalleryModelId = galleryImageModel.GalleryModelId;

                viewModel.Message = "Updated Successfully";//Ajax begin form used

                _galleryImageRepository.Commit();

                viewModel.Status = true;
                viewModel.LinkText = "Back to Gallery";
                viewModel.Url = "/GalleryManager/Index";

                return View("_Message",viewModel);
            }
        }
        public ActionResult Delete(int id)
        {
            GalleryImageModel galleryImageModel = _galleryImageRepository.GetbyId(id);
            if (galleryImageModel == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(galleryImageModel);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            GalleryImageModel galleryImageModelToDelete = _galleryImageRepository.GetbyId(id);
            if (galleryImageModelToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                _galleryImageRepository.Delete(id);
                _galleryImageRepository.Commit();

                return RedirectToAction("Index","GalleryManager");
            }
        }
    }
}