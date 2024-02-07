namespace Banking{
    class Program{
        public static void Main(string[] args){
            
            Account account2 = new SavingsAccount("James", 140.43);
            Account account1 = new SavingsAccount("Michael", 100.13);
            Account account3 = new SavingsAccount("John", 10.23);

            Console.WriteLine(account1.DisplayBalance());
            Console.WriteLine(account2.DisplayBalance());
            Console.WriteLine(account3.DisplayBalance());

            account2.MakeDeposit(20.3, "For funsies");
            Console.WriteLine(account2.DisplayTransactionHistory());
            account1.MakeWithdrawl(10.50 , "NEED COFFEE");
            Console.WriteLine(account1.DisplayTransactionHistory());

        }
    }
}