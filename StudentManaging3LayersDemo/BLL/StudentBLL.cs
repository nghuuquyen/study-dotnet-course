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
        private StudentDTO studentDTO = new StudentDTO();
        public Student[] getStudents()
        {
            return studentDTO.getAllStudents();
        }
    }
}
