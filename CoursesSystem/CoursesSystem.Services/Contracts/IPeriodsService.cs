namespace CoursesSystem.Services.Contracts
{
    using System;

    using CoursesSystem.Data.Models;

    public interface IPeriodsService
    {
        Period Create(DateTime start, DateTime end);
    }
}
