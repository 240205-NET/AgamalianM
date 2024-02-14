using System;

namespace School.App
{
    class Program
    {
        static void Main()
        // To Do Monday:
        // - review the changes (person, student, teacher, course, class, program)
        // - separate concerns (.App/.Logic)
        // - XML commenting
        // - retrieve specific person
        {
            try
            {
                Console.WriteLine("School Starting...");

                School MySchool = new School();
                Student tmp = MySchool.GetStudent();
                Console.WriteLine(tmp.name);
                Console.WriteLine(MySchool.GetStudentsInfo());

                Console.WriteLine("Establishing Connection...");
                string path = "./../.ConnectionString.txt";
                string connectionString = File.ReadAllText(path);
                
                Console.WriteLine(MySchool.GetTeachersInfo(connectionString));
                Console.WriteLine("School Ending...");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }   
}