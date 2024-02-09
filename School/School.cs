namespace School{
    class School{
        // Fields

        private List<Student> students = new List<Student>();
        private List<Teacher> teachers = new List<Teacher>();
        Student newGuy = new  Student("New Guy", "newguy@email.com", "120 ave", "", "Knoxville", "Io", "12345");
        Teacher newTeacher = new  Teacher(14,25000,"Math", "Steve", "steve@email.com", "1229 apt", "", "Jupiter", "Fm", "54322");

        // Constructors
        public School(){

        }

        // Methods
        public Student GetStudent(){
            return newGuy;
        }
    }
}