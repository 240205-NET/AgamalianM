using System;
using System.Text;

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
        
            _students.Add(new Student( "New Guy", "guy@no.com", "1500 Pen. Ave", "", "Washington", "DC", "12345"));
            _teachers.Add(new Teacher(14, 75000, "Science", "Someone New", "new.teach@no.com", "Somewhere", "", "NYC", "NY", "12345"));
        }

        // Methods
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

        public string GetTeachersInfo()
        {
            var sb = new StringBuilder();
            foreach(Teacher t in _teachers)
            {
                sb.AppendLine(t.ToString());
            }
            return sb.ToString();
        }
    }
}