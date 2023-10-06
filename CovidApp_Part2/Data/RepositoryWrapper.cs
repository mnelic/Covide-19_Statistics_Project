namespace CovidApp_Part2.Data
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private AppDbContext _appDbContext;
        private IGenderRepository _gender;
        private ILabRepository _lab;
        private IPatientRepository _patient;
        private IPatientStatusRepository _patientStatus;
        private IProvinceRepository _province;
        private IStatusRepository _status;
        private ITestRepository _test;
        private ITestResultRepository _testResult;

        public RepositoryWrapper(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IGenderRepository Gender
        {
            get
            {
                if (_gender == null)
                {
                    _gender = new EFGenderRepository(_appDbContext);
                }

                return _gender;
            }
        }

        public ILabRepository Lab
        {
            get
            {
                if (_lab == null)
                {
                    _lab = new EFLabRepository(_appDbContext);
                }

                return _lab;
            }
        }

        public IPatientRepository Patient
        {
            get
            {
                if (_patient == null)
                {
                    _patient = new EFPatientRepository(_appDbContext);
                }

                return _patient;
            }
        }

        public IPatientStatusRepository PatientStatus
        {
            get
            {
                if (_patientStatus == null)
                {
                    _patientStatus = new EFPatientStatusRepository(_appDbContext);
                }

                return _patientStatus;
            }
        }

        public IProvinceRepository Province
        {
            get
            {
                if (_province == null)
                {
                    _province = new EFProvinceRepository(_appDbContext);
                }

                return _province;
            }
        }

        public IStatusRepository Status
        {
            get
            {
                if (_status == null)
                {
                    _status = new EFStatusRepository(_appDbContext);
                }

                return _status;
            }
        }

        public ITestRepository Test
        {
            get
            {
                if (_test == null)
                {
                    _test = new EFTestRepository(_appDbContext);
                }

                return _test;
            }
        }

        public ITestResultRepository TestResult
        {
            get
            {
                if (_testResult == null)
                {
                    _testResult = new EFTestResultRepository(_appDbContext);
                }

                return _testResult;
            }
        }
    }
}
