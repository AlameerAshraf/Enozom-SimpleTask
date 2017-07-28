namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class h1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        StoreId = c.Int(nullable: false, identity: true),
                        StoreName = c.String(),
                        StoreDescription = c.String(),
                        StoreLogo = c.String(),
                    })
                .PrimaryKey(t => t.StoreId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Stores");
        }
    }
}
