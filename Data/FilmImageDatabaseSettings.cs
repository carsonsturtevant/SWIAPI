namespace SWIAPI.Data
{
    public class FilmImageDatabaseSettings : IFilmImageDatabaseSettings
    {
        public string FilmImageCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IFilmImageDatabaseSettings
    {
        string FilmImageCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}