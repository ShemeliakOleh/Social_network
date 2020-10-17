﻿using System;
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
        [BsonElement("user")]
        public BsonObjectId[] User { get; set; }

        [BsonElement("comments")]
        public string[] Comments { get; set; }

        [BsonElement("postsContent")]
        public string PostsContent { get; set; }
        [BsonElement("likers")]
        public BsonObjectId[] Likers { get; set; }
    }
}
