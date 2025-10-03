using DataAccess;
using StudentObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class StudentRepo:IStudentRepo
    {
        private readonly AppDBContext _context;

        public StudentRepo(AppDBContext context)
        {
            _context=context;
        }

        public void AddStudent(Student stu)
        {
            _context.Students.Add(stu);
            _context.SaveChanges();
        }

        public void DeleteStudent(int id)
        {
            var student = _context.Students.Find(id);
            if (student != null)
            {
                student.IsDeleted=true;
                _context.Students.Update(student);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Student> GetAll()
        {
            return _context.Students.ToList().Where(x=>x.IsDeleted==false);
        }
        public IEnumerable<Student> GetByName(string stuName)
        {
            return _context.Students.Where(x=>x.LastName.ToLower().Trim().Contains(stuName.ToLower().Trim())).ToList().Where(x => x.IsDeleted == false);
        }

        public Student? GetById(int id)
        {
            return _context.Students.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateStudent(Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
        }
    }
}
