namespace CovidApp_Part2.Data
{
    public interface IRepositoryWrapper
    {
        IGenderRepository Gender { get; }
        ILabRepository Lab { get; }
        IPatientRepository Patient { get; }
        IPatientStatusRepository PatientStatus { get; }
        IProvinceRepository Province { get; }
        IStatusRepository Status { get; }
        ITestRepository Test { get; }
        ITestResultRepository TestResult { get; }
    }
}
