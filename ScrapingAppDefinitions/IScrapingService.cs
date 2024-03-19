using ScrapingAppDefinitions.Models;

namespace ScrapingAppDefinitions
{
    public interface IScrapingService
    {
        Task<UserSearch> Search(Guid ProfileId, Guid ProviderId, String searchTerms);
    }
}
