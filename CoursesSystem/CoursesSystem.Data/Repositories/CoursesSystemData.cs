using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoursesSystem.Data.Models;
using System.Data.Entity;

namespace CoursesSystem.Data.Repositories
{
    public class CoursesSystemData : ICoursesSystemData
    {
        private readonly DbContext context;
        private readonly IDictionary<Type, object> repositories;

        public CoursesSystemData()
        {
            this.context = new CoursesSystemDbContext();
            this.repositories = new Dictionary<Type, object>();
        }

        public IDbRepository<Course> Courses
        {
            get
            {
                return this.GetRepository<Course>();
            }
        }

        public IDbRepository<Period> Periods
        {
            get
            {
                return this.GetRepository<Period>();
            }
        }

        public IDbRepository<User> Users
        {
            get
            {
                return this.GetRepository<User>();
            }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IDbRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepository = typeof(T);

            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(DbRepository<T>), this.context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IDbRepository<T>)this.repositories[typeOfRepository];
        }
    }
}
