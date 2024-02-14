namespace Project1{
    class Program{
        static void Main(){
            Day day = new Day(10);
            Stock Amazon = new Stock(day.numberOfDays, "Amazon", 10, 500, 10);
            Stock Target = new Stock(day.numberOfDays, "Target", 5, 200, 20);
            Console.WriteLine("NEW STOCK: " +"\n"+ Amazon +"\n"+ Target);

            Account account1 = new Account("Michael", 18, "128 pe node", 999999, 2);
            Console.WriteLine("NEW ACCOUNT: " + account1);

            Console.WriteLine("BUY");
            account1.BuyStock(day,Amazon,3);
            Console.WriteLine(account1);
            account1.BuyStock(day,Target,4);
            Console.WriteLine(account1);
            day.Next();
            
            Console.WriteLine("SELL");
            account1.SellStock(day,Amazon,2);
            account1.SellStock(day,Target,4);
            Console.WriteLine(account1);

        }
    }
}