namespace Project1{
    class Program{
        static void Main(){
            int day = 3;
            bool isStartOfDay = true;
            Stock Amazon = new Stock("Amazon", 1000, 500, 10);

            Console.WriteLine(Amazon.ToString());

            Account account1 = new Account("Michael", 18, "128 pe node", 999999, 2);
            Console.WriteLine(account1.ToString());

            account1.BuyStock(day, isStartOfDay, Amazon, 499);
            Console.WriteLine(account1.ToString());

            account1.BuyStock(day, isStartOfDay, Amazon, 505);
            Console.WriteLine(account1.ToString());
            
            account1.BuyStock(day, isStartOfDay, Amazon, 2);
            Console.WriteLine(account1.ToString());

        }
    }
}