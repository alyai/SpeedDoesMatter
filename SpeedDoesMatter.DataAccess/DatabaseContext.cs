using System;
using SpeedDoesMatter.DataAccess.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SQLite;
using System.IO;


namespace SpeedDoesMatter.DataAccess
{
    public class DatabaseContext : DbContext
	{
    private const string DATABASE_PATH = "/Users/omega/Documents/GitHub/SpeedDoesMatter/SpeedDoesMatter.DataAccess/SQlite/SpeedDoesMatter.sqlite3";

        private static SQLiteConnection sqLiteConnection;

        public DatabaseContext() :
            base(sqLiteConnection = new SQLiteConnection()
            {
                ConnectionString = new SQLiteConnectionStringBuilder()
                {
                    DataSource = DATABASE_PATH,
                    ForeignKeys = true
                }.ConnectionString
            }, true)
        {
            if (!File.Exists(DATABASE_PATH))
            {
                // Creates the database file, but doesn't create the tables. So an error will still occur when accessing the tables.
                SQLiteConnection.CreateFile(DATABASE_PATH);
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public SQLiteConnection GetSqLiteConnection()
        {
            return sqLiteConnection;
        }

        public DbSet<PageSpeedTest> PageSpeedTest { get; set; }

    }
}
