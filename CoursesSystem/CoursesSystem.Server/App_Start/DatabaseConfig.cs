using CoursesSystem.Data;
using CoursesSystem.Data.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CoursesSystem.Server
{
    public class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CoursesSystemDbContext, Configuration>());
            CoursesSystemDbContext.Create().Database.Initialize(true);
        }
    }
}