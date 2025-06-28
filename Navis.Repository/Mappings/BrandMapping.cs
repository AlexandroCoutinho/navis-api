using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using Navis.Domain.Entities;

namespace Navis.Repository.Mappings
{
    internal class BrandMapping
    {
        public static void Register()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(Brand)))
            {
                BsonClassMap.RegisterClassMap<Brand>((BsonClassMap<Brand> bsonClassMap) =>
                {
                    bsonClassMap.AutoMap();
                    bsonClassMap.MapIdMember(x => x.Id)
                    .SetIdGenerator(StringObjectIdGenerator.Instance)
                    .SetSerializer(new StringSerializer(BsonType.ObjectId));

                    bsonClassMap.MapMember(x => x.Name).SetIsRequired(true);
                });
            }
        }
    }
}
