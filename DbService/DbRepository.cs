using DbService.Repositories;
using Microsoft.Extensions.Logging;
using ScrapingAppDefinitions;

namespace DbService
{
    public class DbRepository : IDbService
    {
        private ILogger<DbRepository> logger;
        private AppDbContext dbContext;

        public DbRepository(AppDbContext dbContext, ILogger<DbRepository> logger)
        {
            this.dbContext= dbContext;
            // These probably should be removed  at the end of the lifetime of the context.
            this.dbContext.SavedChanges += DbContext_SavedChanges;
            this.dbContext.SaveChangesFailed += DbContext_SaveChangesFailed;
            this.logger = logger;
        }
        /// <summary>
        /// These could have also been interceptors
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DbContext_SaveChangesFailed(object? sender, Microsoft.EntityFrameworkCore.SaveChangesFailedEventArgs e)
        {
            logger.LogCritical($"Saving Changes failed : {e.Exception.Message}", e.Exception);
        }

        private void DbContext_SavedChanges(object? sender, Microsoft.EntityFrameworkCore.SavedChangesEventArgs e)
        {
            logger.LogInformation($"Save Changes complete : {e.EntitiesSavedCount}");
        }

        public IDbSearchProvider Providers => new DBSearchProviderService(dbContext, DBSearchProviderService.ConvertToModel, DBSearchProviderService.ConvertToDb, nameof(DBSearchProviderService));

        public IDbSearchHistory Searches => new DbUserSearchService(dbContext, DbUserSearchService.ConvertToModel, DbUserSearchService.ConvertToDb, nameof(DbUserSearchService));

        public IDbProfileSelector Profiles => new DbUserProfileService(dbContext, DbUserProfileService.ConvertToModel, DbUserProfileService.ConvertToDb, nameof(DbUserSearchService));
    }
}
