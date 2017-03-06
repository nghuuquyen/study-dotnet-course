using StudentManagingStudentManaging3LayersDemo.Models;
using StudentManagingVer2;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManaging3LayersDemo
{
    public class StudentDTO
    {
        DBHelper DBHelper = new DBHelper();
        public Student[] getAllStudents()
        {
            string sqlCmd = "SELECT * FROM SV";
            DataTable d = DBHelper.DBExcuteQuery(sqlCmd);
            int count = d.Rows.Count;

            Student[] students = new Student[count];
            for (int i = 0; i < count; i++)
            {
                students[i] = GetStudentFromDataRow(d.Rows[i]);
            }

            return students;
        }

        private Student GetStudentFromDataRow(DataRow row)
        {
            Student s = new Student();
            s.MSSV = row["MSSV"].ToString();
            s.Name = row["Name"].ToString();
            s.DiaChi = row["DiaChi"].ToString();
            return s;
        }
    }
}
