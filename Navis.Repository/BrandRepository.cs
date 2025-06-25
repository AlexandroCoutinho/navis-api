using MongoDB.Driver;
using Navis.Domain.Entities;
using Navis.Domain.Repository;

namespace Navis.Repository
{
    public class BrandRepository : IBrandRepository
    {

        public BrandRepository()
        {

        }

        public async Task<Brand> CreateAsync(Brand brand)
        {
            var mongoClient = new MongoClient("mongodb://localhost:27017");
            var mongoDatabase = mongoClient.GetDatabase("Navis");
            var mongoCollection = mongoDatabase.GetCollection<Brand>("Brand");

            await mongoCollection.InsertOneAsync(brand);
            brand = new Brand() { Name = brand.Name, Id = brand.Id };

            return brand;
        }
    }
}
