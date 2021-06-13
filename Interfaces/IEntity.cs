using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BooksApi.Interfaces
{
    public interface IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        string Id { get; set; }
    }

    public interface IEntity<TType> where TType: struct
    {
        [BsonId]
        TType Id { get; set; }
    }
}