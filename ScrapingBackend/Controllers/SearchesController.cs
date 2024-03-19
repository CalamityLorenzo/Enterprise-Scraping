using Microsoft.AspNetCore.Mvc;
using ScrapingAppDefinitions;
using ScrapingAppDefinitions.Models;
using ScrapingAppDefinitions.ResultType;
using ScrapingBackend.Models;

namespace ScrapingBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchesController(ILogger<SearchesController> logger, IDbService dbService, IScrapingService scraper) : ControllerBase
    {

        [HttpGet]
        [Route("{profileId}")]
        public async Task<IActionResult> GetSearchesForProfile(Guid profileId)
        {
            try
            {
                logger.LogInformation($"{nameof(SearchesController)} GetAll");
                var profiles = await dbService.Searches.GetAll(profileId);
                return new OkObjectResult(profiles.Value);
            }

            catch (Exception ex)
            {
                logger.LogCritical($"{nameof(SearchesController)} GetAll", ex);
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] NewUserSearchModel userSearch)
        {
            try
            {

                logger.LogInformation($"{nameof(SearchesController)} Add");

                var completeUserSearch = await scraper.Search(userSearch.ProfileId, userSearch.ProviderId, userSearch.SearchTerms);
                var result = await dbService.Searches.Create(completeUserSearch);
                if (result.IsSuccess)
                    return Ok(result.Value);
                else
                {
                    return StatusCode(500, result.ErrorMessage);
                }
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
                var result = await dbService.Searches.Update(userSearch);
                if (!result.IsSuccess)
                    return StatusCode(500, result.ErrorMessage);
                else
                    return Ok(result.Value);
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
                var result = await dbService.Searches.Delete(providerId.Value);
                // We always blame ourselves with the processing :(
                if (result is ResultError error)
                    return StatusCode(500, error.ErrorMessage);
                else
                    return Ok();
            }
            catch (Exception ex)
            {
                logger.LogCritical($"{nameof(SearchesController)} Delete", ex);
                return StatusCode(500, ex.Message);
            }

        }

    }

}
