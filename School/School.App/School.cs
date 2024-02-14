using System;
using System.Text;
using System.Data.SqlClient;
using School.Logic;

namespace School.App
{
    class School
    {
        // Fields
        private List<Student> _students;
        private List<Teacher> _teachers;
        private List<Course> _courses;
        private List<Class> _classes;
        
        // Constructor
        public School()
        {
            this._students = new List<Student>();
            this._teachers = new List<Teacher>();
            this._courses = new List<Course>();
            this._classes = new List<Class>();
        
            _students.Add(new Student( "New Guy", "guy@no.com", "1500 Pen. Ave", "", "Washington", "DC", 12345));
            _teachers.Add(new Teacher(14, 75000, "Science", "Someone New", "new.teach@no.com", "Somewhere", "", "NYC", "NY", 12345));
        }

        // Methods
        public Student GetStudent(int studentId)
        {
            /*
            // a list is indexed
            // a dictionary is not indexed, but is pairs (entries and keys)
            // you can look up an entry by the key. the Key MUST be unique within the dictionary
            // Dictionary in a loop! 
            foreach( Student s in _students)
            {
                if (s.studentId == studentId)
                {
                    StudentDictionary.Add(s.studentId, s);
                }
            }
            return StudentDictionary.Add(s.studentId, s);
            */

            
            // Only returns the FIRST instance that matches
            foreach( Student s in _students)
            {
                if (s.studentId == studentId)
                {
                    return s;
                }
            }

            return new Student();

            /*
            // returns ALL possible instances that match
            List<Student> result = new List<Student>();
            foreach( Student s in _students)
            {
                if (s.studentId == studentId)
                {
                    result.Add(s);
                }
            }
            return result;
            */

            // List.IndexOf() - searches the list and returns the index of the entry that matches the object sent as a parameter.
            // this method would require a not-insignificant rewrite of our Student class.

            // List.Find() - Accepts a value, searches the list, and returns the instances of the object



            // LINQ (Lin-Que) is all about sorting and filtering
            /* LINQ syntax
            var studentQuery =  from s in _students 
                                where s.studentId == studentId
                                select s;

            return studentQuery.FirstOrDefault();
            */


            // llambda expression syntax
            /*
            return _students.FirstOrDefault(s => s.studentId == studentId);
            */

        }

        public List<Student> GetStudents()
        {
            return _students;
        }

        public List<Teacher> GetTeachers()
        {
            return _teachers;
        }

        public string GetStudentsInfo()
        {
            var sb = new StringBuilder();
            foreach(Student s in _students)
            {
                sb.AppendLine(s.ToString());
            }
            return sb.ToString();
        }

        // public string GetTeachersInfo()
        // {
        //     var sb = new StringBuilder();
        //     foreach(Teacher t in _teachers)
        //     {
        //         sb.AppendLine(t.ToString());
        //     }
        //     return sb.ToString();
        // }

        public string GetTeachersInfo(string connectionString){
            var sb = new StringBuilder();
            using SqlConnection connection = new SqlConnection(connectionString);

            try{
                connection.Open();
                string cmdText = "SELECT * FROM [School].[Teachers];";
                using SqlCommand cmd = new SqlCommand(cmdText, connection);
                using SqlDataReader reader = cmd.ExecuteReader();
                
                while(reader.Read()){

                    // string Id = reader.GetInt32(0); // Id INT PRIMARY KEY,
                    string name = reader.GetString(1); // Name VARCHAR(255) NOT NULL,
                    string email = reader.GetString(2); // Email VARCHAR(255) NOT NULL,
                    string address1 = reader.GetString(3); // Address1 VARCHAR(255)NOT NULL,
                    string address2 = reader.GetString(4); // Address2 VARCHAR(255),
                    string city = reader.GetString(5); // City VARCHAR(255) NOT NULL,
                    string state = reader.GetString(6); // State VARCHAR(255) NOT NULL,
                    int zip = reader.GetInt32(7); // Zip INT NOT NULL,
                    int office = reader.GetInt32(8); // Office INT NOT NULL,
                    decimal salary = reader.GetDecimal(9); // Salary DECIMAL NOT NULL,
                    string subject = reader.GetString(10); // Subject VARCHAR(255) NOT NULL           
                    
                    sb.AppendLine(new Teacher(office, salary, subject, name, email, address1, address2, city, state, zip).ToString());
                }
                connection.Close();
            }catch(Exception e){
                Console.WriteLine(e);
                connection.Close();
            }

            return sb.ToString();
        }

        public void AddTeacherToDB(Teacher teacher){
            // INSERT INTO [School].[Teachers] (
            // [Id],
            // [Name],
            // [Email],
            // [Address1],
            // [Address2],
            // [City],
            // [State],
            // [Zip],
            // [Office],
            // [Salary],
            // [Subject]
            // )
            // VALUES(
            //     13,
            //     'MR. DUDER',
            //     'noemail@nothin.net',
            //     '1392 idho pl',
            //     '',
            //     'Riverbrook',
            //     'KY',
            //     48223,
            //     4,
            //     255.32,
            //     'Sience'
            // );
        }
    }
}