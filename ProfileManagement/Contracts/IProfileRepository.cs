using ProfileManagement.Model;

namespace ProfileManagement.Contracts
{
    public interface IProfileRepository
    {
        public Task<IEnumerable<Profile>> GetProfile();
        //public Task<IEnumerable<Profile>> saveDiagnosis(Profile objPatient);
        //public Task<IEnumerable<Profile>> updateDiagnosis(Profile objPatient);
    }
}

