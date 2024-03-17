using DbService.DbModels;
using ScrapingAppDefinitions;
using ScrapingAppDefinitions.Models;
using ScrapingAppDefinitions.ResultType;

namespace DbService.Repositories
{
    internal class DbUserSearchService : BaseRepository<DbUserSearch, UserSearch>, IDbSearchHistory
    {
        public DbUserSearchService(AppDbContext dbContext, Func<DbUserSearch, UserSearch> convertToModel, Func<UserSearch, DbUserSearch> convertToDb, string reportingName) : base(dbContext, convertToModel, convertToDb, reportingName)
        {
        }

        public async Task<Result<IEnumerable<UserSearch>>> GetAll(Guid profileId)
        {
            try
            {
                var profiles = this._ctx.UserSearches.Where(a => a.ProfileId == profileId).ToList();
                return new Result<IEnumerable<UserSearch>>(profiles.Select(ConvertToModel).ToList());
            }
            catch (Exception ex)
            {
                return new Result<IEnumerable<UserSearch>>($"Create {nameof(ReportingName)} : {profileId} failed \n{ex.Message}");
            }
        }

        internal static UserSearch ConvertToModel(DbUserSearch userSearch) => new UserSearch(userSearch.Id, userSearch.ProfileId, userSearch.ProviderId, userSearch.UserProfile!.Name, userSearch.SearchProvider!.Name, userSearch.SearchTerms, userSearch.Positions, userSearch.Time);
        internal static DbUserSearch ConvertToDb(UserSearch userSearch) => new DbUserSearch(userSearch.Id, userSearch.ProfileId, userSearch.ProviderId, userSearch.SearchTerms, userSearch.Positions, userSearch.Time, DateTime.Now, DateTime.Now);

    }
}
