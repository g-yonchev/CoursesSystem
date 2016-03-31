using CoursesSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesSystem.Data
{
    public interface ICoursesSystemDbContext
    {
        IDbSet<User> Users { get; set; }

        IDbSet<CoursePeriod> CoursePeriods { get; set; }

        IDbSet<Course> Courses { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity)
            where TEntity : class;

        void Dispose();

        int SaveChanges();
    }
}
