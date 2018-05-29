namespace ProjectExpenseControl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Store_Procedures : DbMigration
    {
        public override void Up()
        {
            Sql(ResourceSQL.Create_SP_DeleteUserRemoveRole);
            Sql(ResourceSQL.Create_SP_InsertUserAddRoleDefault);
        }
        
        public override void Down()
        {
            Sql(ResourceSQL.DROP_SP);
        }
    }
}
