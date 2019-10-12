namespace VidlyNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [dbo].[Genres] ([Name]) VALUES ('Comedy')");
            Sql("INSERT INTO [dbo].[Genres] ([Name]) VALUES ('Action')");
            Sql("INSERT INTO [dbo].[Genres] ([Name]) VALUES ('Family')");
            Sql("INSERT INTO [dbo].[Genres] ([Name]) VALUES ('Romance')");
            Sql("INSERT INTO [dbo].[Genres] ([Name]) VALUES ('Drama')");

        }
        
        public override void Down()
        {
        }
    }
}
