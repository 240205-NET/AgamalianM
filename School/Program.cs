namespace School{
    class Program{
        static void Main(){
            
            Console.WriteLine("School Starting...");
            try{
                School MySchool = new School();
            }
            catch(Exception e){
                Console.WriteLine(e.Message);
            }
            
            Console.WriteLine("School Ending...");

            // Courses : Parent Class
                // ID
                // Name
                // Department
                // Requirements
                // Credit Hours

            // Classes : Child of Course
                // Location
                // Schedule
                // Instructor
                // Roster
                // Capacity
                // Section

        }
    }
}