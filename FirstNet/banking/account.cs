namespace Banking{
    class Account
    {
        //fields
        public int accountNumber {get;set;}

        protected double balance;

        private string owner;

        private static int accountNumberSeed = 1;
        
        //constructor
        public Account(string ownerName, double initialBalance){
            this.accountNumber = accountNumberSeed++;
            
            this.owner = ownerName;
            makeDeposit(initialBalance);
        }



        
        //methods
    }
}


//account
//pin
//owner
//account_type
//account_number
//balance
//withdrawals
//deposit
//balance
//associate with another account
//transfer to another account
//close account