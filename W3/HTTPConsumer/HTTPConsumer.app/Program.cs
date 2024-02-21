using HTTPConsumer.DTO;
using System;
using System.Net.Http;
using System.Text.Json;

namespace HTTPConsumer.App
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("HTTP Consumer Console App Starting...");

            // create an HTTP Client object
            HttpClient client = new HttpClient();

            // retrieve ALL of the posts
            // prepare the info you need to make your request...
            int? postNumber = 45;
            string uri = $"http://jsonplaceholder.typicode.com/posts/{postNumber}";

            // HTTP Status Codes
            // 1xx's - Info 
            // 2xx's - Good response
            // 3xx's - Redirection
            // 4xx's - Client error
            // 404 - resource not found
            // 403 - access denied/forbidden
            // 418 - I am a teapot
            // 5xx's - Server error
            

            // Async and await
            // Async(ronous) - run this thing, but you CAN do other things while you're waiting for this...
            // Await - this is the thing you're going to wait for a result from.
            string HTTPresponse = await client.GetStringAsync(uri);

            // When we use 'async' and 'await' the containing method must be asynchronous
            // any async method MUST return a Task (an object that denotes if the method has completed or not)
            // in addition to any object or type that the method would otherwise return

            // Console.WriteLine(HTTPresponse);

            //List<Post> posts = JsonSerializer.Deserialize<List<Post>>(HTTPresponse);

            Post posts = JsonSerializer.Deserialize<Post>(HTTPresponse);

            Console.WriteLine($"{posts.userId}: {posts.title}\n{posts.body}\n\n");

            //Console.WriteLine($"{posts[45].userId}: {posts[45].title}\n{posts[45].body}\n\n");

            //foreach (var item in posts)
            //{
            //    Console.WriteLine($"{item.userId}: {item.title}\n{item.body}\n\n");
            //}
        }
    } // close the Program class


}