namespace GPUTest2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Data",
                c => new
                    {
                        DataID = c.Int(nullable: false, identity: true),
                        fps = c.Int(nullable: false),
                        stuff = c.String(),
                    })
                .PrimaryKey(t => t.DataID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Data");
        }
    }
}
