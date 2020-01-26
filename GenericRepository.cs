using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace StudentMongoDB
{
    public class GenericRepository<T>: IGenericRepository<T> where T: class
    {
        private IMongoCollection<T> _collection;
        private IMongoClient _client;
        private IMongoDatabase _database;
        public GenericRepository()
        {
            _client = new MongoClient();
            _database = _client.GetDatabase("testDB");
            
            // _collection = database.GetCollection<T>(collectionName);
        }


        public IEnumerable<T> GetAll()
        {
            string tableName = typeof(T).Name;
            _collection = _database.GetCollection<T>(tableName + "s");
            var all = _collection.Find(new BsonDocument());
            return all.ToEnumerable();
        }
        public T GetById(string id)
        {
            string tableName = typeof(T).Name;
            _collection = _database.GetCollection<T>(tableName + "s");
            var filter = Builders<T>.Filter.Eq("Id", id);
            return  _collection.Find(filter).FirstOrDefault();
        }

        public T Insert(T record)
        {
            string tableName = typeof(T).Name;
            _collection = _database.GetCollection<T>(tableName + "s");
            _collection.InsertOne(record);
            return record;
        }

        public T Delete(string id)
        {
            string tableName = typeof(T).Name;
            _collection = _database.GetCollection<T>(tableName + "s");
            var filter = Builders<T>.Filter.Eq("Id", id);
            var record = _collection.FindOneAndDelete(filter);
            return record;
        }

        public T Update(T record, string id)
        {
            string tableName = typeof(T).Name;
            _collection = _database.GetCollection<T>(tableName + "s");
            var filter = Builders<T>.Filter.Eq("Id", id);
            var updated = _collection.ReplaceOne(filter, record);
            return record;
        }
    }
}