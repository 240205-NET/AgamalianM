using System.Text;

namespace Project1{
    class Stock{
        // Fields
        public string CompanyName{get;}
        public int Quantity{get;}
        public Data stockData;
        // Constructors
        public Stock(string compayName, int quantity, int startPrice, int variation){
            this.CompanyName = compayName;
            this.Quantity = quantity;
            stockData = new Data();
            stockData.GenerateData(startPrice, variation);
        }

        // Methods
        public string ToString(){
            var sb = new StringBuilder();
            sb.Append("Company: " + CompanyName);
            sb.Append("\tQuantity: " + Quantity);
            sb.Append("\tData:\n" + stockData.ToString());
            return sb.ToString();
        }
    }
}

// Stocks
    // Company
    // Quantity
    // Data