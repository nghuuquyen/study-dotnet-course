using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Code_First
{
    [Table("SV")]
    public class SV
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MSSV { get; set; }
        public string HoTen { get; set; }
        public int ID_Khoa { get; set; }
        [ForeignKey ("ID_Khoa")]
        public virtual Khoa Khoa { get; set; }
    }
}
