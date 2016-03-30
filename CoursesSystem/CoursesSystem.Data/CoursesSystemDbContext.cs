namespace CoursesSystem.Data
{
    using System.Data.Entity;

    using CoursesSystem.Data.Models;

    public class CoursesSystemDbContext : DbContext
    {
        public CoursesSystemDbContext()
            : base("CoursesSystemSystem")
        {
        }

        public virtual IDbSet<User> Clients { get; set; }
    }
}
