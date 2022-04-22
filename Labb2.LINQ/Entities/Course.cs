using System;
using System.Collections.Generic;
using System.Text;

namespace Labb2.LINQ.Entities
{
    public class Course
    {
        public int ID { get; set; }
        public string CourseName { get; set; }
        public Teacher Teacher { get; set; }



    }
}
