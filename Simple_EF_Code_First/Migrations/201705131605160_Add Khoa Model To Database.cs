namespace Simple_EF_Code_First.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddKhoaModelToDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Khoa",
                c => new
                    {
                        MSKhoa = c.String(nullable: false, maxLength: 50),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.MSKhoa);
        }
        
        public override void Down()
        {
            DropTable("dbo.Khoa");
        }
    }
}
