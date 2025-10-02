using StudentObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IStudentRepo
    {
        void AddStudent(Student stu);
        IEnumerable<Student> GetAll();
        Student? GetById(int id);
        IEnumerable<Student> GetByName(string name);
        void UpdateStudent(Student student);   
        void DeleteStudent(int id);
        
    }
}
