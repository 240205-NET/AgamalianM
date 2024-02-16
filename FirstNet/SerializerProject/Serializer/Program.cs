using System;
using System.IO;
using System.Xml.Serialization;

namespace Serializer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Serializer running...");

            Menu();

            Console.WriteLine("Application closing...");
        }

        public static void Menu()
        {
            string path = @".\TextFile.txt";
            // create some objects
            Person Lawrence = new Person("Lawrence", 72, 28);

            bool loop = true;
            while(loop)
            {
                Console.WriteLine("Please select an option:");
                Console.WriteLine("1: Read from file.");
                Console.WriteLine("2: Write to file.");
                Console.WriteLine("3: Create Xml Record");
                Console.WriteLine("4: Read from Xml Record");
                Console.WriteLine("5: Parse string to ints");
                Console.WriteLine("0: Exit.");

                string? choice = Console.ReadLine(); // the "?" makes it nullable

                switch(choice)
                {
                    case "1": // if (choice == "1")
                        ReadFile(path);
                        break;

                    case "2":
                        WriteFile(Lawrence, path);
                        break;

                    case "3":
                        Serialize(Lawrence, path);
                        break;

                    case "4":
                        Person NewGuy = DeserializeXML(path);
                        Console.WriteLine(NewGuy.ToString());
                        break;

                    case "5":
                        Console.WriteLine("Please enter a number to be parsed from a string to an int: ");
                        string input = Console.ReadLine();
                        try
                        {
                            int result = TextToNumber(input);
                            Console.WriteLine("Resulted in a type of: " + result.GetType() + " with a value of: " + result);
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine("Invalid input: " + e.Message);
                        }
                        break;

                    case "0":
                        loop = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }
        
        static void WriteFile(Person Lawrence, string path)
        {
            // display/confirm the object
            Console.WriteLine(Lawrence.ToString());

            // save to a file as text
            Console.WriteLine("Writing to file...");
            string[] text = {Lawrence.ToString()};

            if( File.Exists(path))
            {
                File.AppendAllLines(path,text);
            }
            else
            {
                File.WriteAllLines(path, text); // WriteAllLines requires an IEnumerable (a collection) of strings
            // File.WriteLine(path, <string>); // WriteLine will operate on a single string
            }
        }

        static void ReadFile(string path)
        {
            Console.WriteLine("Reading from file...");
            // read from the file
            if(File.Exists(path))
            {
                string[] readText = File.ReadAllLines(path);
                foreach (string s in readText)
                {
                    Console.WriteLine(s);
                }
            }
            else
            {
                Console.WriteLine("File Not Found");
            }
        }

        static void Serialize(Person Lawrence, string path)
        {
            // convert/serialize the object
            Console.WriteLine(Lawrence.SerializeXML());

            // save the serialized object to a file
            string[] text1 = {Lawrence.SerializeXML()};
            File.WriteAllLines(path, text1);
        }

        static Person DeserializeXML(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Person));
            Person P = new Person();
            if (!File.Exists(path))
            {
                Console.WriteLine("File Not Found");
                return null;
            }
            else
            {
                using StreamReader reader = new StreamReader(path);
                var record = (Person)serializer.Deserialize(reader);
                if (record is null)
                {
                    throw new InvalidDataException();
                    return null;
                }
                else
                {
                    P = record;
                }
            }
            return P;
        }

        public static int TextToNumber(string raw)
        {
            int result;
            if(!Int32.TryParse(raw, out result))
            {
                throw new Exception("Input must be numerical.");
            }
            else
            {
                return result;
            }
        }
    }
}
