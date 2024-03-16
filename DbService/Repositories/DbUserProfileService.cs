using DbService.DbModels;
using ScrapingAppDefinitions;
using ScrapingAppDefinitions.Models;

namespace DbService.Repositories
{
    internal class DbUserProfileService : BaseRepository<DbUserProfile, UserProfile>, IDbProfileSelector
    {
        public DbUserProfileService(AppDbContext ctx, Func<DbUserProfile, UserProfile> convertToModel, Func<UserProfile, DbUserProfile> convertToDb, string reportingName) : base(ctx, convertToModel, convertToDb, reportingName)
        {
        }

        public IEnumerable<UserProfile> GetAll()=> this._ctx.UserProfiles.Select(ConvertToModel).ToList();

        internal static UserProfile ConvertToModel(DbUserProfile dbUserProfile) => new UserProfile(dbUserProfile.Id, dbUserProfile.Created, dbUserProfile.Updated, dbUserProfile.Name);
        internal static DbUserProfile ConvertToDb(UserProfile userProfile) => new DbUserProfile(userProfile.Id, userProfile.Created, userProfile.Updated, userProfile.Name);
    }
}