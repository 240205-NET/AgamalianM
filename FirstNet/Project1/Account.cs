using System.Text;

namespace Project1{
    class Account{
        // Fields
        public string name{get;set;}
        public int age {get;set;}
        public string address{get;set;}
        public int balance{get;set;} = 0;
        public int tier{get;set;} = 1;
        public List<Stock> stocks{get;set;}
        

        // Constructors
        public Account(string name, int age, string address, int balance, int tier){
            this.name = name;
            this.age = age;
            this.address = address;
            this.balance = balance;
            this.tier = tier;
            this.stocks = new List<Stock>();
        }

        // Methods
        public override string ToString(){
            var sb = new StringBuilder();
            sb.Append("Name: " + name);
            sb.Append("\tBalance: $" + balance);
            sb.AppendLine("\tTier: " + tier);
            if(stocks.Count() != 0){
                sb.AppendLine("---Portfolio---");
                foreach(Stock s in stocks)
                    sb.AppendLine(s.ToString());
            }
            return sb.ToString();
        }

        public void BuyStock(Day day, Stock stock, int amount){
            int cost = amount * stock.data.GetPrice(day.day, day.isStartOfDay);
            if(amount < 0){
                Console.WriteLine("Must be a positive number");
            }else if(amount > stock.Quantity){
                Console.WriteLine("Amount not available");
            }else if(cost > this.balance){
                Console.WriteLine("Not enough funds");
            }else{
                stock.Quantity -= amount;
                var newStock = (from s in this.stocks
                                where s.CompanyName == stock.CompanyName
                                select s).FirstOrDefault();
                
                if(newStock == null){
                    newStock = new Stock(stock);
                    newStock.Quantity = amount;
                } else{
                    this.stocks.Remove(newStock);
                    newStock.Quantity += amount;
                }
                 
                this.stocks.Add(newStock);
                this.balance -= cost;
                Console.WriteLine("Transaction Complete");
            }
            
        }

        public void SellStock(Day day, Stock stock , int amount){
            int cost = amount * stock.data.GetPrice(day.day, day.isStartOfDay);
            var accountStock = (from s in this.stocks
                                where s.CompanyName == stock.CompanyName
                                select s).FirstOrDefault();
            if(amount < 0){
                Console.WriteLine("Must be a positive number");
            }else if(accountStock == null){
                Console.WriteLine("You do not own any of this stock");
            }else if(amount > accountStock.Quantity){
                Console.WriteLine("Amount not available");
            }else{
                stocks.Remove(accountStock);
                if(accountStock.Quantity != amount){
                    accountStock.Quantity -= amount;
                    stocks.Add(accountStock);
                }

                stock.Quantity += amount;
                this.balance += cost;
                Console.WriteLine("Transaction Complete");
            }
        }
    }
}


// Accounts
    // Owner
        // Name
        // Age
        // Address
    // Funds        --how much in yo bank
        // Assets
        // Checking Account
    // Buy Power    --how much you are risking
        // Low-Buy Power
        // High-Buy Power
        // Unlimited-Buy Power