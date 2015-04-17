using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class MongoContext : IContext
    {
        private readonly MongoClient _client;
        private readonly MongoDatabase _db;

        public MongoContext(String connectionString)
        {
            MongoUrlBuilder build = new MongoUrlBuilder(connectionString);

            _client = new MongoClient(build.ToMongoUrl());
            _db = _client.GetServer().GetDatabase(build.DatabaseName);
        }

        public IEnumerable<T> GetTableFor<T>(String collectionName)
        {
            return _db.GetCollection<T>(collectionName).AsQueryable();
        }

        public Boolean Save<T>(String collectionName, T item)
        {
            var coll = _db.GetCollection<T>(collectionName);
            var result = coll.Save(item);
            return result.Ok;
        }

        public Boolean Delete<T, I>(String collectionName, I id)
        {
            var bson = MongoDB.Bson.BsonValue.Create(id);
            var coll = _db.GetCollection<T>(collectionName);
            var item = coll.Find(Query.EQ("_id", bson)).FirstOrDefault();

            var result = coll.Remove(Query.EQ("_id", bson));
            return result.Ok;
        }
    }
}
