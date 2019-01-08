namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class twoUpdate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Student", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Student", "Image", c => c.String());
        }
    }
}
