using System.Text;

namespace Project1{
    class Stock{
        // Fields
        public string CompanyName{get;}
        public int Quantity{get;set;}
        public Data data {get;}
        // Constructors
        public Stock(string compayName, int quantity){
            this.CompanyName = compayName;
            this.Quantity = quantity;
            this.data = new Data();
            this.data.GenerateData();
        }

        // Methods
        public string ToString(){
            var sb = new StringBuilder();
            sb.Append("Company: " + CompanyName);
            sb.Append("\tQuantity: " + Quantity);
            return sb.ToString();
        }
    }
}

// Stocks
    // Company
    // Quantity
    // Data