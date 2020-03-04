
using MongoDB.Driver;
using Newtonsoft.Json;
using SWIAPI.Data;
using SWIAPI.Models;
using System.Collections.Generic;
using System.IO;

namespace SWIAPI.Services
{
    public class PeopleImageService
    {
        private readonly IMongoCollection<PeopleImage> _peopleImages;

        public PeopleImageService(IPeopleImageDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _peopleImages = database.GetCollection<PeopleImage>(settings.PeopleImageCollectionName);

            if (_peopleImages.Find(peopleImage => true).ToList().Count == 0)
            {
                var data = File.ReadAllText("./Data/Json/peopleimage_collection.json");
                var dataSerialized = JsonConvert.DeserializeObject<List<PeopleImage>>(data);
                _peopleImages.InsertMany(dataSerialized);
            }
        }

        public List<PeopleImage> Get() =>
            _peopleImages.Find(peopleImage => true).ToList();

        public PeopleImage Get(string id) =>
            _peopleImages.Find(peopleImage => peopleImage.Id == id).FirstOrDefault();
    }
}
