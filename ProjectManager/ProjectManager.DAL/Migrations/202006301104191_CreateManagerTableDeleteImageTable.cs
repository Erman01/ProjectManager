namespace ProjectManager.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateManagerTableDeleteImageTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GalleryModels", "EmployeeModel_Id", "dbo.EmployeeModels");
            DropForeignKey("dbo.ImageModels", "GalleryModelId", "dbo.GalleryModels");
            DropIndex("dbo.GalleryModels", new[] { "EmployeeModel_Id" });
            DropIndex("dbo.ImageModels", new[] { "GalleryModelId" });
            CreateTable(
                "dbo.ManagerModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        Gender = c.Boolean(nullable: false),
                        ProfileUrl = c.String(),
                        Email = c.String(maxLength: 200),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.GalleryModels", "ManagerModelId", c => c.String());
            AddColumn("dbo.GalleryModels", "ManagerModel_Id", c => c.Int());
            CreateIndex("dbo.GalleryModels", "ManagerModel_Id");
            AddForeignKey("dbo.GalleryModels", "ManagerModel_Id", "dbo.ManagerModels", "Id");
            DropColumn("dbo.GalleryModels", "EmployeeModelId");
            DropColumn("dbo.GalleryModels", "EmployeeModel_Id");
            DropTable("dbo.ImageModels");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.GalleryModels", "EmployeeModel_Id", c => c.Int());
            AddColumn("dbo.GalleryModels", "EmployeeModelId", c => c.String());
            DropForeignKey("dbo.GalleryModels", "ManagerModel_Id", "dbo.ManagerModels");
            DropIndex("dbo.GalleryModels", new[] { "ManagerModel_Id" });
            DropColumn("dbo.GalleryModels", "ManagerModel_Id");
            DropColumn("dbo.GalleryModels", "ManagerModelId");
            DropTable("dbo.ManagerModels");
            CreateIndex("dbo.ImageModels", "GalleryModelId");
            CreateIndex("dbo.GalleryModels", "EmployeeModel_Id");
            AddForeignKey("dbo.ImageModels", "GalleryModelId", "dbo.GalleryModels", "Id", cascadeDelete: true);
            AddForeignKey("dbo.GalleryModels", "EmployeeModel_Id", "dbo.EmployeeModels", "Id");
        }
    }
}
