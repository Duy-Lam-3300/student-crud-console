using DataAccess;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Repositories;
using StudentObjects;

namespace StudentCRUD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var context = new AppDBContext();
            var repo=new StudentRepo(context);

            while (true)
            {
                Console.WriteLine("\n--- Student Management System ---");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. View Students");
                Console.WriteLine("3. Find Student's Name");
                Console.WriteLine("4. Update Student");
                Console.WriteLine("5. Delete Student");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": AddStudent(repo); break;
                    case "2": ViewsStudent(repo); break;
                    case "3": FindStudentName(repo); break;
                    case "4": UpdateStudent(repo); break;

                    case "6": return;
                    default: Console.WriteLine("Invalid option!");break;


                }
            }

        }
        static void AddStudent(StudentRepo repo)
        {
            Console.WriteLine("Enter name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter date of birth (yyyy-mm-dd): ");
            DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());

            repo.AddStudent(new Student { Name=name, DateOfBirth=dateOfBirth });

            Console.WriteLine("Student "+name+" added successfully");

        }
        static void ViewsStudent(StudentRepo repo) {
            var students = repo.GetAll();
            int order = 0;
            if(students.Count() == 0)
            {
                Console.WriteLine("No Student Found");
                return;

            }
            foreach(var s in students)
            {
                order++;
                Console.WriteLine($"{order}: {s.Name}, Date of birth: {s.DateOfBirth}");
            }

        }
        static IEnumerable<Student> FindStudentName(StudentRepo repo) {
            Console.WriteLine("Enter student's name: ");
            string studentName= Console.ReadLine();
            while(String.IsNullOrWhiteSpace(studentName.Trim()))
            {
                Console.WriteLine("Enter student's name: ");
                studentName = Console.ReadLine();
            }
            var students = repo.GetByName(studentName);
            int order = 0;
            if(students.Count() == 0)
            {
                Console.WriteLine("No Student Found");
                return null;

            }
            Console.WriteLine("Order \t| Name \t| Date of birth");
            foreach(var s in students)
            {
                order++;
                Console.WriteLine($"{order} \t| {s.Name} \t| Date of birth: {s.DateOfBirth}");
            }
            return students.ToList();

        }
        static void UpdateStudent(StudentRepo repo) {
            var students = FindStudentName(repo);
            Console.WriteLine("Choose student's order: ");
            int index;
            while (!int.TryParse(Console.ReadLine(), out index) || index < 1 || index > students.Count())
            {
                Console.WriteLine("Choose student's order: ");
            }
            var choosedStudent = students.ElementAt(index - 1);

            Console.WriteLine($"You choose: {choosedStudent.Name} \t | Date of birth: {choosedStudent.DateOfBirth}");

            Console.WriteLine("New student's name: ");
            var newName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newName))
            {
                choosedStudent.Name = newName;
            } else
            {
                Console.WriteLine("Student's name unchanged!");

            }

            Console.WriteLine("New student's DateOfBirth (yyyy-mm-dd): ");
            var dateTimeInput = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(dateTimeInput)) {
                DateTime newDateOfBirth;
                while (!DateTime.TryParse(dateTimeInput, out newDateOfBirth))
                {
                    Console.WriteLine("New student's DateOfBirth (yyyy-mm-dd): ");
                    dateTimeInput = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(dateTimeInput))
                        break;
                }



                if (!string.IsNullOrWhiteSpace(dateTimeInput))
                {
                    choosedStudent.DateOfBirth = newDateOfBirth;
                }
            } else
            {
                Console.WriteLine("Date of birth unchanged!");

            }

            repo.UpdateStudent(choosedStudent);
            Console.WriteLine($"Student updated to: {choosedStudent.Name} \t| {choosedStudent.DateOfBirth}");
            return;


        }
    }
}
