namespace CoursesSystem.Data
{
    using System;
    using System.Data.Entity;

    using CoursesSystem.Data.Models;

    public class CoursesSystemDbContext : DbContext, ICoursesSystemDbContext
    {
        public CoursesSystemDbContext()
            : base("CoursesSystem")
        {
        }

        public virtual IDbSet<User> Users { get; set; }

        public virtual IDbSet<Course> Courses { get; set; }

        public virtual IDbSet<Period> Periods { get; set; }

        public static CoursesSystemDbContext Create()
        {
            return new CoursesSystemDbContext();
        }
    }
}
