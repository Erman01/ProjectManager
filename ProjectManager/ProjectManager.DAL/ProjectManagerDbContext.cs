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
            this.Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<EmployeeModel> EmployeeModels { get; set; }
        public DbSet<DepartmentModel> DepartmentModels { get; set; }
        public DbSet<ManagerModel> ManagerModels { get; set; }
        public DbSet<GalleryModel> GalleryModels { get; set; }
        public DbSet<GalleryImageModel> GalleryImageModels { get; set; }
    }
}
