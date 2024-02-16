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

        // SQL - Database
        // SQL - Structured Query Language
        // It's a whole new language! It has it's own syntax, and there's many "flavors" of SQL
        // PostgreSQL, SQLite, MS-SQL/T-SQL/Transactional-SQL

        {
            try
            {
                Console.WriteLine("School Starting...");

                School MySchool = new School();
                // Student tmp = MySchool.GetStudent();
                // Console.WriteLine(tmp.name);
                Console.WriteLine(MySchool.GetStudentsInfo());
                Console.WriteLine(MySchool.GetTeachersInfo());

                Console.WriteLine("Schoold Ending...");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        
    }
}