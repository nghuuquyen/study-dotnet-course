namespace FinalProject_QuanLySinhVien.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Khoa",
                c => new
                    {
                        MaKhoa = c.Int(nullable: false),
                        Ten = c.String(maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.MaKhoa);
            
            CreateTable(
                "dbo.SV",
                c => new
                    {
                        MSSV = c.Int(nullable: false, identity: true),
                        TenSV = c.String(maxLength: 255, unicode: false),
                        NgaySinh = c.DateTime(storeType: "date"),
                        QueQuan = c.String(maxLength: 255, unicode: false),
                        HoKhau = c.String(maxLength: 255, unicode: false),
                        GioiTinh = c.Boolean(),
                        DiemTB = c.Double(),
                        MaKhoa = c.Int(),
                    })
                .PrimaryKey(t => t.MSSV)
                .ForeignKey("dbo.Khoa", t => t.MaKhoa)
                .Index(t => t.MaKhoa);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SV", "MaKhoa", "dbo.Khoa");
            DropIndex("dbo.SV", new[] { "MaKhoa" });
            DropTable("dbo.SV");
            DropTable("dbo.Khoa");
        }
    }
}
