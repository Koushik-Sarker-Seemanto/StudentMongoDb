using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
namespace StudentMongoDB
{
    public class Teacher
    {
        [BsonId]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Dept { get; set; }
        public string Type { get; set; }
        
        public Teacher()
        {
            
        }

        public Teacher(string id, string name, string dept, string type)
        {
            this.Id = id;
            this.Name = name;
            this.Dept = dept;
            this.Type = type;
        }
    }
}