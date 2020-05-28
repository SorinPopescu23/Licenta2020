namespace Licenta1.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Licenta1.Models.Licenta1Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Licenta1.Models.Licenta1Context";
        }

        protected override void Seed(Licenta1.Models.Licenta1Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
