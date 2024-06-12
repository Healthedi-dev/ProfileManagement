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

        public async Task<IEnumerable<Profile>> saveProfile(Profile objProfile)
        {



            var query = "SELECT NEXT VALUE FOR dbo.parimarySeq AS PROFILEID";
            using (var connection = _context.CreateConnection())
            {
                var model = await connection.QueryAsync<Profile>(query);

                if (string.IsNullOrEmpty(objProfile.Name))
                {
                    // objProfile.account_num = model.LastOrDefault().PROFILEID.ToString();
                }

                query = "Insert into Profile(PROFILEID,NAME,Email,PHONE,ADDRESS,Portfolio_url) values(" + model.LastOrDefault().PROFILEID + ",'" + objProfile.Name + "','" + objProfile.Email + "','" + objProfile.Phone + "','" + objProfile.Address + "','" + objProfile.Portfolio_url + "' )";

                var updatedRow = await connection.QueryAsync<Profile>(query);
                return updatedRow;

            }
        }
            public async Task<IEnumerable<Profile>> updateProfile(Profile objProfile)
            {


                var query = "update Profile set name='" + objProfile.Name + "', email='" + objProfile.Email + "', phone='" + objProfile.Phone + "', address='" + objProfile.Address + "',Portfolio_url='" + objProfile.Portfolio_url+ "' WHERE PROFILEID=" + objProfile.PROFILEID + "";
                using (var connection = _context.CreateConnection())
                {
                    var updatedRow = await connection.QueryAsync<Profile>(query);
                    return updatedRow.ToList();
                }
            }
        public async Task<IEnumerable<Profile>> deleteProfile(long id)
        {


            var query = "Delete from Profile where profileid="+id;

                  using (var connection = _context.CreateConnection())
            {
                var updatedRow = await connection.QueryAsync<Profile>(query);
                return updatedRow.ToList();
            }
        }
    }
}
