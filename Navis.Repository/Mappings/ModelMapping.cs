using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using Navis.Domain.Entities;

namespace Navis.Repository.Mappings
{
    internal class ModelMapping
    {
        public static void Register()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(Model)))
            {
                BsonClassMap.RegisterClassMap<Model>((BsonClassMap<Model> bsonClassMap) =>
                {
                    bsonClassMap.AutoMap();

                    bsonClassMap.MapIdMember(x => x.Id)
                    .SetIdGenerator(StringObjectIdGenerator.Instance)
                    .SetSerializer(new StringSerializer(BsonType.ObjectId));

                    bsonClassMap.MapMember(x => x.Name).SetIsRequired(true);

                    bsonClassMap.MapMember(x => x.IsDeleted).SetIsRequired(true).SetDefaultValue(false);
                });
            }
        }
    }
}
