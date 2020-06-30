using ProjectManager.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Core.ViewModels
{
    public class GalleryImageViewModel
    {
        public GalleryImageModel GalleryImageModel { get; set; }
        public IEnumerable<GalleryModel> GalleryModels { get; set; }
    }
}
