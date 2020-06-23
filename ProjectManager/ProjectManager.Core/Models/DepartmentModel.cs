using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Core.Models
{
    public class DepartmentModel : BaseEntity
    {
        public DepartmentModel()
        {
            EmployeeModels = new List<EmployeeModel>();
        }
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public virtual ICollection<EmployeeModel> EmployeeModels { get; set; }
    }
}
