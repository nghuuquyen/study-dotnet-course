namespace Simple_EF_Code_First
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SV")]
    public partial class SV
    {
        [Key]
        [StringLength(50)]
        public string MSSV { get; set; }

        [Required]
        public string Name { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public string DiaChi { get; set; }

        [StringLength(50)]
        public string tel { get; set; }

        public int? Nien_Khoa { get; set; }

        public int ID_Lop { get; set; }

        public virtual Lop Lop { get; set; }
    }
}
