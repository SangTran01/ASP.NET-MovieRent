namespace MovieRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTitlefieldtoMovieclass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Title", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Title");
        }
    }
}
