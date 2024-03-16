using DbService;
using Microsoft.EntityFrameworkCore;
using ScrapingAppDefinitions.Models;

namespace BackEndTesting
{
    [TestClass]
    public class UserSearchTests
    {
        AppDbContext getDbContext()
        {
            var dbOpt = new DbContextOptionsBuilder<AppDbContext>();
            dbOpt.UseLazyLoadingProxies().UseSqlServer("Data Source=.\\SQLEXPRESS;User ID=sa;Password=12Fingers34;Encrypt=False;Database=DbScraping");
            return new AppDbContext(dbOpt.Options);
        }

        [TestMethod]
        public async Task Add()
        {
            var dbService = new DbRepository(getDbContext(), new MockLogger<DbRepository>());

            SearchProvider searchProvider = new SearchProvider(Guid.Empty, "TestUrl", "BASE64:String", "https://searchUrl");
            UserProfile userProfile = new UserProfile(Guid.Empty, DateTime.Now, DateTime.Now, "Francis");
            var provider = await dbService.Providers.Create(searchProvider);
            var user = await dbService.Profiles.Create(userProfile);

            UserSearch userSearch = new UserSearch(Guid.Empty,user.Value!.Id, provider.Value!.Id, user.Value.Name, provider.Value.Name, "Largely over the top",  "1,11,40", DateTime.Now);
            var result = await dbService.Searches.Create(userSearch);
            Assert.IsTrue(result.IsSuccess);
            Assert.IsTrue(result.Value!.Id != Guid.Empty);
            Assert.IsTrue(result.Value!.ProfileId == user.Value.Id);
            Assert.IsTrue(result.Value!.ProviderId == provider.Value.Id);
        }


        [TestMethod]
        public async Task Update()
        {
            var dbService = new DbRepository(getDbContext(), new MockLogger<DbRepository>());

            SearchProvider searchProvider = new SearchProvider(Guid.Empty, "TestUrl", "BASE64:String", "https://searchUrl");
            UserProfile userProfile = new UserProfile(Guid.Empty, DateTime.Now, DateTime.Now, "Francis");
            var provider = await dbService.Providers.Create(searchProvider);
            var user = await dbService.Profiles.Create(userProfile);

            UserSearch userSearch = new UserSearch(Guid.Empty, user.Value!.Id, provider.Value!.Id, user.Value!.Name, provider.Value!.Name, "Largely over the top", "1,11,40", DateTime.Now);
            var result = await dbService.Searches.Create(userSearch);
            var ctx2 = getDbContext();
            var dbService2 = new DbRepository(ctx2, new MockLogger<DbRepository>());
            var result2 = await dbService2.Searches.Update(result.Value! with { SearchTerms = "SearchTerms" });

            Assert.IsTrue(result2.IsSuccess);
            Assert.IsTrue(result2.Value!.Id != Guid.Empty);
            Assert.IsTrue(result2.Value.SearchTerms == "SearchTerms");
            Assert.IsTrue(result2.Value.ProfileId == user.Value.Id);
            Assert.IsTrue(result2.Value.ProviderId == provider.Value.Id);
            Assert.IsTrue(result2.Value.ProfileName == user.Value.Name);
            Assert.IsTrue(result2.Value.ProviderName == provider.Value.Name);
        }

        [TestMethod]
        public async Task Delete()
        {
            var dbService = new DbRepository(getDbContext(), new MockLogger<DbRepository>());

            SearchProvider searchProvider = new SearchProvider(Guid.Empty, "TestUrl", "BASE64:String", "https://searchUrl");
            UserProfile userProfile = new UserProfile(Guid.Empty, DateTime.Now, DateTime.Now, "Francis");
            var provider = await dbService.Providers.Create(searchProvider);
            var user = await dbService.Profiles.Create(userProfile);

            UserSearch userSearch = new UserSearch(Guid.Empty, user.Value!.Id, provider.Value!.Id, user.Value!.Name, provider.Value!.Name,  "Largely over the top", "1,11,40", DateTime.Now);
            var result = await dbService.Searches.Create(userSearch);

            Assert.IsTrue(result.IsSuccess);
            Assert.IsTrue(result.Value!.Id != Guid.Empty);

            var result2 = await dbService.Searches.Delete(result.Value.Id);
            Assert.IsTrue(result2.IsSuccess);
        }
    }
}
