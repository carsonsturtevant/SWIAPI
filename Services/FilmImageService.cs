using MongoDB.Driver;
using SWIAPI.Data;
using SWIAPI.Models;
using System.Collections.Generic;

namespace SWIAPI.Services
{
    public class FilmImageService
    {
        private readonly IMongoCollection<FilmImage> _filmImages;

        public FilmImageService(IFilmImageDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _filmImages = database.GetCollection<FilmImage>(settings.FilmImageCollectionName);
        }

        public List<FilmImage> Get() =>
            _filmImages.Find(filmImage => true).ToList();

        public FilmImage Get(string id) =>
            _filmImages.Find(filmImage => filmImage.Id == id).FirstOrDefault();
    }
}
