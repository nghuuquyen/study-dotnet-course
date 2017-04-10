using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV_LINQ_3Layer_Demo.DAL
{
    class StudentDAL
    {
        DataClasses1DataContext db = new DataClasses1DataContext();

        public System.Collections.Generic.List<SV> getAll()
        {
            return db.SVs.Select(s => s).ToList();
        }
    }
}
