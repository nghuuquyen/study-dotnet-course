namespace Simple_Code_First.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Khoa", "LoaiKhoa", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Khoa", "LoaiKhoa");
        }
    }
}
