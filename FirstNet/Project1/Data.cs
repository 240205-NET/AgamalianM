using System.Text;

namespace Project1{
    class Data{
        // Fields
        private const int numberOfDays = 10;
        public int[] OpenPrice {get;set;}
        public int[] ClosePrice {get;set;}

        // Constructors
        public Data(){
            this.OpenPrice = new int[numberOfDays];
            this.ClosePrice = new int[numberOfDays];
        }

        // Methods
        public void GenerateData(int startPrice, int variation){
            int endPrice = 0;
            Random rnd = new Random();
            
            if(startPrice < 1 || variation < 1){
                Console.WriteLine("Parameters must be positive numbers");
            }else{
                
                for(int i = 0; i < numberOfDays; i++){
                    if(i > 0){
                        startPrice = endPrice;
                    }
                    endPrice = rnd.Next(startPrice - variation,
                                    (startPrice + variation) + 1);
                    if(endPrice < 0)
                        endPrice = 0; // prevent negative stock value
                    this.OpenPrice[i] = startPrice;
                    this.ClosePrice[i] = endPrice;
                }
            }
        }
        public int GetPrice(int day, bool isStartOfDay){
            if(day <= 0){
                Console.WriteLine("Must be a positive integer");
                return -1;
            }
            return isStartOfDay ? (this.OpenPrice[day - 1]) : (this.ClosePrice[day - 1]);
        }
        public string ToString(){
            var sb = new StringBuilder();
            for(int i = 0; i < numberOfDays; i++){
                sb.Append("Day: " + (i + 1));
                sb.Append("\tOpening Price: $" + this.OpenPrice[i]);
                sb.AppendLine("\tClosing Price: $" + this.ClosePrice[i]);
            }
            return sb.ToString();
        }
    }
}
// Data
    // Day
    // Open
    // High
    // Low
    // Close