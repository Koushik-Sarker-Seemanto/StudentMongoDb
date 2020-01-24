using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace StudentMongoDB
{
    public class GenericRepository<T>: IGenericRepository<T> where T: class
    {
        private readonly IMongoCollection<T> _collection;

        // private static Repository _instance;
        public GenericRepository(string collectionName)
        {
            IMongoClient client = new MongoClient();
            var database = client.GetDatabase("testDB");
            _collection = database.GetCollection<T>(collectionName);
        }


        public IEnumerable<T> GetAll()
        {
            var all = _collection.Find(new BsonDocument());
            return all.ToEnumerable();
        }
        public T GetById(string id)
        {
            var filter = Builders<T>.Filter.Eq("Id", id);
            return  _collection.Find(filter).FirstOrDefault();
        }

        public T Insert(T record)
        {
            _collection.InsertOne(record);
            return record;
        }

        public T Delete(string id)
        {
            var filter = Builders<T>.Filter.Eq("Id", id);
            var record = _collection.FindOneAndDelete(filter);
            return record;
        }

        public T Update(T record, string id)
        {
            var filter = Builders<T>.Filter.Eq("Id", id);
            var updated = _collection.ReplaceOne(filter, record);
            return record;
        }
    }
}