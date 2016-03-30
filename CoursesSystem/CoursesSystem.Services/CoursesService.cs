namespace CoursesSystem.Services
{
    using System;
    using System.Linq;

    using CoursesSystem.Data.Models;
    using CoursesSystem.Data.Repositories;
    using CoursesSystem.Services.Contracts;

    public class CoursesService : ICoursesService
    {
        private readonly IDbRepository<Course> courses;
        private readonly IDbRepository<User> users;
        private readonly IDbRepository<Period> periods;

        public CoursesService(IDbRepository<Course> courses, IDbRepository<User> users, IDbRepository<Period> periods)
        {
            this.courses = courses;
            this.users = users;
            this.periods = periods;
        }

        public IQueryable<Course> GetAll()
        {
            var courses = this.courses.All();
            return courses;
        }

        public Course GetById(int id)
        {
            var course = this.courses.GetById(id);
            return course;
        }

        public Course Create(string name)
        {
            var course = new Course
            {
                Name = name
            };

            this.courses.Add(course);
            this.courses.Save();

            return course;
        }

        public void AddPeriod(int courseId, DateTime start, DateTime end)
        {
            var period = new Period
            {
                StartDate = start,
                EndDate = end
            };
            this.periods.Add(period);
            this.periods.Save();

            var course = this.GetById(courseId);
            course.Periods.Add(period);

            this.courses.Save();
        }

        public void Join(int courseId, int userId)
        {
            var course = this.courses.GetById(courseId);

            var user = this.users.GetById(userId);

            user.Courses.Add(course);
            course.Users.Add(user);
            this.users.Save();
            this.courses.Save();
        }
    }
}
