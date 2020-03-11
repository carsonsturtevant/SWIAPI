using MongoDB.Driver;
using Newtonsoft.Json;
using SWIAPI.Data;
using SWIAPI.Models;
using System.Collections.Generic;
using System.IO;

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

            if (_filmImages.Find(filmImage => true).ToList().Count == 0)
            {
                var data = File.ReadAllText("./Data/Json/filmimage_collection.json");
                var dataSerialized = JsonConvert.DeserializeObject<List<FilmImage>>(data);
                _filmImages.InsertMany(dataSerialized);
            }
        }

        public List<FilmImage> Get() =>
            _filmImages.Find(filmImage => true).ToList();

        public FilmImage Get(string id) =>
            _filmImages.Find(filmImage => filmImage.Id == id).FirstOrDefault();
    }
}
