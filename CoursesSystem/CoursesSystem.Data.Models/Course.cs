namespace CoursesSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class Course
    {
        private ICollection<User> users;
        private ICollection<Period> periods;

        public Course()
        {
            this.users = new HashSet<User>();
            this.periods = new HashSet<Period>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public bool HasActivePeriods
        {
            get
            {
                var isActive = this.Periods.Any(x => x.StartDate > DateTime.Now);
                return isActive;
            }
        }

        public virtual ICollection<User> Users
        {
            get { return this.users; }
            set { this.users = value; }
        }

        public virtual ICollection<Period> Periods
        {
            get { return this.periods; }
            set { this.periods = value; }
        }
    }
}
