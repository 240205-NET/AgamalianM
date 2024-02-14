namespace Project1{
    class Program{
        static void Main(){
            Stock Amazon = new Stock("Amazon", 1000, 500, 10);

            Console.WriteLine(Amazon.ToString());

            Account account1 = new Account("Michael", 18, "128 pe node", 999999, 2);
            Console.WriteLine(account1.ToString());
            
            Transaction test = new Transaction(2, account1, Amazon);
            test.BuyStock(500,true);
            Console.WriteLine(account1.ToString());

            test.BuyStock(502,true);
            Console.WriteLine(account1.ToString());

        }
    }
}