using Labb2.LINQ.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Labb2.LINQ
{
    public class SchoolContext : DbContext
    {
        public DbSet<Year> Year { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-D1QEIP0J\SQLEXPRESS;Initial Catalog=School;Integrated Security=True;");
        }
    }
}
