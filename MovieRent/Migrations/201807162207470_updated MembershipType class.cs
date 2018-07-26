namespace MovieRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedMembershipTypeclass : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "Membership_Id", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "Membership_Id" });
            DropColumn("dbo.Customers", "MembershipTypeId");
            RenameColumn(table: "dbo.Customers", name: "Membership_Id", newName: "MembershipTypeId");
            DropPrimaryKey("dbo.MembershipTypes");
            AlterColumn("dbo.Customers", "MembershipTypeId", c => c.Int(nullable: false));
            AlterColumn("dbo.MembershipTypes", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.MembershipTypes", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Movies", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Movies", "Genre", c => c.String(nullable: false));
            AddPrimaryKey("dbo.MembershipTypes", "Id");
            CreateIndex("dbo.Customers", "MembershipTypeId");
            AddForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipTypeId" });
            DropPrimaryKey("dbo.MembershipTypes");
            AlterColumn("dbo.Movies", "Genre", c => c.String());
            AlterColumn("dbo.Movies", "Title", c => c.String());
            AlterColumn("dbo.MembershipTypes", "Name", c => c.String());
            AlterColumn("dbo.MembershipTypes", "Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.Customers", "MembershipTypeId", c => c.Byte());
            AddPrimaryKey("dbo.MembershipTypes", "Id");
            RenameColumn(table: "dbo.Customers", name: "MembershipTypeId", newName: "Membership_Id");
            AddColumn("dbo.Customers", "MembershipTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "Membership_Id");
            AddForeignKey("dbo.Customers", "Membership_Id", "dbo.MembershipTypes", "Id");
        }
    }
}
