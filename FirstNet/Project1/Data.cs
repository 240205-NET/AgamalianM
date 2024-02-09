namespace Project1{
    class Data{
        // Fields
        private const int numberOfDays = 100;
        public int[] Day {get;}
        public int[] OpenPrice {get;}
        public int[] ClosePrice {get;}

        // Constructors
        public Data(){
            this.Day = new int[numberOfDays];
            this.OpenPrice = new int[numberOfDays];
            this.ClosePrice = new int[numberOfDays];
        }

        // Methods
        public int[] GetData(int day){
            int[] stockPrice = new int[2];
            if(day < 0){
                Console.WriteLine("day must be in range 0 - " + numberOfDays);
            }else{
                stockPrice[0] = this.OpenPrice[day];
                stockPrice[1] = this.ClosePrice[day];
            }
            return stockPrice;
        }
        
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
                    this.Day[i] = i + 1;
                    this.OpenPrice[i] = startPrice;
                    this.ClosePrice[i] = endPrice;

                    // newData[i,0] = this.Day[i];
                    // newData[i,1] = this.OpenPrice[i];
                    // newData[i,2] = this.ClosePrice[i];
                }
            }
        }
        
        public void ToString(){
            for(int i = 0; i < numberOfDays; i++){
                Console.WriteLine("Day:\t" + this.Day[i]);
                Console.WriteLine("Opening Price:\t" + this.OpenPrice[i]);
                Console.WriteLine("Closing Price:\t" + this.ClosePrice[i]);
            }
        }
    }
}
// Data
    // Day
    // Open
    // High
    // Low
    // Close