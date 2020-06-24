using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Core.Models
{
    public abstract class BaseEntity
    {
        [Display(Name ="Created At")]
        public DateTime CreatedAt { get; set; }
        public BaseEntity()
        {
            this.CreatedAt = DateTime.Now;
        }
    }
}
