using System;

namespace School.App
{
    class Student : Person
    {
        // Fields
        public double gpa { get; set; } = 0;
        
        // Constructor
        public Student( string name, string email, string address1, string address2, string city, string state, string zip)
        {
            this.name = name;
            this.email = email;
            this.address1 = address1;
            this.address2 = address2;
            this.city = city;
            this.state = state;
            this.zip = zip;
        }

        // Methods
        public override string ToString()
        {
            return $"Student\nName: {this.name}\nGPA: {this.gpa}\nEmail: {this.email}\nAddress:\n{this.address1}\n{this.address2}\n{this.city} {this.state}, {this.zip}\n";
        }
    }
}