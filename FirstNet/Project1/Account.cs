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
        public string ToString(){
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

        public void BuyStock(int day, bool isStartOfDay, Stock stock, int amount){
            int cost = amount * stock.data.GetPrice(day, isStartOfDay);
            // Console.WriteLine("Cost: " + stock.data.GetPrice(day, isStartOfDay)
            //                 + " x " + amount + " = " + cost);
            if(amount < 0){
                Console.WriteLine("Must be a positive number");
            }else if(amount > stock.Quantity){
                Console.WriteLine("Amount not available");
            }else if(cost > this.balance){
                Console.WriteLine("Not enough funds");
            }else{
                stock.Quantity -= amount; // FIX Global stock.quantity 
                var newStock = (from s in this.stocks
                                where s.CompanyName == stock.CompanyName
                                select s).FirstOrDefault();
                
                if(newStock == null){
                    Console.WriteLine("nothing found");
                    newStock = stock;
                    newStock.Quantity = amount;
                } else{
                    Console.WriteLine("found something: " + newStock.ToString());
                    this.stocks.Remove(newStock);
                    newStock.Quantity += amount;
                }
                 
                this.stocks.Add(newStock);
                this.balance -= cost;
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