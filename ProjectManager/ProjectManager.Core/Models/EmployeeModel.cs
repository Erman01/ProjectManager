using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Core.Models
{
    public class EmployeeModel : BaseEntity
    {
        public int Id { get; set; }
        [StringLength(50)]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [StringLength(50)]
        [Display(Name ="Last Name")]
        public string LastName { get; set; }
        public bool Gender { get; set; }
        [Display(Name = "Employee Image")]
        public string Url { get; set; }
        [Display(Name ="E-Mail")]
        public string EMail { get; set; }
        [Display(Name ="Date of Birth")]
        public DateTime DateOfBirth { get; set; }
        [Display(Name ="Department Name")]
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual DepartmentModel DepartmentModel { get; set; }
        
       
    }
}
