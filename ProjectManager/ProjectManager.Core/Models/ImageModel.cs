using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Core.Models
{
    public class ImageModel : BaseEntity
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string Title { get; set; }
        [StringLength(300)]
        public string Description { get; set; }
        public string Url { get; set; }
        public int GalleryModelId { get; set; }
        public int EmployeeModelId { get; set; }
        public virtual GalleryModel GalleryModel { get; set; }
        public virtual EmployeeModel EmployeeModel { get; set; }
    }
}
