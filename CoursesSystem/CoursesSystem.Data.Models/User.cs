namespace CoursesSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        private ICollection<CoursePeriod> coursePeriods;

        public User()
        {
            this.coursePeriods = new HashSet<CoursePeriod>();
        }

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

        public virtual ICollection<CoursePeriod> CoursePeriods
        {
            get { return this.coursePeriods; }
            set { this.coursePeriods = value; }
        }
    }
}
