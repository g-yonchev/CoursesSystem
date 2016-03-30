namespace CoursesSystem.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<CoursesSystemDbContext>
    {
        public Configuration()
        {
            // TODO: Remove in production.
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(CoursesSystemDbContext context)
        {
        }
    }
}
