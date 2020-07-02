using ProjectManager.Core.Contracts;
using ProjectManager.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectManager.MVCUI.Controllers
{
    public class DepartmentManagerController : Controller
    {
        private readonly IRepository<DepartmentModel> _departmentModelRepository;
        private readonly IRepository<EmployeeModel> _employeeModelRepository;
        public DepartmentManagerController(IRepository<DepartmentModel> departmentModelRepository, IRepository<EmployeeModel> employeeModelRepository)
        {
            _departmentModelRepository = departmentModelRepository;
            _employeeModelRepository = employeeModelRepository;
        }
        // GET: DepartmentManager
        public ActionResult Index()
        {
           List<DepartmentModel> departmentModel = _departmentModelRepository.Collection().ToList();

            return View(departmentModel);
        }
        public ActionResult DepartmentEmployees(int id)
        {
            DepartmentModel departmentModel = _departmentModelRepository.GetbyId(id);
            if (departmentModel==null)
            {
                return HttpNotFound();
            }
            else
            {
                List<EmployeeModel> employeeList = _employeeModelRepository.Collection().Where(x => x.DepartmentId == departmentModel.Id).ToList();
                ViewBag.TotalEmployee = employeeList.Count();
                return View(employeeList);
            }
        }
        public ActionResult Create()
        {
            DepartmentModel departmentModel = new DepartmentModel();

            return View(departmentModel);
        }
        [HttpPost]
        public ActionResult Create(DepartmentModel departmentModel)
        {
            if (!ModelState.IsValid)
            {
                return View(departmentModel);
            }
            else
            {
                _departmentModelRepository.Insert(departmentModel);
                _departmentModelRepository.Commit();

                return RedirectToAction("Index");
            }
        }
        public ActionResult Edit(int Id)
        {
            DepartmentModel departmentModel = _departmentModelRepository.GetbyId(Id);
            if (departmentModel==null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(departmentModel);
            }
        }
        [HttpPost]
        public ActionResult Edit(DepartmentModel departmentModel,int Id)
        {
            DepartmentModel departmentModelToUpdate = _departmentModelRepository.GetbyId(Id);
            if (departmentModelToUpdate==null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(departmentModelToUpdate);
                }
                else
                {
                    departmentModelToUpdate.Name = departmentModel.Name;
                    _departmentModelRepository.Commit();

                    return RedirectToAction("Index");
                }
            }
        }
        public ActionResult Delete(int id)
        {
            DepartmentModel departmentModel = _departmentModelRepository.GetbyId(id);
            if (departmentModel==null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(departmentModel);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            DepartmentModel departmentModelToDelete = _departmentModelRepository.GetbyId(id);
            if (departmentModelToDelete==null)
            {
                return HttpNotFound();
            }
            else
            {
                _departmentModelRepository.Delete(id);
                _departmentModelRepository.Commit();

                return RedirectToAction("Index");
            }
        }
    }
}