using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace TravelerDataProvider
{
    public class MongoDatabase<T> : IDatabase<T> where T : class, new()
    {
        private string _collectionName;
        private string _connectionString;

        private IMongoClient _client;
        private IMongoDatabase _db;

        protected IMongoCollection<T> _collection
        {
            get
            {
                return _db.GetCollection<T>(_collectionName);
            }
            set
            {
                _collection = value;
            }
        }

        public MongoDatabase(string collectionName, string connectionStringName, string dataBaseName)
        {
            _connectionString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
            _client = new MongoClient(_connectionString);
            _collectionName = collectionName;
            _db = _client.GetDatabase(dataBaseName);
        }

        public bool Delete(T item)
        {
            ObjectId id = new ObjectId(typeof(T).GetProperty("Id").GetValue(item, null).ToString());
            var query = Builders<T>.Filter.Eq("_id", id);

            // Remove the object.
            var task = _collection.DeleteOneAsync(query);
            task.Wait();
            return task.Result.DeletedCount == 1;
        }

        public int Delete(Expression<Func<T, bool>> expression)
        {
            var filter = Builders<T>.Filter.Where(expression);
            var task = _collection.DeleteManyAsync(filter);
            return (int)task.Result.DeletedCount;
        }

        public void DeleteAll()
        {
            var task = _db.DropCollectionAsync(typeof(T).Name);
            task.Wait();
        }

        public T Single(Expression<Func<T, bool>> expression)
        {
            var filter = Builders<T>.Filter.Where(expression);
            var task = _collection.Find(filter).FirstOrDefaultAsync();
            task.Wait();
            return task.Result;
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            var filter = Builders<T>.Filter.Where(expression);
            var task = _collection.Find(filter).ToListAsync();
            task.Wait();
            return task.Result.AsQueryable<T>();
        }

        public IQueryable<T> All(Expression<Func<T, bool>> expression, int page, int pageSize)
        {
            var filter = Builders<T>.Filter.Where(expression);
            int pageToSkip = (page - 1) * pageSize;
            var task = _collection.Find(filter).Skip(pageToSkip).Limit(pageSize).ToListAsync();
            task.Wait();
            return task.Result.AsQueryable<T>();
        }

        public void Add(T item)
        {
            var task = _collection.InsertOneAsync(item);
            task.Wait();
        }

        public void Add(IEnumerable<T> items)
        {
            var task = _collection.InsertManyAsync(items, new InsertManyOptions() { IsOrdered = true });
            task.Wait();
        }
    }
}
