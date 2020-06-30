using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Core.Models
{
    public class GalleryModel:BaseEntity
    {
        public GalleryModel()
        {
            GalleryImageModels = new List<GalleryImageModel>();

        }
        [Key]
        public int Id { get; set; }
        [StringLength(300)]
        public string Title { get; set; }
        public string Url { get; set; }
        public string ManagerModelId { get; set; }
        public virtual ManagerModel ManagerModel { get; set; }
        public virtual ICollection<GalleryImageModel> GalleryImageModels { get; set; }
        

    }
}
