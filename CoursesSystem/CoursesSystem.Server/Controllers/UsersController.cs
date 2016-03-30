using CoursesSystem.Data;
using CoursesSystem.Data.Models;
using CoursesSystem.Data.Repositories;
using CoursesSystem.Server.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace CoursesSystem.Server.Controllers
{
    public class UsersController : BaseController
    {
        public UsersController(ICoursesSystemData data)
            : base(data)
        {
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var users = this.data.Users.All().ToList();
            return this.Ok(users);
        }

        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var user = this.data.Users.GetById(id);

            if (user == null)
            {
                return this.NotFound();
            }

            return this.Ok(user);
        }

        [HttpPost]
        public IHttpActionResult Create(UserRequestModel model)
        {
            var user = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Age = model.Age,
                IsMale = model.IsMale,
                IsEmployeer = model.IsEmployeer,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Address = model.Address
            };

            this.data.Users.Add(user);

            return this.Ok(user);
        }
    }
}