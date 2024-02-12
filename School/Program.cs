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
            Console.WriteLine("School Starting...");
            try
            {
                School MySchool = new School();
                // Student tmp = MySchool.GetStudent();
                // Console.WriteLine(tmp.name);
                Console.WriteLine(MySchool.GetStudentsInfo());
                Console.WriteLine(MySchool.GetTeachersInfo());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Schoold Ending...");
        }
    }
}