namespace Project1{
    class Transaction{
        // Fields
        public int day{get;set;}
        public Account account{get;set;}
        public Stock stock{get;set;}
        public string transaction{get;set;}
        public int amount{get;set;}

        // Constructors
        public Transaction(int day, Account account, Stock stock){
            this.day = day;
            this.account = account;
            this.stock = stock;
        }

        // Methods
        public void BuyStock(int amount, bool isStartOfDay){
            int cost = amount * this.stock.data.GetPrice(day, isStartOfDay);
            Console.WriteLine("Cost: " + this.stock.data.GetPrice(day, isStartOfDay)
                            + " x " + amount + " = " + cost);
            if(amount < 0){
                Console.WriteLine("Must be a positive number");
            }else if(amount > stock.Quantity){
                Console.WriteLine("Amount not available");
            }else if(cost > account.balance){
                Console.WriteLine("Not enough funds");
            }else{
                this.stock.Quantity -= amount;
                if(this.account.stocks.Exists(s => s.CompanyName == this.stock.CompanyName)){
                    Console.WriteLine("adding on");
                } else {
                    Console.WriteLine("nothing found");
                    Stock boughtStock = this.stock;
                    boughtStock.Quantity = amount; 
                    this.account.stocks.Add(boughtStock);
                    this.account.balance -= cost;
                }
            }
        }
       
    }
}

// Transactions
    // Date
    // Account
    // Stock
    // Transaction  --Buy or sell
        // Amount