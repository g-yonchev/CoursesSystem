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
        private readonly IPeriodsService periodsService;

        public CoursesService(IDbRepository<Course> courses, IPeriodsService periodsService)
        {
            this.courses = courses;
            this.periodsService = periodsService;
        }

        public IQueryable<Course> GetAllActive()
        {
            var activeCourses = this.courses.All().Where(c => c.HasActivePeriods == true);
            return activeCourses;
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
            var period = this.periodsService.Create(start, end);
            var course = this.GetById(courseId);
            course.Periods.Add(period);

            this.courses.Save();
        }
    }
}
