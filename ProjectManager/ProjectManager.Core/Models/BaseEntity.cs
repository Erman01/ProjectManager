using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Core.Models
{
    public abstract class BaseEntity
    {
        public DateTime CreatedAt { get; set; }
        public BaseEntity()
        {
            this.CreatedAt = DateTime.Now;
        }
    }
}
