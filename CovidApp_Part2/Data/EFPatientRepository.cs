using CovidApp_Part2.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CovidApp_Part2.Data
{
    public class EFPatientRepository : RepositoryBase<Patient>, IPatientRepository
    {
        public EFPatientRepository(AppDbContext appDbContext)
            : base(appDbContext)
        {
        }

        public IEnumerable<Patient> GetPatientsWithDetails(string sortBy)
        {
            return _appDbContext.Patients
                .OrderBy(s => EF.Property<object>(s, sortBy))
                .Include(g => g.Gender)
                .Include(p => p.Province);
        }

        public Patient GetPatientWithStatusDetails (int id)
        {
            return _appDbContext.Patients
                .Include(g => g.Gender)
                .Include(p => p.Province)
                .Include(p => p.PatientStatuses)
                .ThenInclude(s => s.Status)
                .FirstOrDefault(p => p.PatientId == id);
        }
    }
}
