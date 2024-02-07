namespace Banking{
    abstract class Account
    {
        //fields
        public int accountNumber {get;set;}
        protected double balance;
        private string owner;
        private static int accountNumberSeed = 1;
        private List<Transaction> transactions = new List<Transaction>();
        
        //constructor
        public Account(string ownerName, double initialBalance){
            this.accountNumber = accountNumberSeed++;
            
            this.owner = ownerName;
            MakeDeposit(initialBalance);
        }

        //methods
        public virtual void MakeDeposit(double amount, string note = ""){
            if(amount < 0){
                Console.WriteLine("Deposit can not be less than 0");
            }else{
                balance += amount;
                Transaction deposit = new Transaction(amount, DateTime.Now, note);
                transactions.Add(deposit); 
            }
        }

        public virtual void MakeWithdrawl(double amount, string note = ""){
            if(amount < 0){
                Console.WriteLine("Withdrawl can not be less than 0");
            } else if(balance - amount < 0){
                Console.WriteLine("Insufficient funds!");
            }else{
                balance -= amount;
                Transaction withdrawl = new Transaction(-amount, DateTime.Now, note = "");
                transactions.Add(withdrawl);
            }
        }

        public virtual string DisplayBalance(){
            return "Account #" + this.accountNumber + " has a balance of: " + this.balance;
        }

        public virtual string DisplayTransactionHistory(){
            var history = new System.Text.StringBuilder();

            history.AppendLine("Date\t\tAmount\t\tNote");
            foreach(Transaction item in transactions){
                history.AppendLine($"{item.date.ToShortDateString()}\t{item.amount}\t\t{item.note}");
            }
            history.AppendLine("Current Balance:\t\t" + balance);
            return history.ToString();
        }
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