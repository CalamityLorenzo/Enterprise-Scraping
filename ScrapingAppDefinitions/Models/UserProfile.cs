namespace ScrapingAppDefinitions.Models
{
    public record UserProfile(Guid Id, DateTime Created, DateTime Updated, string Name) : BaseAppModel(Id)
    {
    }
}
