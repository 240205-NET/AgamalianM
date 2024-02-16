using System.Xml.Serialization;

namespace Serializer
{
    public class Person
    {
        // Fields
        public string? name { get; set; }
        public double? height {get; set; }
        public int? age { get; set; }
        private XmlSerializer Serializer = new XmlSerializer(typeof(Person));

        // Constructor
        public Person(){}
        public Person(string? name, double? height, int? age)
        {
            this.name = name;
            this.height = height;
            this.age = age;
        }
        public Person(string name = "" , double height = 50, int age = 18)
        {
            this.name = name;
            this.height = height;
            this.age = age;
        }

        // Methods
        public string SerializeXML()
        {
            var stringWriter = new StringWriter();
            Serializer.Serialize(stringWriter, this);
            stringWriter.Close();
            return stringWriter.ToString();
        }

        public string ToString()
        {
            var result = new System.Text.StringBuilder();
            result.AppendLine($"Name: {this.name} \t Height: {this.height} in. \t Age: {this.age}");
            return result.ToString();

            // it works, but it's a bad habit!
            // return $"Name: {this.name} \t Height: {this.height} in. \t Age: {this.age}";
        }
    }
}