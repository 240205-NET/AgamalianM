namespace Project1{
    class Day{
        // Fields
        public int day {get;set;}
        public bool isStartOfDay{get;set;}
        public int numberOfDays{get;}
        // Constructors
        public Day(int numberOfDays){
            this.day = 1;
            this.isStartOfDay = true;
            this.numberOfDays = numberOfDays;
        } 
        
        // Methods
        public bool Next(List<Stock> stocks, List<Account> accounts){
            if(!isStartOfDay)
                if(day < numberOfDays){
                    day++;
                }else{
                    return false;
                }
            this.isStartOfDay = (isStartOfDay) ? false : true; //toggle
            Console.WriteLine("\n\n" + (isStartOfDay ? "Start of " : "End of " ) + "Day " + this.day);
            
            Console.WriteLine("======Stock Prices per share======");
            foreach(Stock s in stocks){
                Console.Write(s.CompanyName + ":\t$" + s.data.GetPrice(this.day, this.isStartOfDay));
                StockFluctuation(s);
            }

            foreach(Account a in accounts){
                int stockValue = 0;
                foreach(Stock s in a.stocks){
                    stockValue += s.Quantity * s.data.GetPrice(this.day, this.isStartOfDay);
                }
                Console.WriteLine(a.name + " Stock Value: $" + stockValue);
            }
            return true;
        }
        
        public void Set(int day, bool isStartOfDay){
            if(day > numberOfDays){
                Console.WriteLine("Invalid Day");
            }else{
                this.day = day;
                this.isStartOfDay = isStartOfDay;
            }
        }

        private void StockFluctuation(Stock s){
            if(day == 1 && isStartOfDay){
                return;
            }
            bool previousTimeOfDay = !isStartOfDay;
            int previousDay = (isStartOfDay && day > 1) ? day - 1 : day;
            int previousPrice = s.data.GetPrice(previousDay, previousTimeOfDay);
            int currentPrice = s.data.GetPrice(day, isStartOfDay);

            if(previousPrice < currentPrice){
                Console.WriteLine("\tUP " + previousPrice / (currentPrice - previousPrice) + "%");
            }else if((previousPrice - currentPrice) == 0 || (currentPrice - previousPrice) == 0 ){
                Console.WriteLine("\tSAME 0%");
            }else{
                Console.WriteLine("\tDOWN " + previousPrice / (previousPrice - currentPrice) + "%");
            }
        }
    }
}