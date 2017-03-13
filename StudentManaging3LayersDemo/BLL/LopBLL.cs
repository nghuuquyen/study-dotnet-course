using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManaging3LayersDemo
{
    class LopBLL
    {
        private LopDAL lopDAL = new LopDAL();
        public Lop[] getListLop()
        {
            return lopDAL.getListLop();
        }
    }
}
