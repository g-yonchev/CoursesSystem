using CoursesSystem.Data;
using CoursesSystem.Data.Models;
using CoursesSystem.Data.Repositories;
using CoursesSystem.Server.Models.Users;
using CoursesSystem.Services;
using CoursesSystem.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace CoursesSystem.Server.Controllers
{
    public class UsersController : ApiController
    {
        private readonly IUsersService usersService;

        // Poor man's IoC
        public UsersController()
        {
            this.usersService = new UsersService(new DbRepository<User>(new CoursesSystemDbContext()));
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var users = this.usersService.GetAll().ToList();
            return this.Ok(users);
        }

        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var user = this.usersService.GetById(id);

            if (user == null)
            {
                return this.NotFound();
            }

            return this.Ok(user);
        }

        [HttpPost]
        public IHttpActionResult Create(UserRequestModel model)
        {
            var user = this.usersService.Create(
                model.FirstName,
                model.LastName,
                model.Age,
                model.IsMale,
                model.IsEmployeer,
                model.Email,
                model.PhoneNumber,
                model.Address);

            return this.Ok(user);
        }
    }
}