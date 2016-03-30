using CoursesSystem.Data;
using CoursesSystem.Data.Models;
using CoursesSystem.Data.Repositories;
using CoursesSystem.Server.Models.Courses;
using CoursesSystem.Server.Models.Periods;
using CoursesSystem.Services;
using CoursesSystem.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace CoursesSystem.Server.Controllers
{
    [RoutePrefix("api/courses")]
    public class CoursesController : ApiController
    {
        private readonly ICoursesService coursesService;

        // Poor man's IoC
        public CoursesController()
        {
            this.coursesService = new CoursesService(
                                        new DbRepository<Course>(new CoursesSystemDbContext()),
                                        new DbRepository<User>(new CoursesSystemDbContext()),
                                        new DbRepository<Period>(new CoursesSystemDbContext()));
        }

        [HttpGet]
        public IHttpActionResult GetAllActive()
        {
            var courses = this.coursesService.GetAll().ToList();
            return this.Ok(courses);
        }

        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var course = this.coursesService.GetById(id);

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

            var course = this.coursesService.Create(model.Name);

            return this.Ok(course);
        }

        [HttpPut]
        [Route("join/{courseId}/{userId}")]
        public IHttpActionResult Join(int courseId, int userId)
        {
            // check logged user
            // check user is employeer.
            // check model is valid.

            this.coursesService.Join(courseId, userId);

            return this.Ok("joined");
        }

        [HttpPut]
        [Route("periods/{courseId}/{userId}")]
        public IHttpActionResult AddPeriod(PeriodRequestModel model, int courseId, int userId)
        {
            // check logged user
            // check user is employeer.
            // check model is valid.

            this.coursesService.Join(courseId, userId);

            return this.Ok("joined");
        }
    }
}