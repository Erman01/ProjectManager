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
        public DepartmentManagerController(IRepository<DepartmentModel> departmentModelRepository)
        {
            _departmentModelRepository = departmentModelRepository;
        }
        // GET: DepartmentManager
        public ActionResult Index()
        {
           List<DepartmentModel> departmentModel = _departmentModelRepository.Collection().ToList();

            return View(departmentModel);
        }
    }
}