namespace CoursesSystem.Services
{
    using System;
    using System.Linq;

    using CoursesSystem.Data.Models;
    using CoursesSystem.Data.Repositories;
    using CoursesSystem.Services.Contracts;

    public class UsersService : IUsersService
    {
        private readonly IDbRepository<User> users;

        public UsersService(IDbRepository<User> users)
        {
            this.users = users;
        }

        public IQueryable<User> GetAll()
        {
            var users = this.users.All();
            return users;
        }

        public User GetById(int id)
        {
            var user = this.users.GetById(id);
            return user;
        }

        public User Create(string firstName, string lastName, int age, bool isMale, bool isEmployeer, string email, string phoneNumber, string address)
        {
            var user = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Age = age,
                IsMale = isMale,
                IsEmployeer = isEmployeer,
                Email = email,
                PhoneNumber = phoneNumber,
                Address = address
            };

            this.users.Add(user);
            this.users.Save();

            return user;
        }
    }
}
