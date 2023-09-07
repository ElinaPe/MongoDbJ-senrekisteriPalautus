using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoDbJäsenrekisteri.Models
{
    public class Jasen
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("etunimi")]
        public string Etunimi { get; set; } = String.Empty;

        [BsonElement("sukunimi")]
        public string Sukunimi { get; set; } = String.Empty;

        [BsonElement("osoite")]
        public string Osoite { get; set; } = String.Empty;

        [BsonElement("postinumero")]
        public int Postinumero { get; set; }

        [BsonElement("puhelin")]
        public string Puhelin { get; set; } = String.Empty;

        [BsonElement("email")]
        public string Email { get; set; } = String.Empty;

        [BsonElement("jasenyydenAlkuPvm")]
        public string JasenyydenAlkuPvm { get; set; } = String.Empty;
    }
}
