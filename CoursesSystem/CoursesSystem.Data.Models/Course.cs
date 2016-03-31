namespace CoursesSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Course
    {
        private ICollection<CoursePeriod> periods;

        public Course()
        {
            this.periods = new HashSet<CoursePeriod>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public virtual ICollection<CoursePeriod> Periods
        {
            get { return this.periods; }
            set { this.periods = value; }
        }
    }
}
