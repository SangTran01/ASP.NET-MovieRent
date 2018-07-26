namespace MovieRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateMoviesdata : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT into Movies (Title, Genre, ReleaseDate, DateAdded, NumberInStock) " +
                "Values ('Star Ware - The Last Jedi', 'Action', 'December 15, 2017', 'July 16, 2018', 10)");
            Sql("INSERT into Movies (Title, Genre, ReleaseDate, DateAdded, NumberInStock) " +
                "Values ('A Quiet Place', 'Thriller', 'April 6, 2018', 'July 16, 2018', 4)");
            Sql("INSERT into Movies (Title, Genre, ReleaseDate, DateAdded, NumberInStock) " +
                "Values ('The Lego Movie', 'Comedy', 'February 7, 2014', 'July 16, 2018', 6)");
            Sql("INSERT into Movies (Title, Genre, ReleaseDate, DateAdded, NumberInStock) " +
                "Values ('Avengers: Infinity War', 'Action', 'April 27, 2018', 'July 16, 2018', 5)");
        }
        
        public override void Down()
        {
        }
    }
}
