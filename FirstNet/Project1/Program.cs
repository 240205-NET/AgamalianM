namespace Project1{
    class Program{
        static void Main(){
            List<Account> accounts = new List<Account>();
            List<Stock> stocks = new List<Stock>();
            Day day = new Day(10);
            Stock Amazon = new Stock(day.numberOfDays, "Amazon", 10, 500, 10);
            stocks.Add(Amazon);
            Stock Target = new Stock(day.numberOfDays, "Target", 5, 200, 20);
            stocks.Add(Target);
            Console.WriteLine("NEW STOCK: " +"\n"+ Amazon +"\n"+ Target);
            Account account1 = new Account("Michael", 18, "128 pe node", 999999, 2);
            accounts.Add(account1);
            Console.WriteLine("NEW ACCOUNT: " + account1);

            Console.WriteLine("BUY");
            account1.BuyStock(day,Amazon,3);
            Console.WriteLine(account1);
            account1.BuyStock(day,Target,4);
            Console.WriteLine(account1);
            day.Next(stocks, accounts);
            
            Console.WriteLine("SELL");
            account1.SellStock(day,Amazon,2);
            account1.SellStock(day,Target,4);
            Console.WriteLine(account1);

            day.Set(9,true);
            while(day.Next(stocks, accounts));
        }
    }
}