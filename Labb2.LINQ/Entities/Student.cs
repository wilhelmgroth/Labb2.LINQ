using System;
using System.Collections.Generic;
using System.Text;

namespace Labb2.LINQ.Entities
{
    public class Student
    {
        public int ID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public Year Class { get; set; }
        public List<Course> Courses { get; set; }


    }
}
