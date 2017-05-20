using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Simple_Code_First
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MyDBContext : DbContext
    {
        public MyDBContext()
            : base("name=StudentDBContext")
        {
            //Database.SetInitializer<MyDBContext>(new CreateDatabaseIfNotExists<MyDBContext>());
            Database.SetInitializer<MyDBContext>(new CreateDB());
        }

        public virtual DbSet<SV> SVs { get; set; }
        public virtual DbSet<Khoa> Khoas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        
        }

        public class CreateDB : CreateDatabaseIfNotExists<MyDBContext>
        {
            protected override void Seed(MyDBContext context)
            {

                var Khoa_1 = new Khoa
                {
                    TenKhoa = "Cong Nghe Thong Tin"
                };

                var Khoa_2 = new Khoa
                {
                    TenKhoa = "Dien Tu Vien Thong"
                };


                context.Khoas.Add(Khoa_1);
                context.Khoas.Add(Khoa_2);
                context.SaveChanges();

                base.Seed(context);
            }
        }
    }
}
