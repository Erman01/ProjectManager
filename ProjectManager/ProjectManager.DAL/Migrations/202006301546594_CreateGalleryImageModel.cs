namespace ProjectManager.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateGalleryImageModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GalleryImageModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        GalleryModelId = c.Int(nullable: false),
                        ManagerModelId = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        ManagerModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GalleryModels", t => t.GalleryModelId, cascadeDelete: true)
                .ForeignKey("dbo.ManagerModels", t => t.ManagerModel_Id)
                .Index(t => t.GalleryModelId)
                .Index(t => t.ManagerModel_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GalleryImageModels", "ManagerModel_Id", "dbo.ManagerModels");
            DropForeignKey("dbo.GalleryImageModels", "GalleryModelId", "dbo.GalleryModels");
            DropIndex("dbo.GalleryImageModels", new[] { "ManagerModel_Id" });
            DropIndex("dbo.GalleryImageModels", new[] { "GalleryModelId" });
            DropTable("dbo.GalleryImageModels");
        }
    }
}
