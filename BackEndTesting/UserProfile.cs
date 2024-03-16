using DbService;
using Microsoft.EntityFrameworkCore;
using ScrapingAppDefinitions.Models;

namespace BackEndTesting
{
    [TestClass]
    public class UserProfileTests
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

            UserProfile userProfile = new UserProfile(Guid.Empty, DateTime.Now, DateTime.Now, "Francis");
            var dbService = new DbRepository(getDbContext(), new MockLogger<DbRepository>());
            var result = await dbService.Profiles.Create(userProfile);
            Assert.IsTrue(result.IsSuccess);
            Assert.IsTrue(result.Value!.Id != Guid.Empty);
        }


        [TestMethod]
        public async Task Update()
        {
            UserProfile userProfile = new UserProfile(Guid.Empty, DateTime.Now, DateTime.Now, "Francis");
            var ctx = getDbContext();
            var dbService = new DbRepository(ctx, new MockLogger<DbRepository>());
            var result = await dbService.Profiles.Create(userProfile);

            Assert.IsTrue(result.IsSuccess);
            Assert.IsTrue(result.Value!.Id != Guid.Empty);
            ctx.ChangeTracker.Clear();
            await ctx.DisposeAsync();
            var ctx2 = getDbContext();
            var dbService2 = new DbRepository(ctx2, new MockLogger<DbRepository>());
            var result2 = await dbService2.Profiles.Update(result.Value with { Name = "Cleance" });

            Assert.IsTrue(result2.IsSuccess);
            Assert.IsTrue(result2.Value!.Id != Guid.Empty);
            Assert.IsTrue(result2.Value.Name == "Cleance");

        }

        [TestMethod]
        public async Task Delete()
        {
            UserProfile userProfile = new UserProfile(Guid.Empty, DateTime.Now, DateTime.Now, "Francis");
            var ctx = getDbContext();
            var dbService = new DbRepository(ctx, new MockLogger<DbRepository>());
            var result = await dbService.Profiles.Create(userProfile);

            Assert.IsTrue(result.IsSuccess);
            Assert.IsTrue(result.Value!.Id != Guid.Empty);
            ctx.Dispose();
            var ctx2 = getDbContext();

            var dbService2 = new DbRepository(ctx2, new MockLogger<DbRepository>());
            var result2 = await dbService2.Profiles.Delete(result.Value.Id);
            Assert.IsTrue(result2.IsSuccess);


        }
    }
}