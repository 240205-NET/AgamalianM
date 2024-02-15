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
        public bool Next(){
            if(!isStartOfDay){
                if(day < numberOfDays){
                    day++;
                }else{
                    return false;
                }
            }
            this.isStartOfDay = (isStartOfDay) ? false : true; //toggle
            Console.WriteLine("\n\n" + (isStartOfDay ? "Start of " : "End of " ) + "Day " + this.day);
            return true;
        }
        
        public void Set(int day, bool isStartOfDay){
            if(day > numberOfDays){
                Console.WriteLine("Invalid Day");
            }else{
                this.day = day;
                this.isStartOfDay = isStartOfDay;
            }
            Console.WriteLine("\n\n" + (isStartOfDay ? "Start of " : "End of " ) + "Day " + this.day);
        }
    }
}