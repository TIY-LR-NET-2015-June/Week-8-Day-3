namespace Week8Day3.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Week8Day3.Models.postdbcontext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Week8Day3.Models.postdbcontext context)
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
            context.Posts.AddOrUpdate(x => x.Title,
                new Models.post() { Aurthor = "Daniel Pollock", Title = "How to do Asp.Net web Api", Body = "Just do it!" },
                new Models.post() { Aurthor = "Jason Williams", Title = "How to do Asp.Net web Api", Body = "Just do it!" },
                new Models.post() { Aurthor = "billy bob", Title = "How to do Asp.Net web Api", Body = "Just do it!" },
                new Models.post() { Aurthor = "job hunter", Title = "How to do Asp.Net web Api", Body = "Just do it!" });

        }
    }
}
