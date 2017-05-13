namespace Simple_EF_Code_First
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class StudentDBModel : DbContext
    {
        public StudentDBModel()
            : base("name=StudentDBModel")
        {
        }

        public virtual DbSet<Lop> Lops { get; set; }
        public virtual DbSet<SV> SVs { get; set; }
        public virtual DbSet<Khoa> Khoas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lop>()
                .HasMany(e => e.SVs)
                .WithRequired(e => e.Lop)
                .WillCascadeOnDelete(false);
        }
    }
}
