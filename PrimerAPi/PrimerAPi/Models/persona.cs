using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PrimerAPi.Models
{
    public class persona
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        public string nombre { get; set; }

        public string apellido { get; set; } 
        
        public int edad { get; set; }


    }
}
