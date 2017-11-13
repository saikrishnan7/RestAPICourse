namespace RestAPICourse.Migrations
{
    using RestAPICourse.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RestAPICourse.Models.RestAPICourseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RestAPICourse.Models.RestAPICourseContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Contacts.AddOrUpdate(new Contact[]
        {
            new Contact()
            {
                Id = 0, FirstName = "Sai", LastName="Srivatsan"
            },
            new Contact()
            {
                Id = 1, FirstName = "Sindhu", LastName="Sai"
            },
            new Contact()
            {
                Id = 2, FirstName="Tejas", LastName="Krishnan"
            }
        });

        }
    }
}
