using System.Collections.Generic;
using SpeedDoesMatter.DataAccess.Entities;

namespace SpeedDoesMatter.DataAccess.Repositories
{
    public interface IPageSpeedTestRepository
    {
        public void AddPageSpeedTest(PageSpeedTest pagespeedtest);

        public PageSpeedTest GetPageSpeedTestById(int id);

        public List<PageSpeedTest> GetPageSpeedTests();

        public void EditPageSpeedTest(PageSpeedTest pagespeedtest);

        public void DeletePageSpeedTestById(int id);
    }
}