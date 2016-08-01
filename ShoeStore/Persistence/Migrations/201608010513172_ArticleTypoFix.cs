namespace ShoeStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ArticleTypoFix : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "Description", c => c.String(maxLength: 255));
            DropColumn("dbo.Articles", "Desription");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Articles", "Desription", c => c.String(maxLength: 255));
            DropColumn("dbo.Articles", "Description");
        }
    }
}
