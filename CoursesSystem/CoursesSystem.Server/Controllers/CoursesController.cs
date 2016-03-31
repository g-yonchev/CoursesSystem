namespace CoursesSystem.Server.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;

    using CoursesSystem.Data.Models;
    using CoursesSystem.Data.Repositories;
    using CoursesSystem.Server.Infrastructure.Mapping;
    using CoursesSystem.Server.Models.Courses;
    using CoursesSystem.Server.Models.Periods;

    [RoutePrefix("api/courses")]
    public class CoursesController : BaseController
    {
        public CoursesController(ICoursesSystemData data)
            : base(data)
        {
        }

        [HttpGet]
        public IHttpActionResult GetAllActive()
        {
            var courses = this.data.Periods
                                    .All()
                                    .Where(x => x.StartDate > DateTime.Now)
                                    .To<CourseResponseModel>()
                                    .OrderBy(x => x.StartDate)
                                    .ToList();
            
            return this.Ok(courses);
        }

        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var course = this.data.Courses.GetById(id);

            if (course == null)
            {
                return this.NotFound();
            }

            return this.Ok(course);
        }

        [HttpPost]
        public IHttpActionResult Create(CourseRequestModel model)
        {
            // check logged user
            // check user is employeer.
            // check model is valid.

            var course = new Course
            {
                Name = model.Name,
                Code = model.Code
            };

            this.data.Courses.Add(course);
            this.data.SaveChanges();
            
            return this.Ok("Created");
        }

        [HttpPut]
        [Route("join/{periodId}/{userId}")]
        public IHttpActionResult Join(int periodId, int userId)
        {
            // check logged user
            // check user is employeer.
            // check model is valid.

            var user = this.data.Users.GetById(userId);
            var period = this.data.Periods.GetById(periodId);

            var isUserAlreadyJoined = user.CoursePeriods.Any(x => x == period);

            // check user is already in this course.
            if (isUserAlreadyJoined)
            {
                return this.Ok("already joined");
            }

            user.CoursePeriods.Add(period);
            this.data.SaveChanges();

            return this.Ok("joined");
        }

        [HttpPut]
        [Route("periods/{courseId}")]
        public IHttpActionResult AddPeriod(PeriodRequestModel model, int courseId)
        {
            var period = new CoursePeriod
            {
                StartDate = model.StartDate,
                EndDate = model.EndDate
            };

            var course = this.data.Courses.GetById(courseId);
            course.Periods.Add(period);
            this.data.SaveChanges();

            return this.Ok();
        }
    }
}