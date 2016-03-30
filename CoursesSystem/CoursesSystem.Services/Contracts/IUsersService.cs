namespace CoursesSystem.Services.Contracts
{
    using System.Linq;

    using CoursesSystem.Data.Models;

    public interface IUsersService
    {
        IQueryable<User> GetAll();

        User GetById(int id);

        User Create(string firstName, string lastName, int age, bool isMale, bool isEmployeer, string email, string phoneNumber, string address);
    }
}
