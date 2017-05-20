namespace Simple_Code_First.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Khoa",
                c => new
                    {
                        ID_Khoa = c.Int(nullable: false, identity: true),
                        TenKhoa = c.String(),
                    })
                .PrimaryKey(t => t.ID_Khoa);
            
            CreateTable(
                "dbo.SV",
                c => new
                    {
                        MSSV = c.Int(nullable: false, identity: true),
                        HoTen = c.String(),
                        ID_Khoa = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MSSV)
                .ForeignKey("dbo.Khoa", t => t.ID_Khoa, cascadeDelete: true)
                .Index(t => t.ID_Khoa);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SV", "ID_Khoa", "dbo.Khoa");
            DropIndex("dbo.SV", new[] { "ID_Khoa" });
            DropTable("dbo.SV");
            DropTable("dbo.Khoa");
        }
    }
}
