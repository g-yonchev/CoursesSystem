namespace CoursesSystem.Server.Models.Users
{
    using CoursesSystem.Data.Models;
    using CoursesSystem.Server.Infrastructure.Mapping;

    public class UserRequestModel : IMapFrom<User>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsEmployeer { get; set; }

        public int Age { get; set; }

        public bool IsMale { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }
    }
}