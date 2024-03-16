using ScrapingAppDefinitions.Models;
using ScrapingAppDefinitions.ResultType;

namespace ScrapingAppDefinitions
{
    public interface IDbProfileSelector
    {
        IEnumerable<UserProfile> GetAll();
        Task<Result<UserProfile>> Get(Guid Id);
        Task<Result<UserProfile>> Create(UserProfile provider);
        Task<Result<UserProfile>> Update(UserProfile provider);
        Task<Result> Delete(Guid Id);
    }
}