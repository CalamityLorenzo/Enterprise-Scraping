using Microsoft.AspNetCore.Mvc;
using ScrapingAppDefinitions;
using ScrapingAppDefinitions.Models;
using ScrapingBackend.Models;

namespace ScrapingBackend
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
                var profiles = dbService.Providers.GetAll();
                return new OkObjectResult(profiles);
            }

            catch (Exception ex)
            {
                logger.LogCritical($"{nameof(ProvidersController)} GetAll", ex);
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
                return new OkObjectResult(newProfile);
            }

            catch (Exception ex)
            {
                logger.LogCritical($"{nameof(ProvidersController)} Add", ex);
                return StatusCode(500, ex.Message);
            }

        }
        [HttpPost("/update")]
        public async Task<IActionResult> Update([FromBody] SearchProvider provider)
        {
            try
            {
                logger.LogInformation($"{nameof(ProvidersController)} Update");
                var newProfile = await dbService.Providers.Update(provider);
                return new OkObjectResult(newProfile);
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
                var newProfile = await dbService.Providers.Delete(providerId.Value);
                return new OkObjectResult(newProfile);
            }
            catch (Exception ex)
            {
                logger.LogCritical($"{nameof(ProvidersController)} Delete", ex);
                return StatusCode(500, ex.Message);
            }

        }

    }

}
