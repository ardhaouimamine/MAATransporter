using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using System.Configuration;

namespace GentleTraveller.Models
{
    public class TravelerContext
    {
        public const string CONNECTION_STRING_NAME = "mongodb";
        public const string DATABASE_NAME = "gentletravelerdb";
        public const string TRIPS_COLLECTION_NAME = "trips";
        public const string TRAVELERS_COLLECTION_NAME = "travelers";

        // This is ok... Normally, these or the entire TravelerContext
        // would be put into an IoC container. We aren't using one,
        // so we'll just keep them statically here as they are 
        // thread-safe.
        private static readonly IMongoClient _client;
        private static readonly IMongoDatabase _database;

        static TravelerContext()
        {
            var connectionString = ConfigurationManager.ConnectionStrings[CONNECTION_STRING_NAME].ConnectionString;
            _client = new MongoClient(connectionString);
            _database = _client.GetDatabase(DATABASE_NAME);
        }

        public IMongoClient Client
        {
            get { return _client; }
        }

        public IMongoCollection<Trip> Trips
        {
            get { return _database.GetCollection<Trip>(TRIPS_COLLECTION_NAME); }
        }

        public IMongoCollection<Traveler> Travelers
        {
            get { return _database.GetCollection<Traveler>(TRAVELERS_COLLECTION_NAME); }
        }
    }
}