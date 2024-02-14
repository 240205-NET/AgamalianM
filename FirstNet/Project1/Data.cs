using System.Text;

namespace Project1{
    class Data{
        // Fields
        private const int numberOfDays = 10;
        public int[] Day {get;}
        public int[] OpenPrice {get;set;}
        public int[] ClosePrice {get;set;}

        // Constructors
        public Data(){
            this.Day = new int[numberOfDays];
            this.OpenPrice = new int[numberOfDays];
            this.ClosePrice = new int[numberOfDays];
        }

        // Methods
        public void GenerateData(int startPrice = 1, int variation = 1){
            // int[,]newData = new int[numberOfDays,3];
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
                        
                    this.Day[i] = i + 1;
                    this.OpenPrice[i] = startPrice;
                    this.ClosePrice[i] = endPrice;

                    // newData[i,0] = this.Day[i];
                    // newData[i,1] = this.OpenPrice[i];
                    // newData[i,2] = this.ClosePrice[i];
                }
            }
        }
        public int GetPrice(int day, bool isStartOfDay){
            if(day <= 0){
                Console.WriteLine("Must be a positive number" + numberOfDays);
                return 0;
            }

            return isStartOfDay ? (this.OpenPrice[day - 1]) : (this.ClosePrice[day - 1]);
        }

        public string ToString(){
            var sb = new StringBuilder();
            for(int i = 0; i < numberOfDays; i++){
                sb.Append("Day: " + this.Day[i]);
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