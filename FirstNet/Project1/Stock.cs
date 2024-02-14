using System.Text;

namespace Project1{
    class Stock{
        // Fields
        public string CompanyName{get;}
        public int Quantity{get;set;}
        public Data data {get;}
        // Constructors
        public Stock(string compayName, int quantity, int startPrice, int variation){
            this.CompanyName = compayName;
            this.Quantity = quantity;
            this.data = new Data();
            this.data.GenerateData(startPrice, variation);
        }

        // Methods
        public string ToString(){
            var sb = new StringBuilder();
            sb.Append("Company: " + CompanyName);
            sb.Append("\t\tQuantity: " + Quantity);
            return sb.ToString();
        }
    }
}

// Stocks
    // Company
    // Quantity
    // Data