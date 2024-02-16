using System.Text;

namespace Project1{
    public class Account{
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
        public string ToString(Day today){
            var sb = new StringBuilder();
            sb.Append("\nName: " + name);
            sb.Append("\tBalance: $" + balance);
            sb.AppendLine("\tTier: " + tier);
            if(stocks.Count() != 0){
                sb.AppendLine("---Portfolio---");
                foreach(Stock s in stocks)
                    sb.AppendLine(s.ToString(today));
            }
            return sb.ToString();
        }

        public void BuyStock(Day day, Stock stock, int amount){
            int stockPrice = stock.data.GetPrice(day.day, day.isStartOfDay);
            int cost = amount * stockPrice;
            if(amount < 0){
                Console.WriteLine("Must be a positive number");
            }else if(amount > stock.Quantity){
                Console.WriteLine("Amount not available");
            }else if(cost > this.balance){
                Console.WriteLine("Not enough funds");
            }else if(stockPrice < 0){
                Console.WriteLine("Error with day data");
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

        public void SellStock(Day day, List<Stock> globalStocks, Stock stockToSell, int amount){
            int stockPrice = stockToSell.data.GetPrice(day.day, day.isStartOfDay);
            int cost = amount * stockPrice;
            var stock = (from s in globalStocks
                                where s.CompanyName == stockToSell.CompanyName
                                select s).FirstOrDefault();                              
            
            if(amount < 0){
                Console.WriteLine("Must be a positive number");
            }else if(amount > stockToSell.Quantity){
                Console.WriteLine("Amount not available");
            }else if(stockPrice < 0){
                Console.WriteLine("Error with day data");
            }else{
                stocks.Remove(stockToSell);
                
                
                stockToSell.Quantity -= amount;
                if(stockToSell.Quantity != 0)
                    stocks.Add(stockToSell);

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