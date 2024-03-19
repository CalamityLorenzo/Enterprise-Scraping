using ScrapingAppDefinitions.Models;

namespace ScrapingBackend.Models
{
    public record NewUserSearchModel(Guid ProfileId, Guid ProviderId, string SearchTerms);
}
