namespace VidlyNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'27b9c2be-a2ea-4c6f-8069-c30c4fea6c54', N'guest@vidly.com', 0, N'AIQiW727CK73k86eia1M3bciR0Ki8w+lWlU6ldxh8MYB8tvwoPzAV9cGbQ4LSUQWGg==', N'f1b75674-121c-47f4-87f6-13e555b2b95c', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'749ad11e-9252-4b49-a3da-59003a5d8443', N'admin@vidly.com', 0, N'AO6RjsKAGLJaAPuntn3NQeVJLlrK5Pe268aUOEhCsgN+2WSzdlzzmw4tzytBXGl4mQ==', N'43c4d53e-071e-4c02-ac51-745a4e63ecf0', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'9d9a1de4-3c24-4f75-8555-531d576dfe3a', N'canManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'749ad11e-9252-4b49-a3da-59003a5d8443', N'9d9a1de4-3c24-4f75-8555-531d576dfe3a')

            ");
        }

        public override void Down()
        {
        }
    }
}
