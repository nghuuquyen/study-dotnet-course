namespace FinalProject_QuanLySinhVien
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
        public int MSSV { get; set; }

        [StringLength(255)]
        public string TenSV { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgaySinh { get; set; }

        [StringLength(255)]
        public string QueQuan { get; set; }

        [StringLength(255)]
        public string HoKhau { get; set; }

        public bool? GioiTinh { get; set; }

        public double? DiemTB { get; set; }

        public int? MaKhoa { get; set; }

        public virtual Khoa Khoa { get; set; }
    }
}
