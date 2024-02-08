using System;
using System.IO;

namespace Serializer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Serializer running...");
            string path = @".\TextFile.txt";
            
            // create some objects
            Person Lawrence = new Person("Lawrence", 72, 28);

            // display/confirm the object
            // Console.WriteLine(Lawrence.ToString());
            
            bool loopAgain = true;
            do{
                Console.WriteLine("\nSelect an option:");
                Console.WriteLine("1\t-\twrite to file");
                Console.WriteLine("2\t-\tread from file");
                Console.WriteLine("3\t-\tserialize to XML, and write to the file");
                Console.WriteLine("0\t-\tExit Program");
                string? userOption = Console.ReadLine();
                
                switch(userOption){
                    case "1":{
                        // write text and save to file
                        writeFile(path);
                        break;
                    }
                    case "2":{
                        // read from the file
                        readFile(path);
                        break;
                    }
                    case "3":{
                        // convert/serialize the object
                        string[] text = {Lawrence.SerializeXML()};
                        saveSerialize(text, path);
                        break;
                    }
                    case "0":{
                        loopAgain = false;
                        break;
                    }
                    default:{
                        Console.WriteLine("Invalid option");
                        break;
                    }
                }
            }while(loopAgain);
            

            
            
            
            // Console.WriteLine(Lawrence.SerializeXML());

            // save the serialized object to a file
            
            
        }

        static void readFile(string path){
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

        static void writeFile(string path){
            Console.WriteLine("Writing to file:");
            string[] text = {Console.ReadLine()};

            if( File.Exists(path))
            {
                File.AppendAllLines(path,text);
            }
            else
            {
                File.WriteAllLines(path, text); // WriteAllLines requires an IEnumerable (a collection) of strings
               // File.WriteLine(path, <string>); // WriteLine will operate on a single string
            }
            Console.WriteLine("Saved");
        }
    
        static void saveSerialize(string[] text, string path){
            File.WriteAllLines(path, text);
            Console.WriteLine("Saved");
        }
    
    }
}