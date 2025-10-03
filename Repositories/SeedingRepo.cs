using DataAccess;
using StudentObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class SeedingRepo
    {
        public static void Seed(AppDBContext dBContext)
        {
            if (!dBContext.Schools.Any())
            {
                var schools=new List<School> {
                  new School { Id = 1, Name = "Greenwood High", YearEstablish = 1995 },
                    new School { Id = 2, Name = "Riverdale Academy", YearEstablish = 2001 },
                    new School { Id = 3, Name = "Sunrise International", YearEstablish = 2010 }
                };
                dBContext.Schools.AddRange(schools);
            }
            if (!dBContext.Students.Any())
            {
                var students=new List<Student> {
                  new Student { Id = 1, FirstName = "Alice",   LastName = "Johnson", DateOfBirth = new DateTime(2005, 3, 14),  SchoolId = 1 },
                    new Student { Id = 2, FirstName = "Bob",     LastName = "Smith",   DateOfBirth = new DateTime(2004, 11, 2),  SchoolId = 1 },
                    new Student { Id = 3, FirstName = "Charlie", LastName = "Nguyen",  DateOfBirth = new DateTime(2006, 7, 21),  SchoolId = 1 },
                    new Student { Id = 4, FirstName = "Daisy",   LastName = "Tran",    DateOfBirth = new DateTime(2005, 5, 10),  SchoolId = 2 },
                    new Student { Id = 5, FirstName = "Ethan",   LastName = "Lee",     DateOfBirth = new DateTime(2003, 12, 25), SchoolId = 2 },
                    new Student { Id = 6, FirstName = "Fiona",   LastName = "Garcia",  DateOfBirth = new DateTime(2004, 8, 30),  SchoolId = 2 },
                    new Student { Id = 7, FirstName = "George",  LastName = "Brown",   DateOfBirth = new DateTime(2006, 1, 18),  SchoolId = 3 },
                    new Student { Id = 8, FirstName = "Hannah",  LastName = "Wilson",  DateOfBirth = new DateTime(2005, 6, 5),   SchoolId = 3 },
                    new Student { Id = 9, FirstName = "Ivan",    LastName = "Pham",    DateOfBirth = new DateTime(2004, 4, 22),  SchoolId = 3 },
                    new Student { Id = 10, FirstName = "Julia",  LastName = "Taylor",  DateOfBirth = new DateTime(2003, 9, 12),  SchoolId = 3 }
                };
                dBContext.Students.AddRange(students);
            }
            if (!dBContext.Grades.Any())
            {
                var grades=new List<Grade> {
                 new Grade { Id = 1,  Subject = "Math",    Score = 85, StudentId = 1 },
                    new Grade { Id = 2,  Subject = "English", Score = 90, StudentId = 1 },
                    new Grade { Id = 3,  Subject = "Science", Score = 78, StudentId = 2 },
                    new Grade { Id = 4,  Subject = "History", Score = 82, StudentId = 2 },
                    new Grade { Id = 5,  Subject = "Math",    Score = 88, StudentId = 3 },
                    new Grade { Id = 6,  Subject = "English", Score = 76, StudentId = 3 },
                    new Grade { Id = 7,  Subject = "Math",    Score = 91, StudentId = 4 },
                    new Grade { Id = 8,  Subject = "Science", Score = 85, StudentId = 4 },
                    new Grade { Id = 9,  Subject = "English", Score = 72, StudentId = 5 },
                    new Grade { Id = 10, Subject = "History", Score = 80, StudentId = 5 },
                    new Grade { Id = 11, Subject = "Science", Score = 95, StudentId = 6 },
                    new Grade { Id = 12, Subject = "Math",    Score = 89, StudentId = 6 },
                    new Grade { Id = 13, Subject = "Math",    Score = 65, StudentId = 7 },
                    new Grade { Id = 14, Subject = "English", Score = 70, StudentId = 7 },
                    new Grade { Id = 15, Subject = "Science", Score = 92, StudentId = 8 },
                    new Grade { Id = 16, Subject = "Math",    Score = 84, StudentId = 8 },
                    new Grade { Id = 17, Subject = "History", Score = 77, StudentId = 9 },
                    new Grade { Id = 18, Subject = "English", Score = 86, StudentId = 9 },
                    new Grade { Id = 19, Subject = "Math",    Score = 93, StudentId = 10 },
                    new Grade { Id = 20, Subject = "Science", Score = 88, StudentId = 10 }
                };
                dBContext.Grades.AddRange(grades);
            }
            dBContext.SaveChanges();

        }
    }
}
