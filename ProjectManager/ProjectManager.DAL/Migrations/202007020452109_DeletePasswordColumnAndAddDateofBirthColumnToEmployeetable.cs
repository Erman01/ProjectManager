namespace ProjectManager.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletePasswordColumnAndAddDateofBirthColumnToEmployeetable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmployeeModels", "DateOfBirth", c => c.DateTime(nullable: false));
            DropColumn("dbo.EmployeeModels", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EmployeeModels", "Password", c => c.String());
            DropColumn("dbo.EmployeeModels", "DateOfBirth");
        }
    }
}
