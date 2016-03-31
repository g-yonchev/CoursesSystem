namespace CoursesSystem.Server.Models.Periods
{
    using System;

    using CoursesSystem.Data.Models;
    using CoursesSystem.Server.Infrastructure.Mapping;

    public class PeriodRequestModel : IMapFrom<CoursePeriod>
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}