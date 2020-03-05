namespace SWIAPI.Data
{
    public class PeopleImageDatabaseSettings : IPeopleImageDatabaseSettings
    {
        public string PeopleImageCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IPeopleImageDatabaseSettings
    {
        string PeopleImageCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}