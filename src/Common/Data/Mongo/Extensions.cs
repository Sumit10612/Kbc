using Common.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

namespace Common.Data.Mongo;

public static class Extensions
{
    public static IServiceCollection AddMongoDatabase(this IServiceCollection services)
    {
        BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));
        BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(BsonType.String));

        services.AddSingleton(sp =>
        {
            var configuration = sp.GetService<IConfiguration>();
            var mongoClient = new MongoClient(configuration.GetConnectionString("Mongo"));
            return mongoClient.GetDatabase(configuration["ServiceName"]);
        });

        return services;
    }


    public static IServiceCollection AddMongoRepository<T>(this IServiceCollection services,
        string collectionName = null) where T : IEntity
    {
        services.AddSingleton<IRepository<T>>(sp =>
        {
            var db = sp.GetService<IMongoDatabase>();
            return new MongoRepository<T>(db, collectionName);
        });

        return services;
    }
}
