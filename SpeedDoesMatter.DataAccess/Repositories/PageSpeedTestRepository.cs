using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using SpeedDoesMatter.DataAccess.Entities;

namespace SpeedDoesMatter.DataAccess.Repositories
{
    public class PageSpeedTestRepository : IPageSpeedTestRepository
    {
        public void AddPageSpeedTest(PageSpeedTest pagespeedtest)
        {
            using (var context = new DatabaseContext())
            {
                context.PageSpeedTest.Add(pagespeedtest);
                context.SaveChanges();
            }
        }

        public PageSpeedTest GetPageSpeedTestById(int id)
        {
            using (var context = new DatabaseContext())
            {
                return context.PageSpeedTest.FirstOrDefault(a => a.Id == id);
            }
        }

        public List<PageSpeedTest> GetPageSpeedTests()
        {
            using (var context = new DatabaseContext())
            {
                return context.PageSpeedTest.ToList();
            }
        }

        public void EditPageSpeedTest(PageSpeedTest pagespeedtest)
        {
            using (var context = new DatabaseContext())
            {
                var entity = context.PageSpeedTest.Find(pagespeedtest.Id);
                if (entity == null) 
                    return;

                context.Entry(entity).CurrentValues.SetValues(pagespeedtest);
                context.SaveChanges();
            }
        }

        public void DeletePageSpeedTestById(int id)
        {
            using (var context = new DatabaseContext())
            {
                var entity = context.PageSpeedTest.Find(id);
                if (entity == null) 
                    return;

                context.PageSpeedTest.Remove(entity);
                context.SaveChanges();
            }
        }

        public string GetSQLiteVersion()
        {
            using (var context = new DatabaseContext())
            {
                using (var sqlConnection = context.GetSqLiteConnection())
                {
                    sqlConnection.Open();
                    SQLiteCommand command = new SQLiteCommand("SELECT SQLITE_VERSION()", context.GetSqLiteConnection());

                    return command.ExecuteScalar().ToString();
                }
            }
        }
    }
}