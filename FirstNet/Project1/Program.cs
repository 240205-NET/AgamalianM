namespace Project1{
    class Program{
        static void Main(){
            Console.WriteLine("How Many Days?");
            Day day = new Day(Int32.Parse(Console.ReadLine()));
            Stock Microsoft = new Stock(day.numberOfDays, "Microsoft", 20, 300, 10);
            Stock Facebook = new Stock(day.numberOfDays, "Facebook", 10, 500, 10);
            Stock Apple = new Stock(day.numberOfDays, "Apple", 5, 200, 2);
            Stock Amazon = new Stock(day.numberOfDays, "Amazon", 8, 400, 1);
            Stock Netflix = new Stock(day.numberOfDays, "Netflix", 15, 100, 5);
            Stock Google = new Stock(day.numberOfDays, "Google", 10, 700, 3);

            Console.WriteLine("Please Create an account");
            Console.Write("name: ");
            string name = Console.ReadLine();
            Console.Write("age: ");
            int age = Int32.Parse(Console.ReadLine());
            Console.Write("address: ");
            string address = Console.ReadLine();
            Console.Write("balance: ");
            int balance = Int32.Parse(Console.ReadLine());
            Console.Write("tier: ");
            int tier = Int32.Parse(Console.ReadLine());
            Account account1 = new Account(name, age, address, balance, tier);

            Console.WriteLine("Welcome");
            Console.WriteLine(account1.ToString(day));

            do{
                Google.AnnounceStockPrices(day);
                
                Console.WriteLine("\nChoose an option");
                Console.WriteLine("1 -- BUY STOCK");
                Console.WriteLine("2 -- SELL STOCK");
                Console.WriteLine("3 -- HOLD STOCK");
                Console.WriteLine("4 -- SKIP TO DAY");
                
                int choice = Int32.Parse(Console.ReadLine());

                switch(choice){
                    case 1:
                        Console.WriteLine("Choose stock to buy");
                        //choose stock to buy
                        break;
                    case 2:
                        Console.WriteLine("Choose stock to sell");
                        //choose stock to sell
                        break;
                    case 3:
                        break;
                    case 4:
                        Console.WriteLine("which day would you like to skip too?");
                        int userDay = Int32.Parse(Console.ReadLine());
                        day.Set(userDay, true);
                        break;
                    default:
                        Console.WriteLine("unkown option");
                        break;
                }

            }while(day.Next());
            Console.WriteLine("thanks for playing");
            Console.WriteLine("STATS");
            Console.WriteLine(account1.ToString(day));
        }
    }
}