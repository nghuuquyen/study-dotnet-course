using StudentManagingVer2;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManaging3LayersDemo
{
    class LopDAL
    {
       private DBHelper DBHelper = new DBHelper();
        
       public Lop[] getListLop()
       {
            string sqlCmd = "SELECT * FROM Lop";
            DataTable d = DBHelper.DBExcuteQuery(sqlCmd);
            int count = d.Rows.Count;

            Lop[] results = new Lop[count];

            for (int i = 0; i < count; i++)
            {
                results[i] = GetLopFromDataRow(d.Rows[i]);
            }

            return results;
       }

        private Lop GetLopFromDataRow(DataRow row)
        {
            Lop l = new Lop();
            l.IDLop = row["ID_Lop"].ToString();
            l.TenLop = row["Ten_Lop"].ToString();
            return l;
        }
    }
}
