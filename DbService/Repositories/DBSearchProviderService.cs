using DbService.DbModels;
using ScrapingAppDefinitions;
using ScrapingAppDefinitions.Models;

namespace DbService.Repositories
{
    internal class DBSearchProviderService : BaseRepository<DbSearchProvider, SearchProvider>, IDbSearchProvider
    {
        public DBSearchProviderService(AppDbContext dbContext, Func<DbSearchProvider, SearchProvider> convertToModel, Func<SearchProvider, DbSearchProvider> convertToDb, string reportingName) : base(dbContext, convertToModel, convertToDb, reportingName)
        {
        }
        public IEnumerable<SearchProvider> GetAll() => this._ctx.SearchProviders.Select(ConvertToModel).ToList();


        internal static SearchProvider ConvertToModel(DbSearchProvider dbProvider) => new SearchProvider(dbProvider.Id, dbProvider.Name, dbProvider.Base64Image, dbProvider.BaseUrl);
        internal static DbSearchProvider ConvertToDb(SearchProvider provider)
        {
            return new DbSearchProvider(provider.Id, provider.Name, provider.Base64Image, provider.BaseUrl, DateTime.Now, DateTime.Now);
        }
    }
}
