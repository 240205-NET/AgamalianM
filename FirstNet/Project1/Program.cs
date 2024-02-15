namespace Project1{
    class Program{
        static void Main(){       
            Console.WriteLine("How Many Days?");
            Day day = new Day(ReadInt());
            
            List<Stock> stocks = GenerateStocks(day);
            
            Account account1 = CreateAccount();
            int startBalance = account1.balance;
            Console.WriteLine("Welcome");
            Console.WriteLine(account1.ToString(day));

            // play game
            do{
                AnnounceStockPrices(day, stocks);
                int menu = 0;
                do{
                    menu = GetMenuOption();
                    
                    int[] choice = new int[2];
                    switch(menu){
                        case 1: // View account
                            Console.WriteLine(account1.ToString(day));
                            break;
                        case 2: // BUY STOCK
                            Console.WriteLine("Choose stock to buy");
                            choice = GetStockChoice(stocks, day);
                            account1.BuyStock(day, stocks[choice[0]], choice[1]);
                            break;
                        case 3: // SELL STOCK
                            Console.WriteLine("Choose stock to sell");
                            choice = GetStockChoice(account1.stocks, day);
                            account1.SellStock(day, account1.stocks[choice[0]], choice[1]);
                            break;
                        case 4: // HOLD STOCK
                            Console.WriteLine("And so, time continues on...");
                            break;
                        case 5: // SKIP TO DAY
                            Console.WriteLine("Which day would you like to skip too?");
                            Console.WriteLine("Last day: " + day.numberOfDays);
                            int userDay = ReadInt();
                            day.Set(userDay, true);
                            break;
                        default:
                            Console.WriteLine("Unknown option");
                            break;
                    }
                }while(menu < 4); //continue to next day if user is done buying/selling
            }while(day.Next());
            
            Console.WriteLine("Thanks for playing!");
            Console.WriteLine("STATS");
            Console.WriteLine(account1.ToString(day));
            int performance = account1.balance - startBalance;
            if(performance > 0){
                Console.WriteLine("You made: $" + performance + "!");
            }else{
                Console.WriteLine("You lost: $" + -performance + "!");
            }
        }

        static void AnnounceStockPrices(Day today, List<Stock> stocks){
            Console.WriteLine("======STOCK PRICES PER SHARE======");
            foreach(Stock s in stocks){
                Console.Write(s.ToString(today));
                Console.WriteLine(StockFluctuation(today, s));
            }
        }
        
        static string StockFluctuation(Day today, Stock stock){
            if(today.day == 1 && today.isStartOfDay){
                return "";
            }
            bool previousTimeOfDay = !today.isStartOfDay;
            int previousDay = (today.isStartOfDay) ? today.day - 1 : today.day;
            int previousPrice = stock.data.GetPrice(previousDay, previousTimeOfDay);
            int currentPrice = stock.data.GetPrice(today.day, today.isStartOfDay);

            if(previousPrice < currentPrice){
                return ("\tUP " + previousPrice / (currentPrice - previousPrice) + "%");
            }else if(previousPrice == currentPrice){
                return ("\tSAME 0%");
            }else{
                return ("\tDOWN " + previousPrice / (previousPrice - currentPrice) + "%");
            }
        }
    
        static List<Stock> GenerateStocks(Day today){
            List<Stock> stocks = new List<Stock>();
            Stock Microsoft = new Stock(today.numberOfDays, "Microsoft", 20, 300, 10);
            stocks.Add(Microsoft);
            Stock Facebook = new Stock(today.numberOfDays, "Facebook", 10, 500, 10);
            stocks.Add(Facebook);
            Stock Apple = new Stock(today.numberOfDays, "Apple", 5, 200, 2);
            stocks.Add(Apple);
            Stock Amazon = new Stock(today.numberOfDays, "Amazon", 8, 400, 1);
            stocks.Add(Amazon);
            Stock Netflix = new Stock(today.numberOfDays, "Netflix", 15, 100, 5);
            stocks.Add(Netflix);
            Stock Google = new Stock(today.numberOfDays, "Google", 10, 700, 3);
            stocks.Add(Google);
            return stocks;
        }
    
        static Account CreateAccount(){
            Console.WriteLine("Please Create an account");
            Console.Write("name: ");
            string name = Console.ReadLine();
            Console.Write("age: ");
            int age = ReadInt();
            Console.Write("address: ");
            string address = Console.ReadLine();
            Console.Write("balance: ");
            int balance = ReadInt();
            Console.Write("tier: ");
            int tier = ReadInt();
            Account account = new Account(name, age, address, balance, tier);

            return account;
        }
    
        static int GetMenuOption(){
            Console.WriteLine("\nChoose an option");
            Console.WriteLine("1 -- VIEW ACCOUNT");
            Console.WriteLine("2 -- BUY STOCK");
            Console.WriteLine("3 -- SELL STOCK");
            Console.WriteLine("4 -- HOLD STOCK");
            Console.WriteLine("5 -- SKIP TO DAY");
            return ReadInt();
        }

        static int ReadInt(){
            bool valid = false;
            int choice = 0;
            do{
                try{
                    choice = Int32.Parse(Console.ReadLine());
                    if(choice <= 0){
                        Console.WriteLine("Number must be greater than 0");
                    }else{
                        valid = true;
                    }
                } 
                catch(Exception e){
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Try again");
                }
            }while(!valid);
            return choice;
        }
    
        static int[] GetStockChoice(List<Stock> stocks, Day today){
            int[] choice = new int[2];
            int options = stocks.Count;
            bool valid = false;

            do{
                for(int i = 0; i < options; i++){
                    Console.WriteLine((i + 1) + " - " + stocks[i].ToString(today));
                }
                choice[0] = ReadInt() - 1;
                if(choice[0] > options - 1){
                    Console.WriteLine("Invalid Selection " + (choice[0] + 1));
                    continue;
                }
                valid = true;
            }while(!valid);
            
            valid = false;
            do{
                Console.WriteLine("How many?");
                choice[1] = ReadInt();
                if(choice[1] > stocks[choice[0]].Quantity){
                    Console.WriteLine("Amount not available");
                    continue;
                }
                valid = true;
            }while(!valid);
            return choice;
        }
    }
}