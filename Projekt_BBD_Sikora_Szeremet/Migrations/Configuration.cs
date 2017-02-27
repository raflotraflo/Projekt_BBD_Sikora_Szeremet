using Projekt_BBD_Sikora_Szeremet.Models;

namespace Projekt_BBD_Sikora_Szeremet.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Projekt_BBD_Sikora_Szeremet.Repository.RepositoryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Projekt_BBD_Sikora_Szeremet.Repository.RepositoryContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var dbsetContractor = context.Set<Animal>();

            for (int i = 1; i <= 5; i++)
            {
                var newContractor = new Animal()
                {
                    Name = "Rafa³ " + i,
                    DateOfBirth = new DateTime(1992, 3, 17)
                };


                dbsetContractor.AddOrUpdate(newContractor);

            }

            context.SaveChanges();
        }
    }
}
