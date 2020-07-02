namespace ProjectManager.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUrlColumnToGalleryImageModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GalleryImageModels", "Url", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.GalleryImageModels", "Url");
        }
    }
}
