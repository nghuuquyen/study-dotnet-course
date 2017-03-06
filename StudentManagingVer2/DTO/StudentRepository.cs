using StudentManagingVer2.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagingVer2.DTO
{
    class StudentRepository
    {
        private ArrayList students;
        private DBHelper DBHelper = new DBHelper();

        public ArrayList getAll()
        {
            SqlDataReader reader = DBHelper.DBExcuteReader("");
            return students;
        }
    }
}
