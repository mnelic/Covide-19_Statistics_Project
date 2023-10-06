using CovidApp_Part2.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CovidApp_Part2.Data
{
    public class EFTestRepository : RepositoryBase<Test>, ITestRepository
    {
        public EFTestRepository(AppDbContext appDbContext)
            : base(appDbContext)
        {
        }
    }
}
