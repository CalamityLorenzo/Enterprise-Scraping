using DbService;
using Microsoft.EntityFrameworkCore;
using ScrapingAppDefinitions.Models;

namespace BackEndTesting
{
    [TestClass]
    public class SearchProvidersTest
    {
        AppDbContext getDbContext()
        {
            var dbOpt = new DbContextOptionsBuilder<AppDbContext>();
            dbOpt.UseSqlServer("Data Source=.\\SQLEXPRESS;User ID=sa;Password=12Fingers34;Encrypt=False;Database=DbScraping");
            return new AppDbContext(dbOpt.Options);
        }

        [TestMethod]
        public async Task Add()
        {

            SearchProvider searchProvider= new SearchProvider(Guid.Empty,"TestUrl", "BASE64:String", "https://searchUrl");
            var dbService = new DbRepository(getDbContext(), new MockLogger<DbRepository>());
            var result = await dbService.Providers.Create(searchProvider);
            Assert.IsTrue(result.IsSuccess);
            Assert.IsTrue(result.Value!.Id != Guid.Empty);
        }


        [TestMethod]
        public async Task Update()
        {
            SearchProvider SearchProvider = new SearchProvider(Guid.Empty, "TestUrl", "BASE64:String", "https://searchUrl");
            var ctx = getDbContext();
            var dbService = new DbRepository(ctx, new MockLogger<DbRepository>());
            var result = await dbService.Providers.Create(SearchProvider);

            Assert.IsTrue(result.IsSuccess);
            Assert.IsTrue(result.Value!.Id != Guid.Empty);
            ctx.ChangeTracker.Clear();
            await ctx.DisposeAsync();
            var ctx2 = getDbContext();
            var dbService2 = new DbRepository(ctx2, new MockLogger<DbRepository>());
            var result2 = await dbService2.Providers.Update(result.Value with { Base64Image = "BaseImage" });

            Assert.IsTrue(result2.IsSuccess);
            Assert.IsTrue(result2.Value!.Id != Guid.Empty);
            Assert.IsTrue(result2.Value!.Base64Image == "BaseImage");

        }

        [TestMethod]
        public async Task Delete()
        {
            SearchProvider SearchProvider = new SearchProvider(Guid.Empty, "TestUrl", "BASE64:String", "https://searchUrl");
            var ctx = getDbContext();
            var dbService = new DbRepository(ctx, new MockLogger<DbRepository>());
            var result = await dbService.Providers.Create(SearchProvider);

            Assert.IsTrue(result.IsSuccess);
            Assert.IsTrue(result.Value!.Id != Guid.Empty);
            ctx.Dispose();
            var ctx2 = getDbContext();

            var dbService2 = new DbRepository(ctx2, new MockLogger<DbRepository>());
            var result2 = await dbService2.Providers.Delete(result.Value.Id);
            Assert.IsTrue(result2.IsSuccess);


        }
    }
}
