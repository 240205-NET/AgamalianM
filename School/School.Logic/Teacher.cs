using System;

namespace School.Logic
{
    public class Teacher : Person
    {          
        // Fields
        public int office { get; set; }
        public double salary { get; set; }
        public string subject { get; set; }

        // Constructors
        public Teacher (int office, double salary, string subject, string name, string email, string address1, string address2, string city, string state, string zip)
        {
            this.office = office;
            this.salary = salary;
            this.subject = subject;
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
            return $"Teacher\nName: {this.name}\nSubject: {this.subject}\nOffice: {this.office}\nEmail: {this.email}\nAddress:\n{this.address1}\n{this.address2}\n{this.city} {this.state}, {this.zip}\n";
        }
    }
}