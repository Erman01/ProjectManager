namespace ProjectManager.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeeModelIdChangedIntToString : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GalleryModels", "EmployeeModelId", "dbo.EmployeeModels");
            DropIndex("dbo.GalleryModels", new[] { "EmployeeModelId" });
            AddColumn("dbo.GalleryModels", "EmployeeModel_Id", c => c.Int());
            AlterColumn("dbo.GalleryModels", "EmployeeModelId", c => c.String());
            CreateIndex("dbo.GalleryModels", "EmployeeModel_Id");
            AddForeignKey("dbo.GalleryModels", "EmployeeModel_Id", "dbo.EmployeeModels", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GalleryModels", "EmployeeModel_Id", "dbo.EmployeeModels");
            DropIndex("dbo.GalleryModels", new[] { "EmployeeModel_Id" });
            AlterColumn("dbo.GalleryModels", "EmployeeModelId", c => c.Int(nullable: false));
            DropColumn("dbo.GalleryModels", "EmployeeModel_Id");
            CreateIndex("dbo.GalleryModels", "EmployeeModelId");
            AddForeignKey("dbo.GalleryModels", "EmployeeModelId", "dbo.EmployeeModels", "Id", cascadeDelete: true);
        }
    }
}
