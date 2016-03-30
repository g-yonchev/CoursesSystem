using CoursesSystem.Data;
using CoursesSystem.Data.Models;
using CoursesSystem.Data.Repositories;
using CoursesSystem.Server.Models.Courses;
using CoursesSystem.Server.Models.Periods;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace CoursesSystem.Server.Controllers
{
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
            var courses = this.data.Courses
                                    .All()
                                    .Where(x => x.Periods.Any(p => p.StartDate > DateTime.Now))
                                    .OrderBy(x => x.Name)
                                    .Select(x => new { name = x.Name })
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
                Name = model.Name
            };

            this.data.Courses.Add(course);
            this.data.SaveChanges();

            return this.Ok(course);
        }

        [HttpPut]
        [Route("join/{courseId}/{userId}")]
        public IHttpActionResult Join(int courseId, int userId)
        {
            // check logged user
            // check user is employeer.
            // check model is valid.

            var user = this.data.Users.GetById(userId);
            var course = this.data.Courses.GetById(courseId);

            // check user is already in this course.


            user.Courses.Add(course);
            this.data.SaveChanges();

            return this.Ok("joined");
        }

        [HttpPut]
        [Route("periods/{courseId}")]
        public IHttpActionResult AddPeriod(PeriodRequestModel model, int courseId)
        {
            // TODO: check: first period savechanges or first add and then savechanges?!?!?1
            var period = new Period
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