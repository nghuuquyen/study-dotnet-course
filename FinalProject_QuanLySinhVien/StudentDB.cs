namespace FinalProject_QuanLySinhVien
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class StudentDB : DbContext
    {
        public StudentDB()
            : base("name=StudentDB")
        {

        }

        public virtual DbSet<Khoa> Khoas { get; set; }
        public virtual DbSet<SV> SVs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Khoa>()
                .Property(e => e.Ten)
                .IsUnicode(false);

            modelBuilder.Entity<SV>()
                .Property(e => e.TenSV)
                .IsUnicode(false);

            modelBuilder.Entity<SV>()
                .Property(e => e.QueQuan)
                .IsUnicode(false);

            modelBuilder.Entity<SV>()
                .Property(e => e.HoKhau)
                .IsUnicode(false);
        }
    }
}
