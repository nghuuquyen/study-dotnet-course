//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Sinhvien
    {
        public int id { get; set; }
        public string hoten { get; set; }
        public string sodienthoai { get; set; }
        public string email { get; set; }
        public string lopid { get; set; }
    
        public virtual SinhVienMonHoc SinhVienMonHoc { get; set; }
        public virtual lop lop { get; set; }
        public virtual sinhviendiachi sinhviendiachi { get; set; }
    }
}