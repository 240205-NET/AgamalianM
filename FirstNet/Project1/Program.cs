namespace Project1{
    class Program{
        static void Main(){
            Data amazonData = new Data();
            amazonData.GenerateData(500, 10);
            Stock Amazon = new Stock("Amazon", 1000);

            Console.WriteLine(Amazon.ToString());

            Account account1 = new Account("Michael", 18, "128 pe node", 100, 2);
            Console.WriteLine(account1.ToString());
            
            Transaction test = new Transaction(2, account1, Amazon);
        }
    }
}