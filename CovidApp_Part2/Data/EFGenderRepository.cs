using CovidApp_Part2.Models;

namespace CovidApp_Part2.Data
{
    public class EFGenderRepository : RepositoryBase<Gender>, IGenderRepository
    {
        public EFGenderRepository(AppDbContext appDbContext)
            : base(appDbContext)
        {
        }
    }
}
