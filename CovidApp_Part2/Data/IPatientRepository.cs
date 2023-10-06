using CovidApp_Part2.Models;
using System.Collections.Generic;

namespace CovidApp_Part2.Data
{
    public interface IPatientRepository : IRepositoryBase<Patient>
    {
        IEnumerable<Patient> GetPatientsWithDetails(string sortBy);
        Patient GetPatientWithStatusDetails(int id);
    }
}
