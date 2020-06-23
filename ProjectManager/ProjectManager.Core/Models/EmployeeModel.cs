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
        public EmployeeModel()
        {
            GalleryModels = new List<GalleryModel>();
        }
        public int Id { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        public bool Gender { get; set; }
        public string Url { get; set; }
        public string EMail { get; set; }
        public string Password { get; set; }
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual DepartmentModel DepartmentModel { get; set; }
        public virtual ICollection<GalleryModel> GalleryModels { get; set; }
       
    }
}
