﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLSV_Entity_Framework_Demo_Model_First
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class QLSVModelContainer : DbContext
    {
        public QLSVModelContainer()
            : base("name=QLSVModelContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<MonHoc> MonHocs { get; set; }
        public DbSet<SinhVienMonHoc> SinhVienMonHocs { get; set; }
        public DbSet<lop> lops { get; set; }
        public DbSet<Sinhvien> Sinhviens { get; set; }
        public DbSet<sinhviendiachi> sinhviendiachis { get; set; }
    }
}
