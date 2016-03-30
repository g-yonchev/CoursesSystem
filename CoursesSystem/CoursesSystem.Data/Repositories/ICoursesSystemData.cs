using CoursesSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesSystem.Data.Repositories
{
    public interface ICoursesSystemData
    {
        IDbRepository<User> Users { get; }

        IDbRepository<Course> Courses { get; }

        IDbRepository<Period> Periods { get; }

        int SaveChanges();

        IDbRepository<T> GetRepository<T>() where T : class;
    }
}
