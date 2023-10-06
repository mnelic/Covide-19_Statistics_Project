using CovidApp_Part2.Models;

namespace CovidApp_Part2.Data
{
    public interface IPatientStatusRepository : IRepositoryBase<PatientStatus>
    {
        int GetCurrentStatusOfPatient(int id);
    }
}
