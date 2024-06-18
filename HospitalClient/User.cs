using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClient
{
    [Serializable]
    public class User
    {
        [BsonId, BsonElement("_id"), BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        //id
        public string UserID { get; set; }

        [BsonElement("username"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        //username
        public string Username { get; set; }

        [BsonElement("password"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        //password
        public string Password { get; set; }

        [BsonElement("role"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        //role
        public string Role { get; set; }


    }
}
