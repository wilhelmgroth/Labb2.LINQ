using Labb2.LINQ.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2.LINQ
{
    class Startup
    {
        private static Course[] courseTypes = new Course[]
        {
            new Course { CourseName = "Mathematics", ID = 1 },
            new Course { CourseName = "Geography", ID = 2 },
            new Course { CourseName = "Physics", ID = 3  },
            new Course { CourseName = "Computer Science", ID = 4  },
            new Course { CourseName = "Defense Against the Dark Arts", ID = 5  },
            new Course { CourseName = "Chess", ID = 6 },
            new Course { CourseName = "Bridge", ID = 7 }
        };

        private static Student[] students = new Student[]
        {
            new Student { Firstname = "Phoebe", Lastname = "Buffay"},
            new Student { Firstname = "Ross", Lastname = "Geller"},
            new Student { Firstname = "Chandler", Lastname = "Bing"},
            new Student { Firstname = "Monica", Lastname = "Geller"},
            new Student { Firstname = "Hikaru", Lastname ="Nakamura"}
        };

        private static Teacher[] teachers = new Teacher[]
       {
            new Teacher { Firstname = "Anis"},
            new Teacher { Firstname = "Reider"},
            new Teacher { Firstname = "Voldemort"},
            new Teacher { Firstname = "Dumbledore"},
            new Teacher { Firstname = "Scorsese"},
       };

        private static Year[] classYear = new Year[]
      {
            new Year { ClassYear = "2020-A"},
            new Year { ClassYear = "2019-A"},
            new Year { ClassYear = "2020-B"},
            new Year { ClassYear = "2021-B"},
            new Year { ClassYear = "2021-A"},
      };

        public static void SeedThis(SchoolContext context)
        {
            SeedCourses(context);
            SeedTeachers(context);
            SeedStudents(context);
            SeedClassYear(context);

            context.SaveChanges();
        }

        public static void SeedCourses(SchoolContext context)
        {
            var courseTypesInDB = context.Courses.ToList();
            foreach (var row in courseTypes)
            {
                if (!courseTypesInDB.Any(x => x.ID == row.ID))
                    context.Courses.Add(row);
            }

        }

        public static void SeedStudents(SchoolContext context)
        {
            var studentsInDB = context.Students.ToList();
            foreach (var row in students)
            {
                if (!studentsInDB.Any(x => x.Firstname == row.Firstname && x.Lastname == row.Lastname))
                {
                    context.Students.Add(row);
                }
            }

        }

        public static void SeedClassYear(SchoolContext context)
        {
            var classNamesInDB = context.Year.ToList();

            foreach (var row in classYear)
            {
                if (!classNamesInDB.Any(x => x.ClassYear == row.ClassYear))
                {
                    context.Year.Add(row);
                }
            }

        }

        public static void SeedTeachers(SchoolContext context)
        {

            var teachersInDB = context.Teachers.ToList();
            foreach (var row in teachers)
            {
                if (!teachersInDB.Any(x => x.Firstname == row.Firstname))
                {
                    context.Teachers.Add(row);
                }
            }
        }

    }
}
