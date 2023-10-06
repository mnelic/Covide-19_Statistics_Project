using CovidApp_Part2.Models;

namespace CovidApp_Part2.Data
{
    public class EFLabRepository : RepositoryBase<Lab>, ILabRepository
    {
        public EFLabRepository(AppDbContext appDbContext)
            : base(appDbContext)
        {
        }
    }
}
