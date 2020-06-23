using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Core.Models
{
    public class GalleryModel:BaseEntity
    {
        public GalleryModel()
        {
            ImageModels = new List<ImageModel>();
        }
        public int Id { get; set; }
        [StringLength(300)]
        public string Title { get; set; }
        public string Url { get; set; }
        public int EmployeeModelId { get; set; }
        public virtual EmployeeModel EmployeeModel { get; set; }
        public virtual ICollection<ImageModel> ImageModels { get; set; }
    }
}
