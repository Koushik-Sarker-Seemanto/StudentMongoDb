namespace StudentMongoDB
{
    public class Student
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Dept { get; set; }
        public Student()
        {
            
        }

        public Student(string id, string name, string dept)
        {
            this.Id = id;
            this.Name = name;
            this.Dept = dept;
        }
    }
}