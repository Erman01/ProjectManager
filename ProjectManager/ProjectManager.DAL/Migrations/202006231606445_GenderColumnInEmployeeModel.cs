namespace ProjectManager.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GenderColumnInEmployeeModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmployeeModels", "Gender", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.EmployeeModels", "Gender");
        }
    }
}
