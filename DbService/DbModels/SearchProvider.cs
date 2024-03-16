namespace DbService.DbModels
{
    internal record DbSearchProvider(Guid Id,
        string Name,
        string Base64Image,
        string BaseUrl,
        DateTime Created,
        DateTime Updated) : DbBaseModel(Id, Created, Updated);
}