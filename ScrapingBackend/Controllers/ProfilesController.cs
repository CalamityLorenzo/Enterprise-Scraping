using Microsoft.AspNetCore.Mvc;
using ScrapingAppDefinitions;
using ScrapingAppDefinitions.Models;
using ScrapingAppDefinitions.ResultType;
using ScrapingBackend.Models;

namespace ScrapingBackend.Controllers
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

        [HttpGet]
        [Route("{profileId}")]
        public async Task<IActionResult> Get(Guid profileId)
        {
            try
            {
                logger.LogInformation($"{nameof(ProfilesController)} Get {profileId}");
                var userProfile = await dbService.Profiles.Get(profileId);

                return userProfile.IsSuccess ?
                    new OkObjectResult(userProfile.Value)
                    : StatusCode(500, userProfile.ErrorMessage);


            }
            catch (Exception ex)
            {
                logger.LogCritical($"{nameof(ProfilesController)} Get  {profileId}", ex);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] UserProfile userprofile)
        {
            try
            {
                logger.LogInformation($"{nameof(ProfilesController)} Add");
                var result = await dbService.Profiles.Create(userprofile);
                if (!result.IsSuccess)
                    return StatusCode(500, result.ErrorMessage);
                else
                    return Ok(result.Value);
            }

            catch (Exception ex)
            {
                logger.LogCritical($"{nameof(ProfilesController)} Add", ex);
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] UserProfile userprofile)
        {
            try
            {
                logger.LogInformation($"{nameof(ProfilesController)} Update");
                var result = await dbService.Profiles.Update(userprofile);
                if (!result.IsSuccess)
                    return StatusCode(500, result.ErrorMessage);
                else
                    return Ok(result.Value);
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
                // See Providers controller for pattern match approach
                if (newProfile.IsSuccess)
                    return Ok();
                else
                {
                    return StatusCode(500, ((ResultError)newProfile).ErrorMessage);
                }
            }

            catch (Exception ex)
            {
                logger.LogCritical($"{nameof(ProfilesController)} Delete", ex);
                return StatusCode(500, ex.Message);
            }

        }

    }
}
