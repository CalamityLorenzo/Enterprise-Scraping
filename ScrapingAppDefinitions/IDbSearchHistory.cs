using ScrapingAppDefinitions.Models;
using ScrapingAppDefinitions.ResultType;

namespace ScrapingAppDefinitions
{
    public interface IDbSearchHistory
    {
        IEnumerable<UserSearch> GetAll(Guid profileId);
        Task<Result<UserSearch>> Get(Guid Id);
        Task<Result<UserSearch>> Create(UserSearch provider);
        Task<Result<UserSearch>> Update(UserSearch provider);
        Task<Result> Delete(Guid Id);
    }
}