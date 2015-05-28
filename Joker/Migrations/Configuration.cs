using Joker.Models;

namespace Joker.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Joker.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Joker.Models.ApplicationDbContext";
        }

        protected override void Seed(Joker.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Jokes.AddOrUpdate(
              p => p.JokeTitle,
              new Joke { JokeTitle = "What's a drummer with half a brain?" },
              new Joke { JokeTitle = "Why did the chicken cross the road?" }
            );
            
        }
    }
}
