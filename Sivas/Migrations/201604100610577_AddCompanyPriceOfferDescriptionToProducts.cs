namespace Sivas.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddCompanyPriceOfferDescriptionToProducts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Company", c => c.String());
            AddColumn("dbo.Products", "Price", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "Offer", c => c.Boolean(nullable: false));
            AddColumn("dbo.Products", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Description");
            DropColumn("dbo.Products", "Offer");
            DropColumn("dbo.Products", "Price");
            DropColumn("dbo.Products", "Company");
        }
    }
}
