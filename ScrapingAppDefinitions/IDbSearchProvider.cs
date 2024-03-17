using ScrapingAppDefinitions.Models;
using ScrapingAppDefinitions.ResultType;

namespace ScrapingAppDefinitions
{
    public interface IDbSearchProvider
    {
        Task<Result<IEnumerable<SearchProvider>>> GetAll();
        Task<Result<SearchProvider>> Get(Guid providerId);
        Task<Result<SearchProvider>> Create(SearchProvider provider);
        Task<Result<SearchProvider>> Update(SearchProvider provider);
        Task<Result> Delete(Guid Id);
    }
}