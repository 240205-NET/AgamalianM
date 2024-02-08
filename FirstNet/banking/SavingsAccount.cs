namespace Banking{
    class SavingsAccount : Account{
        //fields
        private double interestRate;

        //constructors
        public SavingsAccount(string owner, double initialBalance, double interestRate = 0.1) : base(owner, initialBalance){
            this.interestRate = interestRate;
        }

        //methods
        public override string DisplayBalance(){
            return "From Savings Account: " +  balance;
        }

    }
}