using Labb2.LINQ.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Labb2.LINQ
{
    class Program
    {

        private static SchoolContext context = new SchoolContext();
        private static List<Course> courses = context.Courses.ToList();
        private static List<Student> students = context.Students.ToList();

        static void Main(string[] args)
        {
            Startup.SeedThis(context);
            StartProgram();
        }


        private static void StartProgram()
        {
            bool menu = true;
            while (menu)
            {


                Console.WriteLine("1: Get all teachers for one course. Options like Update Teacher is included");
                Console.WriteLine("2: Get all information about students.");
                Console.WriteLine("3: Edit a Course ");


                int number = int.Parse(Console.ReadLine());

                switch (number)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine(" Get all teachers for one course.\n");
                        HandleMenu(() => getTeacherForOneSpecificCourse());
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine(" Get all information about students.\n");
                        HandleMenu(() => getAllStudentsAndTheirTeachers());
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine(" Edit a course\n");
                        HandleMenu(() => EditSubject());

                        break;

                    default:
                        Console.WriteLine("Integer is what i want");
                        break;
                }

            };
        }

        private static void HandleMenu(Action action)
        {
            action();
            Console.ReadLine();
            Console.Clear();

        }

        private static void getAllStudentsAndTheirTeachers()
        {

            IDictionary<Teacher, IList<Student>> TeachersAndStudents = new Dictionary<Teacher, IList<Student>>();

            foreach (var course in courses)
            {
                if (!TeachersAndStudents.ContainsKey(course.Teacher))
                {
                    TeachersAndStudents.Add(course.Teacher, students.Where(x => x.Courses.Where(y => y.Teacher.ID == course.Teacher.ID).Count() != 0).ToList());
                }
            }

            foreach (var x in TeachersAndStudents)
            {
                Console.WriteLine($"{x.Key.Firstname} and {x.Key.Firstname}'s courses:  ");
                courses.ForEach(t => { if (t.Teacher.ID == x.Key.ID) Console.WriteLine("Course: " + t.CourseName); });
                Console.WriteLine();
                Console.WriteLine($"{x.Key.Firstname}'s students: ");

                foreach (var student in x.Value)
                {
                    Console.WriteLine($"Student:  {student.Firstname} {student.Lastname}.  Class: {student.Class.ClassYear}. ");
                    var currentCourse = student.Courses.Where(m => m.Teacher.ID == x.Key.ID).FirstOrDefault();
                    Console.WriteLine($"Course: {currentCourse.CourseName}");
                    Console.WriteLine();
                }
                Console.WriteLine("------------------------------------------------------");
            }
            Console.ReadKey();
        }

        private static void EditSubject()
        {

            searchCourse();

            int choice = int.Parse(Console.ReadLine());

            var seletedcourse = courses[choice - 1];
            Console.WriteLine($"Selected course: {seletedcourse.CourseName} ");

            Console.WriteLine();
            Console.WriteLine("Fill in the new coursename");
            string newCourseName = Console.ReadLine();
            Console.WriteLine($"Changing {seletedcourse.CourseName} to {newCourseName} ");

            seletedcourse.CourseName = newCourseName;
            context.SaveChanges();
            StartProgram();

        }

        private static void searchCourse()
        {
            int idx = 0;
            foreach (var x in courses)
            {
                Console.WriteLine($"{idx + 1} {x.CourseName}");
                idx++;
            }
        }

        private static void getTeacherForOneSpecificCourse()
        {
            searchCourse();
            Console.WriteLine("Choose Course");
            var menu = int.Parse(Console.ReadLine());

            var idx = menu - 1;
            var selectedCourse = courses[idx];

            Console.WriteLine($"Course: {selectedCourse.CourseName}");

            Console.WriteLine($"Teacher of the course: {selectedCourse.Teacher.Firstname}");
            var studentsInCourse = students.Where(x => x.Courses.Where(y => y.ID == selectedCourse.ID).Count() != 0).ToArray();

            foreach (var x in studentsInCourse)
                Console.WriteLine("Student: " + x.Firstname + " " + x.Lastname);

            UpdateTeacher(selectedCourse);
        }


        private static void UpdateTeacher(Course selectedCourse)
        {
            Console.WriteLine("Change Teacher in choosen Course? Y/N?");
            string letter = Console.ReadLine().ToUpper();
            if (letter == "Y")
            {
                Console.WriteLine("Write the name for the new teacher");
                string newTeacherName = Console.ReadLine();
                selectedCourse.Teacher.Firstname = newTeacherName;
                context.SaveChanges();
            }
            else
                Console.WriteLine("You choose no");

        }
    }
}
