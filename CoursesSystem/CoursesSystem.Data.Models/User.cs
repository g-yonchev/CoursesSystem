﻿namespace CoursesSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        [Key]
        public int Id { get; set; }

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
