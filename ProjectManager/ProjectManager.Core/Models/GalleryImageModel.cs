using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Core.Models
{
    public class GalleryImageModel:BaseEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int GalleryModelId { get; set; }
        public virtual GalleryModel GalleryModel { get; set; }
        public string ManagerModelId { get; set; }
        public virtual ManagerModel ManagerModel { get; set; }
    }
}
