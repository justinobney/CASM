using System.Data.Entity.Migrations;

namespace Jobney.Casm.Data
{
    public static class DatabaseUpgrader
    {
        public static void PerformUpgrade()
        {
            var config = new Migrations.Configuration
            {
                AutomaticMigrationsEnabled = false
            };
            var migrator = new DbMigrator(config);
            migrator.Update();
        }
    }
}
