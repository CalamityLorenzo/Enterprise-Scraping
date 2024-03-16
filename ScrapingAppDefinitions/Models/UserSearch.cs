namespace ScrapingAppDefinitions.Models
{
    public record UserSearch(Guid Id, Guid ProfileId, Guid ProviderId, string ProfileName, string ProviderName, string SearchTerms, string Positions, DateTime Time) : BaseAppModel(Id);
}
