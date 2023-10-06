using CovidApp_Part2.Models;

namespace CovidApp_Part2.Data
{
    public class EFStatusRepository : RepositoryBase<Status>, IStatusRepository
    {
        public EFStatusRepository(AppDbContext appDbContext)
            : base(appDbContext)
        {
        }
    }
}
