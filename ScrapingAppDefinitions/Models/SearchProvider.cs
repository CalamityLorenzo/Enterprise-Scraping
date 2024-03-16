namespace ScrapingAppDefinitions.Models
{
    public record SearchProvider(Guid Id, string Name, string Base64Image, string BaseUrl ): BaseAppModel(Id);
}