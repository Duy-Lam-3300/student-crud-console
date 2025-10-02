using DataAccess;
using Repositories;
using StudentObjects;

namespace StudentCRUD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var context = new AppDBContext();
            IStudentRepo repo=new StudentRepo(context);

            repo.AddStudent(new Student { Name = "Alice", DateOfBirth = new DateTime(2003, 12, 23) });

            Console.WriteLine("Student added");
            foreach(var s in repo.GetAll())
            {
                Console.WriteLine($"{s.Id} | {s.Name} | {s.DateOfBirth:yyyy-MM-dd}");

            }

        }
    }
}
