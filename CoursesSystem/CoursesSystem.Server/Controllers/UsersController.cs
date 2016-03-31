namespace CoursesSystem.Server.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using CoursesSystem.Data.Models;
    using CoursesSystem.Data.Repositories;
    using CoursesSystem.Server.Infrastructure.Mapping;
    using CoursesSystem.Server.Models.Users;

    public class UsersController : BaseController
    {
        public UsersController(ICoursesSystemData data)
            : base(data)
        {
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var users = this.data.Users.All().To<UserResponseModel>().ToList();
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