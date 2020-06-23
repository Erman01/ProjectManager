namespace ProjectManager.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DepartmentModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmployeeModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        Url = c.String(),
                        EMail = c.String(),
                        Password = c.String(),
                        DepartmentId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        DepartmentModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DepartmentModels", t => t.DepartmentModel_Id)
                .Index(t => t.DepartmentModel_Id);
            
            CreateTable(
                "dbo.GalleryModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 300),
                        Url = c.String(),
                        EmployeeModelId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EmployeeModels", t => t.EmployeeModelId, cascadeDelete: true)
                .Index(t => t.EmployeeModelId);
            
            CreateTable(
                "dbo.ImageModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 100),
                        Description = c.String(maxLength: 300),
                        Url = c.String(),
                        GalleryModelId = c.Int(nullable: false),
                        EmployeeModelId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EmployeeModels", t => t.EmployeeModelId, cascadeDelete: true)
                .ForeignKey("dbo.GalleryModels", t => t.GalleryModelId, cascadeDelete: false)
                .Index(t => t.GalleryModelId)
                .Index(t => t.EmployeeModelId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ImageModels", "GalleryModelId", "dbo.GalleryModels");
            DropForeignKey("dbo.ImageModels", "EmployeeModelId", "dbo.EmployeeModels");
            DropForeignKey("dbo.GalleryModels", "EmployeeModelId", "dbo.EmployeeModels");
            DropForeignKey("dbo.EmployeeModels", "DepartmentModel_Id", "dbo.DepartmentModels");
            DropIndex("dbo.ImageModels", new[] { "EmployeeModelId" });
            DropIndex("dbo.ImageModels", new[] { "GalleryModelId" });
            DropIndex("dbo.GalleryModels", new[] { "EmployeeModelId" });
            DropIndex("dbo.EmployeeModels", new[] { "DepartmentModel_Id" });
            DropTable("dbo.ImageModels");
            DropTable("dbo.GalleryModels");
            DropTable("dbo.EmployeeModels");
            DropTable("dbo.DepartmentModels");
        }
    }
}
