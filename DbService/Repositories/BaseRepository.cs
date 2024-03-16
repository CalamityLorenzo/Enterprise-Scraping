using DbService.DbModels;
using Microsoft.EntityFrameworkCore;
using ScrapingAppDefinitions.Models;
using ScrapingAppDefinitions.ResultType;

namespace DbService.Repositories
{
    internal class BaseRepository<DbModel, AppModel>
                                      where DbModel : DbBaseModel
                                      where AppModel : BaseAppModel
    {
        internal AppDbContext _ctx;
        internal string ReportingName { get; }

        private Func<DbModel, AppModel> ConvertToModel;

        private Func<AppModel, DbModel> ConvertToDb;

        public BaseRepository(AppDbContext ctx, Func<DbModel, AppModel> convertToModel, Func<AppModel, DbModel> convertToDb, string reportingName)
        {
            _ctx = ctx;
            ConvertToDb = convertToDb;
            ConvertToModel = convertToModel;
            ReportingName = reportingName;
        }

        public virtual async Task<Result<AppModel>> Get(Guid Id)
        {
            if (Id == Guid.Empty)
            {
                return new Result<AppModel>("Id must be complete");
            }
            try
            {
                var result = await _ctx.Set<DbModel>().FindAsync(Id);
                if (result == null)
                {
                    return new Result<AppModel>("No Search provider found");
                }

                return new Result<AppModel>(ConvertToModel(result));

            }
            catch (Exception ex)
            {
                return new Result<AppModel>($"Get {nameof(ReportingName)} : {Id} failed \n{ex.Message}");
            }
        }

        public virtual async Task<Result<AppModel>> Create(AppModel provider)
        {
            if (provider.Id != Guid.Empty)
            {
                return new Result<AppModel>($"Create {nameof(ReportingName)} already exists");
            }
            else
            {
                try
                {
                    DbModel dbProvider = ConvertToDb(provider);
                    var addedProvider = await this._ctx.Set<DbModel>().AddAsync(dbProvider);
                    await this._ctx.SaveChangesAsync();
                    return new Result<AppModel>(ConvertToModel(addedProvider.Entity));
                }
                catch (Exception ex)
                {
                    return new Result<AppModel>($"Create {nameof(ReportingName)} : {provider.Id} failed \n{ex.Message}");
                }
            }
        }

        public virtual async Task<Result> Delete(Guid Id)
        {
            if (Id == Guid.Empty) return new ResultError($"Delete {nameof(ReportingName)} : Id cannot be empty");
            try
            {
                await _ctx.Set<DbModel>().Where(x => x.Id == Id).ExecuteDeleteAsync();
                return new ResultSuccess();
            }
            catch (Exception ex)
            {
                return new ResultError($"Delete Provider : {Id} failed \n{ex.Message}");
            }
        }

        public virtual async Task<Result<AppModel>> Update(AppModel provider)
        {
            if (provider.Id == Guid.Empty) return new Result<AppModel>("Update Provider : Id cannot be empty");
            try
            {



                var dbProvider = ConvertToDb(provider);
                var dbEnt = _ctx.Set<DbModel>().Update(dbProvider);
                await _ctx.SaveChangesAsync();
                var dbData = _ctx.Set<DbModel>().Where(a => a.Id == provider.Id).AsNoTracking().First();

                return new Result<AppModel>(ConvertToModel(dbData));

            }
            catch (Exception ex)
            {
                return new Result<AppModel>($"Update Provider : {provider.Id} failed \n{ex.Message}");
            }
        }


    }
}


