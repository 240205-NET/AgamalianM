namespace School{
        class Student : Person{
            // Fields
            public double GPA {get; set;} = 0.0;

            // Constructors
            public Student(string name, string email, string address1, string address2, string city, string state, string zip){
                this.name = name;
                this.email = email;
                this.address1 = address1;
                this.address2 = address2;
                this.city = city;
                this.state = state;
                this.zip = zip;
            }

            // Methods
        }
}

// Students : child of Person
    // Schedule
    // Grades
    // GPA