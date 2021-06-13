using System.ComponentModel.DataAnnotations;
using BooksApi.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BooksApi.Models
{
    public class User: IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
      
        [BsonElement("email")]
        //[EmailAddress]
        public string Email{get;set;}

        [BsonElement("displayName")]
        public string DisplayName{get;set;}
    }
}