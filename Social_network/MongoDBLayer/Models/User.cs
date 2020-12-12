using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace Social_network.Models
{
   public class User
    {
        
        [BsonIgnoreIfDefault]
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("firstName")]
        public string FirstName { get; set; }
        [BsonElement("secondName")]
        public string SecondName { get; set; }
        [BsonElement("password")]
        public string Password { get; set; }
        [BsonElement("email")]
        public string Email { get; set; }
        [BsonElement("interests")]
        public List<string> Interests { get; set; }
        [BsonElement("following")]
        public List<BsonObjectId> Following { get; set; }
        [BsonElement("followers")]
        public List<BsonObjectId> Followers { get; set; }
        [BsonElement("posts")]
        public List<BsonObjectId> Posts { get; set; }
        [BsonElement("comments")]
        public List<BsonObjectId> Comments { get; set; }
        public User()
        {
            Id = ObjectId.GenerateNewId();
            FirstName = "";
            SecondName = "";
            Password = "";
            Email = "";
            Interests = new List<string>();
            Following = new List<BsonObjectId>();
            Followers = new List<BsonObjectId>();
            Posts = new List<BsonObjectId>();
            Comments = new List<BsonObjectId>();
        }

    }
}
