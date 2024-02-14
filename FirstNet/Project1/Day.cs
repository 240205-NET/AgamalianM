namespace Project1{
    class Day{
        // Fields
        public int day {get;set;}
        public bool isStartOfDay{get;set;}
        public int numberOfDays{get;}
        // Constructors
        public Day(int numberOfDays){
            this.day = 0;
            this.isStartOfDay = true;
            this.numberOfDays = numberOfDays;
        } 
        
        // Methods
        public void Next(List<Stock> stocks, List<Account> accounts){
            this.isStartOfDay = (isStartOfDay) ? false : true; //toggle
            if(!this.isStartOfDay && this.day < this.numberOfDays){
                this.day++;
            }
            foreach(Stock s in stocks){
                Console.WriteLine(s.CompanyName + ":\t$" + s.data.GetPrice(this.day, this.isStartOfDay));
            }
            foreach(Account a in accounts){
                int stockValue = 0;
                foreach(Stock s in a.stocks){
                    stockValue += s.Quantity * s.data.GetPrice(this.day, this.isStartOfDay);
                }
                Console.WriteLine("Stock Value: $" + stockValue);
            }
        }
        
        public void SetDay(int day, bool isStartOfDay){
            if(day > numberOfDays){
                Console.WriteLine("Invalid Day");
            }else{
                this.day = day;
                this.isStartOfDay = isStartOfDay;
            }
        }
    }
}