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
   public class Comment
    {
        [BsonIgnoreIfDefault]
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("user")]
        public BsonObjectId User { get; set; }

        [BsonElement("post")]
        public BsonObjectId Post { get; set; }

        [BsonElement("commentContent")]
        public string CommentContent { get; set; }

        [BsonElement("likers")]
        public List<BsonObjectId> Likers { get; set; }
        public Comment()
        {
            Id = ObjectId.GenerateNewId();
            User = ObjectId.Empty;
            Post = ObjectId.Empty;
            CommentContent = "";
            Likers = new List<BsonObjectId>();
        }

    }
}
