namespace CoursesSystem.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Period
    {
        [Key]
        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
}