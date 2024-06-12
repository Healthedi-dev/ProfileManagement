using ProfileManagement.Contracts;
using Microsoft.AspNetCore.Mvc;
using ProfileManagement.Model;

namespace ProfileManagement.Controllers
{
    [Route("api/clinic")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        public readonly IProfileRepository _iClinic;

        public ProfileController(IProfileRepository PatientRepo)
        {
            _iClinic = PatientRepo;

        }
      
       
        [HttpGet]
        [Route("getProfile")]
        public async Task<IActionResult> getProfile()
        {
            try
            {
                var companies = await _iClinic.GetProfile();
                return Ok(companies);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
    
}
}
