using ProjectManager.Core.Contracts;
using ProjectManager.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ProjectManager.Core.ViewModels;
using System.IO;

namespace ProjectManager.MVCUI.Controllers
{
    public class EmployeeManagerController : Controller
    {
        private readonly IRepository<EmployeeModel> _employeeRepository;
        private readonly IRepository<DepartmentModel> _departmentRepository;
        public EmployeeManagerController(IRepository<EmployeeModel> employeeRepository, IRepository<DepartmentModel> departmentRepository)
        {
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;
        }
        public ActionResult Index()
        {
            List<EmployeeModel> employeeModel = _employeeRepository.Collection().Include(x=>x.DepartmentModel).ToList();
            return View(employeeModel);
        }
        public ActionResult Create()
        {
            EmployeeViewModel employeeModel = new EmployeeViewModel()
            {
                EmployeeModel = new EmployeeModel(),
                DepartmentModels = _departmentRepository.Collection()
            };

            return View(employeeModel);
        }
        [HttpPost]
        public ActionResult Create(EmployeeModel employeeModel,HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                return View(employeeModel);
            }
            else
            {
                if (file!=null)
                {
                    employeeModel.Url = employeeModel.Id + Path.GetFileNameWithoutExtension(file.FileName)+".jpg";
                    file.SaveAs(Server.MapPath("//Content//EmployeeProfileImage//") + employeeModel.Url);
                }
                _employeeRepository.Insert(employeeModel);
                _employeeRepository.Commit();

                return RedirectToAction("Index");
            }
        }
        public ActionResult Edit(EmployeeModel employeeModel,int id,HttpPostedFileBase file)
        {
            EmployeeModel employeeModelToEdit = _employeeRepository.GetbyId(id);
            if (employeeModelToEdit==null)
            {
                return HttpNotFound();
            }
            else
            {
                EmployeeViewModel employeeViewModel = new EmployeeViewModel()
                {
                    EmployeeModel = employeeModelToEdit,
                    DepartmentModels = _departmentRepository.Collection()
                };
                return View(employeeViewModel);
            }
        }
        [HttpPost]
        public ActionResult Edit(int id,EmployeeModel employeeModel,HttpPostedFileBase file)
        {
            EmployeeModel employeeModelToEdit = _employeeRepository.GetbyId(id);
            if (employeeModelToEdit==null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(employeeModelToEdit);
                }
                else
                {
                    if (file!=null)
                    {
                        employeeModelToEdit.Url = employeeModel.Id + Path.GetFileNameWithoutExtension(file.FileName) + ".jpg";
                        file.SaveAs(Server.MapPath("//Content//EmployeeProfileImage//") + employeeModelToEdit.Url);
                    }
                    employeeModelToEdit.FirstName = employeeModel.FirstName;
                    employeeModelToEdit.LastName = employeeModel.LastName;
                    employeeModelToEdit.Gender = employeeModel.Gender;
                    employeeModelToEdit.EMail = employeeModel.EMail;
                    employeeModelToEdit.Password = employeeModel.Password;
                    employeeModelToEdit.DepartmentId = employeeModel.DepartmentId;

                    _employeeRepository.Commit();

                    return RedirectToAction("Index");
                }
            }
        }
        public ActionResult Delete(int id)
        {
            EmployeeModel employeeModel = _employeeRepository.GetbyId(id);
            if (employeeModel==null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(employeeModel);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            EmployeeModel employeeModelToDelete = _employeeRepository.GetbyId(id);
            if (employeeModelToDelete==null)
            {
                return HttpNotFound();
            }
            else
            {
                _employeeRepository.Delete(id);
                _employeeRepository.Commit();

                return RedirectToAction("Index");
            }
        }
    }
}