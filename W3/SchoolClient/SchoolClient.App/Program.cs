using System;
using System.Net.Http;
using System.Text.Json;
using SchoolClient.Logic;

namespace SchoolClient.App
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("SchoolClient Starting...");

            string host = "https://localhost:";
            int port;

            Console.WriteLine("Enter the portnumber for the locally running api: ");
            Int32.TryParse(Console.ReadLine(), out port);
            string uri = host + port;
            Console.WriteLine(uri);

            bool loop = true;
            while(loop)
            {
                Console.WriteLine(@"Select an action:
                1: List All Students
                2: List A Student
                0: Exit");
                string selection = Console.ReadLine();

                string tmpuri = "";
                switch (selection)
                {
                    case "1":
                        tmpuri = uri + "/api/Student";
                        Console.WriteLine(tmpuri);
                        Console.WriteLine(await ListAllStudentsAsync(tmpuri));
                        break;
                    
                    case "2":
                        int id;
                        Console.WriteLine("Enter the student id #: ");
                        Int32.TryParse(Console.ReadLine(), out id);
                        tmpuri = uri + "/api/Student/" + id;
                        Console.WriteLine(tmpuri);
                        Console.WriteLine(await ListStudentByIdAsync(tmpuri));
                        break;

                    case "0":
                        loop = false;
                        break;

                    default:
                        break;
                }
            }
        }
        private static async Task<string> ListAllStudentsAsync(string uri)
        {
            HttpClient client = new HttpClient();
            string response = await client.GetStringAsync(uri);
            List<Student> students = JsonSerializer.Deserialize<List<Student>>(response);
            string result = "";
            foreach( var s in students)
            {
                result += $"- {s.name}\n";
            }
            return result;
        }
        private static async Task<string> ListStudentByIdAsync(string uri)
        {
            HttpClient client = new HttpClient();
            string response = await client.GetStringAsync(uri);
            Student student= JsonSerializer.Deserialize<Student>(response);
            return student.ToString();
        }
    }
}