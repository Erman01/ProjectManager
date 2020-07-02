using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Display(Name ="Image")]
        public string Url { get; set; }
        [Display(Name ="Gallery Name")]
        public int GalleryModelId { get; set; }
        public virtual GalleryModel GalleryModel { get; set; }
        [Display(Name ="Manager Name")]
        public string ManagerModelId { get; set; }
        public virtual ManagerModel ManagerModel { get; set; }
    }
}
