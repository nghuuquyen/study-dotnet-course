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
    
    public partial class lop
    {
        public lop()
        {
            this.Sinhviens = new HashSet<Sinhvien>();
        }
    
        public int id { get; set; }
        public string ten { get; set; }
    
        public virtual ICollection<Sinhvien> Sinhviens { get; set; }
    }
}