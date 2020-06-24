using ProjectManager.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Core.ViewModels
{
    public class EmployeeViewModel
    {
        public EmployeeModel EmployeeModel { get; set; }
        public IEnumerable<DepartmentModel> DepartmentModels { get; set; }
    }
}
