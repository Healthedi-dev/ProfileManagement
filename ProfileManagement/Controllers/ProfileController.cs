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
                var profile = await _iClinic.GetProfile();
                return Ok(profile);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        [Route("saveProfile")]
        public async Task<IActionResult> saveProfile(Profile objProfile)
        {
            try
            {
                var   profile = await _iClinic.saveProfile(objProfile);
                return Ok(profile);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        [Route("updateProfile")]
        public async Task<IActionResult> updateProfile(Profile objProfile)
        {
            try
            {
                var   profile = await _iClinic.updateProfile(objProfile);
                return Ok(profile);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        [Route("deleteProfile")]
        public async Task<IActionResult> deleteProfile(long id)
        {
            try
            {
                var profile = await _iClinic.deleteProfile(id);
                return Ok(profile);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
    }
}
