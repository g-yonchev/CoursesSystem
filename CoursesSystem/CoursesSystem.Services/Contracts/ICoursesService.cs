namespace CoursesSystem.Services.Contracts
{
    using System;
    using System.Linq;

    using CoursesSystem.Data.Models;

    public interface ICoursesService
    {
        IQueryable<Course> GetAllActive();

        Course GetById(int id);

        Course Create(string name);
        
        void AddPeriod(int courseId, DateTime start, DateTime end);
    }
}
