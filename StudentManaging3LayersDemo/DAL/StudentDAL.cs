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
using System.Windows.Forms;

namespace StudentManaging3LayersDemo
{
    public class StudentDAL
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
            s.NienKhoa = row["Nien_Khoa"].ToString();
            s.Tel = row["Tel"].ToString();
            s.ID_Lop = row["ID_Lop"].ToString();
            s.Date = DateTime.Parse(row["Date"].ToString());
            return s;
        }

        public void update(Student sv)
        {
            string updateCmdString = "";
            updateCmdString = " UPDATE SV"
                            + " SET "
                            + " Name = '" + sv.Name + "',"
                            + " DiaChi = '" + sv.DiaChi + "',"
                            + " Nien_Khoa = " + sv.NienKhoa
                            + " WHERE SV.MSSV = '" + sv.MSSV + "'";
            DBHelper.DBExcuteNonQuery(updateCmdString);
        }

        public void save(Student sv)
        {
            string sqlCmd = "INSERT INTO SV(MSSV , Name , DiaChi, Nien_Khoa, ID_Lop , Date)"
                          + " VALUES("
                          + "'" + sv.MSSV + "',"
                          + "'" + sv.Name + "',"
                          + "'" + sv.DiaChi + "',"
                          + "'" + sv.NienKhoa + "',"
                          + "'" + sv.ID_Lop + "',"
                          + "'" + DateTime.Now.ToShortDateString() + "'"
                          + ")";

            MessageBox.Show(sqlCmd);

            DBHelper.DBExcuteNonQuery(sqlCmd);
        }
    }
}
