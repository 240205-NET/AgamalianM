namespace Project1{
    class Program{
        static void Main(){
            bool playAgain = true;
            do{
                Console.WriteLine("Welcome!");
                Console.WriteLine("How many days would you like to simulate?");
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
                                if(choice[0] == -1){
                                    break;
                                }
                                account1.BuyStock(day, stocks[choice[0]], choice[1]);
                                break;
                            case 3: // SELL STOCK
                                Console.WriteLine("Choose stock to sell");
                                choice = GetStockChoice(account1.stocks, day);
                                if(choice[0] == -1){
                                    break;
                                }
                                account1.SellStock(day, account1.stocks[choice[0]], choice[1]);
                                break;
                            case 4: // HOLD STOCK
                                Console.WriteLine("And so, time continues on...");
                                break;
                            // case 5: // SKIP TO DAY ##DEBUG OPTION##
                            //     Console.WriteLine("Which day would you like to skip too?");
                            //     Console.WriteLine("Last day: " + day.numberOfDays);
                            //     int userDay = ReadInt();
                            //     day.Set(userDay, true);
                            //     break;
                            default:
                                Console.WriteLine("Invalid option");
                                break;
                        }
                    }while(menu != 4); //continue to next day if user is done buying/selling
                }while(day.Next());
                
                // Perfomance review
                Console.WriteLine("STATS");
                Console.WriteLine(account1.ToString(day));
                int performance = account1.balance - startBalance;
                if(performance > 0){
                    Console.WriteLine("You made: $" + performance + " dollars!");
                }else{
                    Console.WriteLine("You lost: $" + -performance + " dollars...");
                }
                
                Record record = new Record(account1.name, day.numberOfDays, startBalance, performance);
                record.ViewRecords();
                
                int option = YesNoChoice("Save record?");
                if(option == 1){
                    record.Save();
                }
                
                option = YesNoChoice("Play again?");
                if(option == 2){
                    playAgain = false;
                }
            }while(playAgain);
            Console.WriteLine("Thanks for playing!");
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
            bool canPlay = true;
            Console.WriteLine("Please Create an account");
            
            Console.Write("Name: ");
            string name = Console.ReadLine();
            
            int age;
            do{
                Console.Write("Age: ");
                age = ReadInt();
                if(age < 18){
                    Console.WriteLine("This is a Big Boi Game.");
                    Console.WriteLine("You must be 18yrs or older to trade.");
                    canPlay = false;
                }else{
                    canPlay = true;
                }
            }while(!canPlay);
            
            Console.Write("Address: ");
            string address = Console.ReadLine();
            
            int balance;
            do{
                Console.Write("Bank balance: ");
                balance = ReadInt();
                if(balance < 100){
                    Console.WriteLine("Must have at least $100 to purchase a trade.");
                    canPlay = false;
                }else{
                    canPlay = true;
                }
            }while(!canPlay);
            
            int tier;
            if(balance < 500){
                tier = 1;
            }else if(balance > 500 && balance < 1000){
                tier = 2;
            }else{
                tier = 3;
            }
            Account account = new Account(name, age, address, balance, tier);

            return account;
        }
    
        static int GetMenuOption(){
            Console.WriteLine("\nChoose an option");
            Console.WriteLine("1 -- VIEW ACCOUNT");
            Console.WriteLine("2 -- BUY STOCK");
            Console.WriteLine("3 -- SELL STOCK");
            Console.WriteLine("4 -- HOLD STOCK");
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
            
            if(options == 0){
                Console.WriteLine("No options available");
                return new int[] {-1,0};
            }

            do{
                for(int i = 0; i < options; i++){
                    Console.WriteLine((i + 1) + " - " + stocks[i].ToString(today));
                }
                Console.WriteLine((options + 1) + " - " + "Cancel");
                choice[0] = ReadInt();
                if(choice[0] > options + 1){
                    Console.WriteLine("Invalid Selection");
                    continue;
                }
                if(choice[0] == options + 1){ 
                    return new int[] {-1,0};
                }
                choice[0] -= 1;
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
    
        static int YesNoChoice(string question){
            int option = 0;
            do{
                Console.WriteLine(question);
                Console.WriteLine("1\t-\tYES");
                Console.WriteLine("2\t-\tNO");
                option = ReadInt();
                if(option > 2)
                    Console.WriteLine("Invalid option");
            }while(option > 2);
            return option;
        }
    }
}