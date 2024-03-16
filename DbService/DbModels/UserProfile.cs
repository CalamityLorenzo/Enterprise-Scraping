namespace DbService.DbModels
{
    internal record DbUserProfile(Guid Id, DateTime Created, DateTime Updated, string Name) : DbBaseModel(Id, Created, Updated);
}
