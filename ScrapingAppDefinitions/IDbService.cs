namespace ScrapingAppDefinitions
{
    public interface IDbService
    {
        IDbSearchProvider  Providers  {get;}
        IDbSearchHistory  Searches{get; }
        IDbProfileSelector Profiles { get; }
    }
}
