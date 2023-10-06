using CovidApp_Part2.Models;
using System.Linq;

namespace CovidApp_Part2.Data
{
    public class EFPatientStatusRepository : RepositoryBase<PatientStatus>, IPatientStatusRepository
    {
        public EFPatientStatusRepository(AppDbContext appDbContext)
            : base(appDbContext)
        {
        }

        //GetCurrentStatus of Patient
        public int GetCurrentStatusOfPatient(int id)
        {
            PatientStatus result = _appDbContext.PatientStatuses
                .Where(p => p.PatientId == id)
                .OrderByDescending(p => p.PatientStatusDate)
                .FirstOrDefault();

            if (result == null)
                return 0;
            else
                return result.StatusId;
        }
    }
}
