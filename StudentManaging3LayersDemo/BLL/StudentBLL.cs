using StudentManagingStudentManaging3LayersDemo.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManaging3LayersDemo
{
    public class StudentBLL
    {
        private StudentDAL studentDAL = new StudentDAL();
        public Student[] getStudents()
        {
            return studentDAL.getAllStudents();
        }

        public void saveStudent(Student s)
        {
            studentDAL.save(s);
        }

        public void updateStudent(Student s)
        {
            studentDAL.update(s);
        }

    }
}
