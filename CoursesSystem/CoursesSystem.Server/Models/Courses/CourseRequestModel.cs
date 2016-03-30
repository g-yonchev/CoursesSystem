namespace CoursesSystem.Server.Models.Courses
{
    using CoursesSystem.Data.Models;
    using CoursesSystem.Server.Infrastructure.Mapping;

    public class CourseRequestModel : IMapFrom<Course>
    {
        public string Name { get; set; }
    }
}