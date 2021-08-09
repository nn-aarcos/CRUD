using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyWebApiCRUD.Entities;

namespace MyWebApiCRUD.StudentData
{
    public interface IStudentCRUD
    {
        List<Student> GetAll();
        Student GetStudentById(int id);
        Student AddNewStudent(Student student);
        Student EditStudent(Student student);
        void DeleteStudent(int id);
    }
}