using System;

namespace TestClient{
    public class Program{
        public static async void Main(string[] args){
            string uri = "https://localhost:7113";

            Console.WriteLine("select an option");
            Console.WriteLine("[1] - list all albums");
            Console.WriteLine("[2] - find an album by id");
            
            string tempuri = "";
            char choice = Console.ReadKey(true).KeyChar;
            switch(choice){
                case '1':
                    tempuri = uri + "/Test/Albums";
                    System.Console.WriteLine(await ListAllAlbumsAsync(tempuri));
                    break;
                case '2':
                    break;
                default:
                    break;
            }
        }

        static async Task<string> ListAllAlbumsAsync(string uri){
            
        }
    }
}