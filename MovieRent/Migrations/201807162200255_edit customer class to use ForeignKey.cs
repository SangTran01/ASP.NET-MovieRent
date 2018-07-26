namespace MovieRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editcustomerclasstouseForeignKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "MemberShipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MemberShipTypeId" });
            AddColumn("dbo.Customers", "Membership_Id", c => c.Byte());
            AlterColumn("dbo.Customers", "MembershipTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "Membership_Id");
            AddForeignKey("dbo.Customers", "Membership_Id", "dbo.MembershipTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "Membership_Id", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "Membership_Id" });
            AlterColumn("dbo.Customers", "MembershipTypeId", c => c.Byte(nullable: false));
            DropColumn("dbo.Customers", "Membership_Id");
            CreateIndex("dbo.Customers", "MemberShipTypeId");
            AddForeignKey("dbo.Customers", "MemberShipTypeId", "dbo.MembershipTypes", "Id", cascadeDelete: true);
        }
    }
}
