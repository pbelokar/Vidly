namespace VidlyNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDOBinCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "DateofBirth", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "DateofBirth");
        }
    }
}
