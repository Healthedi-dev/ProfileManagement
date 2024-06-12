using ProfileManagement.Model;

namespace ProfileManagement.Contracts
{
    public interface IProfileRepository
    {
        public Task<IEnumerable<Profile>> GetProfile();
        public Task<IEnumerable<Profile>> saveProfile(Profile objPatient);
        public Task<IEnumerable<Profile>> updateProfile(Profile objPatient);
        public Task<IEnumerable<Profile>> deleteProfile(long id);
    }
}

