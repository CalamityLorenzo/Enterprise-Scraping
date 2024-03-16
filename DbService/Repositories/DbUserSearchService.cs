using DbService.DbModels;
using ScrapingAppDefinitions;
using ScrapingAppDefinitions.Models;

namespace DbService.Repositories
{
    internal class DbUserSearchService : BaseRepository<DbUserSearch, UserSearch>, IDbSearchHistory
    {
        public DbUserSearchService(AppDbContext dbContext, Func<DbUserSearch, UserSearch> convertToModel, Func<UserSearch, DbUserSearch> convertToDb, string reportingName) : base(dbContext, convertToModel, convertToDb, reportingName)
        {
        }

        public IEnumerable<UserSearch> GetAll(Guid profileId) => this._ctx.UserSearches.Where(a=>a.ProfileId ==  profileId).Select(ConvertToModel).ToList();

        internal static UserSearch ConvertToModel(DbUserSearch userSearch) => new UserSearch(userSearch.Id, userSearch.ProfileId, userSearch.ProviderId, userSearch.UserProfile!.Name, userSearch.SearchProvider!.Name, userSearch.SearchTerms, userSearch.Positions, userSearch.Time);
        internal static DbUserSearch ConvertToDb(UserSearch userSearch) => new DbUserSearch(userSearch.Id, userSearch.ProfileId, userSearch.ProviderId, userSearch.SearchTerms, userSearch.Positions, userSearch.Time, DateTime.Now, DateTime.Now);

    }
}
