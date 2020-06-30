using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Core.Models
{
    public class ManagerModel:BaseEntity
    {
        public ManagerModel()
        {
            GalleryModels = new List<GalleryModel>();
        }
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public bool Gender { get; set; }
        public string ProfileUrl { get; set; }
        [Display(Name = "E-Mail")]
        [StringLength(200)]
        public string Email { get; set; }
        public virtual ICollection<GalleryModel> GalleryModels { get; set; }
    }
}
