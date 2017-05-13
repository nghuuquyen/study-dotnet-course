using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framwork_Code_First.Models
{
    public class MonHoc
    {
        public MonHoc()
        {
            this.SinhVienMonHocs = new HashSet<SinhVienMonHoc>();
        }
        public int id { get; set; }
        public string name { get; set; }

        public virtual ICollection<SinhVienMonHoc> SinhVienMonHocs { get; set; }
    }
}
