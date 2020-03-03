using MongoDB.Driver;
using SWIAPI.Data;
using SWIAPI.Models;
using System.Collections.Generic;

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
        }

        public List<PeopleImage> Get() =>
            _peopleImages.Find(peopleImage => true).ToList();

        public PeopleImage Get(string id) =>
            _peopleImages.Find(peopleImage => peopleImage.Id == id).FirstOrDefault();
    }
}
