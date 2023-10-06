using CovidApp_Part2.Models;

namespace CovidApp_Part2.Data
{
    public class EFProvinceRepository : RepositoryBase<Province>, IProvinceRepository
    {
        public EFProvinceRepository(AppDbContext appDbContext)
            : base(appDbContext)
        {
        }
    }
}
