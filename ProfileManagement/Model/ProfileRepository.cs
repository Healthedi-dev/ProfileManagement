using ProfileManagement.Contracts;
using ProfileManagement.Model;
using Dapper;
namespace ClearingHouse_Backend.Model
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly DapperContext _context;

        public ProfileRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Profile>> GetProfile()
       {
          

            var query = "SELECT * FROM Profile";
            using (var connection = _context.CreateConnection())
            {
                var companies = await connection.QueryAsync<Profile>(query);
                return companies.ToList();
            }
        }

       
    }
}
