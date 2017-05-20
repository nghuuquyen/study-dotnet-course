using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Code_First
{
    [Table("Khoa")]
    public class Khoa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_Khoa { get; set; }
        public string TenKhoa { get; set; }
        public int LoaiKhoa { get; set; }
        public virtual ICollection<SV> SVs { get; set; }
    }
}
