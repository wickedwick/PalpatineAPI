namespace PalpatineApi.Migrations.PalpatineData
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFKtoAspNetUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserDatas", "UserGuid", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserDatas", "UserGuid");
        }
    }
}
