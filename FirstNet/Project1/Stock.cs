using System.Text;

namespace Project1{
    class Stock{
        // Fields
        static private int stockID = 0;
        public int ID {get;}
        public string CompanyName{get;}
        public int Quantity{get;set;}
        public Data data {get;}
        
        // Constructors
        public Stock(int numberOfDays, string compayName, int quantity, int startPrice, int variation){
            this.CompanyName = compayName;
            this.Quantity = quantity;
            this.data = new Data(numberOfDays);
            this.data.GenerateData(startPrice, variation);
            this.ID = stockID++;
        }

        public Stock(Stock stock){
            this.CompanyName = stock.CompanyName;
            this.Quantity = stock.Quantity;
            this.data = stock.data;
            this.ID = stockID++;
        }

        // Methods
        public string ToString(Day today){
            var sb = new StringBuilder();
            sb.Append(this.CompanyName + "\tShares: " + this.Quantity);
            sb.Append("\tPrice: $" + this.data.GetPrice(today.day, today.isStartOfDay));
            return sb.ToString();
        }
    }
}

// Stocks
    // Company
    // Quantity
    // Data