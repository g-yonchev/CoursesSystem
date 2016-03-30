namespace CoursesSystem.Services
{
    using System;

    using CoursesSystem.Data.Models;
    using CoursesSystem.Data.Repositories;
    using CoursesSystem.Services.Contracts;

    public class PeriodsService : IPeriodsService
    {
        private readonly IDbRepository<Period> periods;

        public PeriodsService(IDbRepository<Period> periods)
        {
            this.periods = periods;
        }

        public Period Create(DateTime start, DateTime end)
        {
            var period = new Period
            {
                StartDate = start,
                EndDate = end
            };

            this.periods.Add(period);
            this.periods.Save();

            return period;
        }
    }
}
