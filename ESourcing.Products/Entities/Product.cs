using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ESourcing.Products.Entities
{
    public class Product
    {
        [BsonId]//KEY 
        [BsonRepresentation(BsonType.ObjectId)] // +1
        public string Id { get; set; }
        [BsonElement("Adı")]
        public string Name { get; set; }
        public string Category { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
        public decimal Price { get; set; }
    }
}
