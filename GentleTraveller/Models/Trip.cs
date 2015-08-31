using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GentleTraveller.Models
{
    public class Trip
    {
        [BsonElement("_id")]
        public ObjectId Id { get; set; }
        public DateTime Date { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public decimal CarryingCapacity { get; set; }
    }
}