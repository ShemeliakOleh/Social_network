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
   public class Post
    {
        [BsonIgnoreIfDefault]
        [BsonId]
        [BsonElement("_id")]
        public ObjectId Id { get; set; }
        [BsonElement("user")]
        public BsonObjectId User { get; set; }

        [BsonElement("comments")]
        public List<BsonObjectId> Comments { get; set; }

        [BsonElement("postsContent")]
        public string PostsContent { get; set; }
        [BsonElement("likers")]
        public List<BsonObjectId> Likers { get; set; }
        public Post()
        {
            Id = ObjectId.GenerateNewId();
            User = ObjectId.Empty;
            Comments = new List<BsonObjectId>();
            PostsContent = "";
            Likers = new List<BsonObjectId>();
        }
    }
}
