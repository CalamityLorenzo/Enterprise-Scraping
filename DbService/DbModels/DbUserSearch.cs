using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
namespace DbService.DbModels
{
    internal record DbUserSearch(
        Guid Id,
        Guid ProfileId,
        Guid ProviderId,
        string SearchTerms,
        string Positions,
        DateTime Time,
        DateTime Created,
        DateTime Updated) : DbBaseModel(Id, Created, Updated)
    {
        public virtual DbSearchProvider? SearchProvider { get; set; }
        public virtual DbUserProfile? UserProfile { get; set; }
    }


}
