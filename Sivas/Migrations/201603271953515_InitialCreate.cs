namespace Sivas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Category = c.Int(nullable: false),
                        Image = c.Binary(),
                        Landscape = c.Boolean(nullable: false),
                        Brand = c.String(),
                        Model = c.String(),
                        EnergyStar = c.Int(nullable: false),
                        Color = c.String(),
                        Specification = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Products");
        }
    }
}
