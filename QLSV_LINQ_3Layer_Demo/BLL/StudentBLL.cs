using QLSV_LINQ_3Layer_Demo.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV_LINQ_3Layer_Demo.BLL
{
    

    class StudentBLL
    {
        StudentDAL db = new StudentDAL();

        public System.Collections.Generic.List<SV> getAll()
        {
            return db.getAll();
        }
    }
}
