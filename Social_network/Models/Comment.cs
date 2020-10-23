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
        [BsonElement("user")]
        public BsonObjectId User { get; set; }

        [BsonElement("post")]
        public List<BsonObjectId> Post { get; set; }

        [BsonElement("commentContent")]
        public string CommentContent { get; set; }

        [BsonElement("likers")]
        public List<BsonObjectId> Likers { get; set; }

    }
}
