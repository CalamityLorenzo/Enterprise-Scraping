using Microsoft.AspNetCore.Mvc;
using ScrapingAppDefinitions;
using ScrapingAppDefinitions.Models;
using ScrapingBackend.Models;

namespace ScrapingBackend
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfilesController(ILogger<ProfilesController> logger, IDbService dbService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                logger.LogInformation($"{nameof(ProfilesController)} GetAll");
                var profiles = dbService.Profiles.GetAll();
                return new OkObjectResult(profiles);
            }

            catch (Exception ex)
            {
                logger.LogCritical($"{nameof(ProfilesController)} GetAll", ex);
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] UserProfile userprofile)
        {
            try
            {
                logger.LogInformation($"{nameof(ProfilesController)} Add");
                var newProfile = await dbService.Profiles.Create(userprofile);
                return new OkObjectResult(newProfile);
            }

            catch (Exception ex)
            {
                logger.LogCritical($"{nameof(ProfilesController)} Add", ex);
                return StatusCode(500, ex.Message);
            }

        }
        [HttpPost("/update")]
        public async Task<IActionResult> Update([FromBody] UserProfile userprofile)
        {
            try
            {
                logger.LogInformation($"{nameof(ProfilesController)} Update");
                var newProfile = await dbService.Profiles.Update(userprofile);
                return new OkObjectResult(newProfile);
            }

            catch (Exception ex)
            {
                logger.LogCritical($"{nameof(ProfilesController)} Update", ex);
                return StatusCode(500, ex.Message);
            }

        }


        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] EntityIdModel profileId)
        {
            try
            {
                logger.LogInformation($"{nameof(ProfilesController)} Delete");
                var newProfile = await dbService.Profiles.Delete(profileId.Value);
                return new OkObjectResult(newProfile);
            }

            catch (Exception ex)
            {
                logger.LogCritical($"{nameof(ProfilesController)} Delete", ex);
                return StatusCode(500, ex.Message);
            }

        }

    }
}
