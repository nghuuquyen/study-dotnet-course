using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Simple_EF_Code_First
{
    [Table("Khoa")]
    public partial class Khoa
    {
        [Key]
        [StringLength(50)]
        public string MSKhoa { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
