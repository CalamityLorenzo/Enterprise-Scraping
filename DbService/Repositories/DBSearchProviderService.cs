using DbService.DbModels;
using Microsoft.EntityFrameworkCore;
using ScrapingAppDefinitions;
using ScrapingAppDefinitions.Models;
using ScrapingAppDefinitions.ResultType;

namespace DbService.Repositories
{
    internal class DBSearchProviderService : BaseRepository<DbSearchProvider, SearchProvider>, IDbSearchProvider
    {
        public DBSearchProviderService(AppDbContext dbContext, Func<DbSearchProvider, SearchProvider> convertToModel, Func<SearchProvider, DbSearchProvider> convertToDb, string reportingName) : base(dbContext, convertToModel, convertToDb, reportingName)
        {
        }
        public async Task<Result<IEnumerable<SearchProvider>>> GetAll()
        {
            try
            {
                var providers = await this._ctx.SearchProviders.ToListAsync();
                return new Result<IEnumerable<SearchProvider>>(providers.Select(ConvertToModel).ToList());
            }
            catch (Exception ex)
            {
                return new Result<IEnumerable<SearchProvider>>($"GetAll {nameof(ReportingName)} : failed \n{ex.Message}");
            }
        }


        internal static SearchProvider ConvertToModel(DbSearchProvider dbProvider) => new SearchProvider(dbProvider.Id, dbProvider.Name, dbProvider.Base64Image, dbProvider.BaseUrl);
        internal static DbSearchProvider ConvertToDb(SearchProvider provider)
        {
            return new DbSearchProvider(provider.Id, provider.Name, provider.Base64Image, provider.BaseUrl, DateTime.Now, DateTime.Now);
        }
    }
}
