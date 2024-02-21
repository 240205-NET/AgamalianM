using System;

namespace SchoolClient.Logic
{
    public class Student : Person
    {
        // Fields
        public double? gpa { get; set; } = 0;
        public int? studentId { get; }
        private static int idSeed = 1;
        
        // Constructor
        public Student()
        {}
        public Student( int id, string name, string email, string address1, string address2, string city, string state, string zip, double gpa = 0.0)
        {
            this.studentId = id;
            this.name = name;
            this.email = email;
            this.address1 = address1;
            this.address2 = address2;
            this.city = city;
            this.state = state;
            this.zip = zip;
            this.gpa = gpa;
        }
        public Student( string name, string email, string address1, string address2, string city, string state, string zip)
        {
            this.studentId = idSeed;
            this.name = name;
            this.email = email;
            this.address1 = address1;
            this.address2 = address2;
            this.city = city;
            this.state = state;
            this.zip = zip;

            idSeed++;
        }

        // Methods
        public override string ToString()
        {
            return $"Student\nName: {this.name}\nId: {this.studentId}\nGPA: {this.gpa}\nEmail: {this.email}\nAddress:\n{this.address1}\n{this.address2}\n{this.city} {this.state}, {this.zip}\n";
        }
    }
}