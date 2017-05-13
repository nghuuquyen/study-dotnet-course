using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framwork_Code_First.Models
{
    public class Lop
    {
        public Lop()
        {
            this.SinhViens = new HashSet<SinhVien>();
        }

        public int id { get; set; }
        public string ten { get; set; }

        public virtual ICollection<SinhVien> SinhViens { get; set; }
    }
}
