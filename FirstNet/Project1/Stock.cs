using System.Text;

namespace Project1{
    class Stock{
        // Fields
        static private List<Stock> stocks = new List<Stock>();
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
            stocks.Add(this);
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
            sb.AppendLine(StockFluctuation(today));
            return sb.ToString();
        }

        public void AnnounceStockPrices(Day today){
            Console.WriteLine("======STOCK PRICES PER SHARE======");
            foreach(Stock s in stocks){
                Console.Write(s.ToString(today));
            }
        }
        
        private string StockFluctuation(Day today){
            if(today.day == 1 && today.isStartOfDay){
                return "";
            }
            bool previousTimeOfDay = !today.isStartOfDay;
            int previousDay = (today.isStartOfDay) ? today.day - 1 : today.day;
            int previousPrice = data.GetPrice(previousDay, previousTimeOfDay);
            int currentPrice = data.GetPrice(today.day, today.isStartOfDay);

            if(previousPrice < currentPrice){
                return ("\tUP " + previousPrice / (currentPrice - previousPrice) + "%");
            }else if(previousPrice == currentPrice){
                return ("\tSAME 0%");
            }else{
                return ("\tDOWN " + previousPrice / (previousPrice - currentPrice) + "%");
            }
        }
    }
}

// Stocks
    // Company
    // Quantity
    // Data