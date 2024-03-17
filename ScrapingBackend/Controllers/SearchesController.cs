using Microsoft.AspNetCore.Mvc;
using ScrapingAppDefinitions;
using ScrapingAppDefinitions.Models;
using ScrapingBackend.Models;

namespace ScrapingBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchesController(ILogger<SearchesController> logger, IDbService dbService) : ControllerBase
    {
        [HttpGet]
        [Route("{profileId}")]
        public async Task<IActionResult> GetSearchesForProfile(Guid profileId)
        {
            try
            {
                logger.LogInformation($"{nameof(SearchesController)} GetAll");
                var profiles = dbService.Searches.GetAll(profileId);
                return new OkObjectResult(profiles);
            }

            catch (Exception ex)
            {
                logger.LogCritical($"{nameof(SearchesController)} GetAll", ex);
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] UserSearch userSearch)
        {
            try
            {
                logger.LogInformation($"{nameof(SearchesController)} Add");
                var newProfile = await dbService.Searches.Create(userSearch);
                return new OkObjectResult(newProfile);
            }

            catch (Exception ex)
            {
                logger.LogCritical($"{nameof(SearchesController)} Add", ex);
                return StatusCode(500, ex.Message);
            }

        }
        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] UserSearch userSearch)
        {
            try
            {
                logger.LogInformation($"{nameof(SearchesController)} Update");
                var newProfile = await dbService.Searches.Update(userSearch);
                return new OkObjectResult(newProfile);
            }

            catch (Exception ex)
            {
                logger.LogCritical($"{nameof(SearchesController)} Update", ex);
                return StatusCode(500, ex.Message);
            }

        }


        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] EntityIdModel providerId)
        {
            try
            {
                logger.LogInformation($"{nameof(SearchesController)} Delete");
                var newProfile = await dbService.Searches.Delete(providerId.Value);
                return new OkObjectResult(newProfile);
            }
            catch (Exception ex)
            {
                logger.LogCritical($"{nameof(SearchesController)} Delete", ex);
                return StatusCode(500, ex.Message);
            }

        }

    }

}
