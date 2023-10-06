using CovidApp_Part2.Models;

namespace CovidApp_Part2.Data
{
    public class EFTestResultRepository : RepositoryBase<TestResult>, ITestResultRepository
    {
        public EFTestResultRepository(AppDbContext appDbContext)
            : base(appDbContext)
        {
        }
    }
}
