using Microsoft.AspNetCore.Mvc;
using ScrapingAppDefinitions;
using ScrapingAppDefinitions.Models;
using ScrapingAppDefinitions.ResultType;
using ScrapingBackend.Models;

namespace ScrapingBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvidersController(ILogger<ProvidersController> logger, IDbService dbService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                logger.LogInformation($"{nameof(ProvidersController)} GetAll");
                var provider = await dbService.Providers.GetAll();
                return new OkObjectResult(provider.Value);
            }

            catch (Exception ex)
            {
                logger.LogCritical($"{nameof(ProvidersController)} GetAll", ex);
                return StatusCode(500, ex.Message);
            }

        }

        [HttpGet]
        [Route("{providerId}")]
        public async Task<IActionResult> Get(Guid providerId)
        {
            try
            {
                logger.LogInformation($"{nameof(ProfilesController)} Get {providerId}");
                var provider = await dbService.Providers.Get(providerId);

                return provider.IsSuccess ?
                    new OkObjectResult(provider.Value)
                    : StatusCode(500, provider.ErrorMessage);


            }
            catch (Exception ex)
            {
                logger.LogCritical($"{nameof(ProfilesController)} Get  {providerId}", ex);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] SearchProvider provider)
        {
            try
            {
                logger.LogInformation($"{nameof(ProvidersController)} Add");
                var newProfile = await dbService.Providers.Create(provider);
                return new OkObjectResult(newProfile.Value);
            }

            catch (Exception ex)
            {
                logger.LogCritical($"{nameof(ProvidersController)} Add", ex);
                return StatusCode(500, ex.Message);
            }

        }
        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] SearchProvider provider)
        {
            try
            {
                logger.LogInformation($"{nameof(ProvidersController)} Update");
                var result = await dbService.Providers.Update(provider);
                if (!result.IsSuccess)
                    return StatusCode(500, result.ErrorMessage);
                else
                    return Ok(result.Value);
            }

            catch (Exception ex)
            {
                logger.LogCritical($"{nameof(ProvidersController)} Update", ex);
                return StatusCode(500, ex.Message);
            }

        }


        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] EntityIdModel providerId)
        {
            try
            {
                logger.LogInformation($"{nameof(ProvidersController)} Delete");
                var result = await dbService.Providers.Delete(providerId.Value);
                if(result is ResultError error)
                    return StatusCode(500, error.ErrorMessage);
                else
                    return Ok();
                
            }
            catch (Exception ex)
            {
                logger.LogCritical($"{nameof(ProvidersController)} Delete", ex);
                return StatusCode(500, ex.Message);
            }

        }

    }

}
