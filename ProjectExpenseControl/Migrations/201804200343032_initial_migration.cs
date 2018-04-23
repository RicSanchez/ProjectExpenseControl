namespace ProjectExpenseControl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial_migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        TUSR_IDE_RESOURCE = c.Int(nullable: false, identity: true),
                        TUSR_DES_TYPE = c.String(),
                        TUSR_FH_CREATED = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TUSR_IDE_RESOURCE);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        USR_IDE_USER = c.Int(nullable: false, identity: true),
                        USR_IDE_AREA = c.String(),
                        USR_DES_POSITION = c.String(),
                        USR_DES_NAME = c.String(),
                        USR_DES_FIRST_NAME = c.String(),
                        USR_DES_LAST_NAME = c.String(),
                        USR_DES_PASSWORD = c.String(),
                        USR_DES_PHONE = c.String(),
                        USR_DES_EMAIL = c.String(),
                        USR_FH_CREATED = c.DateTime(nullable: false),
                        USR_LAST_LOGIN = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        ActivationCode = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.USR_IDE_USER);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        USR_IDE_USER = c.Int(nullable: false),
                        TUSR_IDE_RESOURCE = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.USR_IDE_USER, t.TUSR_IDE_RESOURCE })
                .ForeignKey("dbo.Users", t => t.USR_IDE_USER, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.TUSR_IDE_RESOURCE, cascadeDelete: true)
                .Index(t => t.USR_IDE_USER)
                .Index(t => t.TUSR_IDE_RESOURCE);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRoles", "TUSR_IDE_RESOURCE", "dbo.Roles");
            DropForeignKey("dbo.UserRoles", "USR_IDE_USER", "dbo.Users");
            DropIndex("dbo.UserRoles", new[] { "TUSR_IDE_RESOURCE" });
            DropIndex("dbo.UserRoles", new[] { "USR_IDE_USER" });
            DropTable("dbo.UserRoles");
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
        }
    }
}
