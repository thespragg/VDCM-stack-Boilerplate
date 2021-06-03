using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace server.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Username")]
        public string Username { get; set; }

        [BsonElement("Hash")]
        public byte[] Hash { get; set; }

        [BsonElement("Salt")]
        public byte[] Salt { get; set; }

        [BsonElement("LastLoggedIn")]
        public BsonDateTime LastLoggedIn { get; set; }

        [BsonElement("IncorrectAttempts")]
        public int IncorrectAttempts { get; set; }

        [BsonElement("LoginIp")]
        public int LoginIp { get; set; }

        [BsonElement("Email")]
        public string Email { get; set; }

        [BsonElement("Created")]
        public BsonDateTime Created { get; set; }
    }
}
