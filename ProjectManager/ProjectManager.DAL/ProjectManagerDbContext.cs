using ProjectManager.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.DAL
{
    public class ProjectManagerDbContext:DbContext
    {
        public ProjectManagerDbContext():base("DefaultConnection")
        {

        }
        public DbSet<EmployeeModel> EmployeeModels { get; set; }
        public DbSet<DepartmentModel> DepartmentModels { get; set; }
        public DbSet<ImageModel> ImageModels { get; set; }
        public DbSet<GalleryModel> GalleryModels { get; set; }
    }
}
