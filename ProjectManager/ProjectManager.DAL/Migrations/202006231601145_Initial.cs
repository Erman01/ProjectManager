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
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DepartmentModels", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);
            
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
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GalleryModels", t => t.GalleryModelId, cascadeDelete: true)
                .Index(t => t.GalleryModelId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ImageModels", "GalleryModelId", "dbo.GalleryModels");
            DropForeignKey("dbo.GalleryModels", "EmployeeModelId", "dbo.EmployeeModels");
            DropForeignKey("dbo.EmployeeModels", "DepartmentId", "dbo.DepartmentModels");
            DropIndex("dbo.ImageModels", new[] { "GalleryModelId" });
            DropIndex("dbo.GalleryModels", new[] { "EmployeeModelId" });
            DropIndex("dbo.EmployeeModels", new[] { "DepartmentId" });
            DropTable("dbo.ImageModels");
            DropTable("dbo.GalleryModels");
            DropTable("dbo.EmployeeModels");
            DropTable("dbo.DepartmentModels");
        }
    }
}
