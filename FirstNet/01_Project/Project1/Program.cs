namespace Project1{
    public class Program{
        static void Main(){
            bool playAgain = true;
            do{
                Console.Clear();
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
                                Console.WriteLine("\nChoose stock to buy");
                                choice = GetStockChoice(stocks, day);
                                if(choice[0] == -1){
                                    break;
                                }
                                account1.BuyStock(day, stocks[choice[0]], choice[1]);
                                break;
                            case 3: // SELL STOCK
                                Console.WriteLine("\nChoose stock to sell");
                                choice = GetStockChoice(account1.stocks, day);
                                if(choice[0] == -1){
                                    break;
                                }
                                account1.SellStock(day, stocks, account1.stocks[choice[0]], choice[1]);
                                break;
                            case 4: // HOLD STOCK
                                Console.WriteLine("\nAnd so, time continues on...");
                                break;
                            // case 5: // SKIP TO DAY ##DEBUG OPTION##
                            //     Console.WriteLine("Which day would you like to skip too?");
                            //     Console.WriteLine("Last day: " + day.numberOfDays);
                            //     int userDay = ReadInt();
                            //     day.Set(userDay, true);
                            //     break;
                            default:
                                Console.WriteLine("\nInvalid option");
                                break;
                        }
                    }while(menu != 4); //continue to next day if user is done buying/selling
                    Console.Clear();
                }while(day.Next());
                
                // Perfomance review
                Console.WriteLine("\n\n-------STATS-------");
                Console.WriteLine(account1.ToString(day));
                int performance = account1.balance - startBalance;
                if(performance > 0){
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("You made: $" + performance + " dollars!");
                }else{
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You lost: $" + -performance + " dollars...");
                }
                Console.ResetColor();
                
                Record record = new Record(account1.name, day.numberOfDays, startBalance, performance);
                record.ViewRecords();
                
                int option = YesNoChoice("Save record?");
                if(option == 1){
                    record.Save();
                }
                
                Console.Clear();
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
                Console.ResetColor();
            }
        }
        
        static string StockFluctuation(Day today, Stock stock){
            if(today.day == 1 && today.isStartOfDay){
                return "";
            }
            bool previousTimeOfDay = !today.isStartOfDay;
            int previousDay = (today.isStartOfDay) ? today.day - 1 : today.day;
            double previousPrice = stock.data.GetPrice(previousDay, previousTimeOfDay);
            double currentPrice = stock.data.GetPrice(today.day, today.isStartOfDay);

            if(previousPrice < currentPrice){
                Console.ForegroundColor = ConsoleColor.Green;
                return ("\tUP " + String.Format("{0:##0.##%}",((currentPrice - previousPrice) / previousPrice)));
            }else if(previousPrice == currentPrice){
                return ("\tSAME 0%");
            }else{
                Console.ForegroundColor = ConsoleColor.Red;
                return ("\tDOWN " + String.Format("{0:##0.##%}",((previousPrice - currentPrice) / previousPrice)));
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
                }else if (age > 100){{
                    Console.WriteLine("You have to be ALIVE to trade...");
                    canPlay = false;
                }
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
                    Console.Clear();
                    Console.WriteLine("Must have at least $100 to purchase a trade.");
                    balance = ConvertAssets();
                }else if(balance > 10000){
                    Console.WriteLine("Hi Bezos!!!");
                    name = "Jeff Bezos";    
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
            Console.WriteLine("1 -- View account");
            Console.WriteLine("2 -- BUY stock");
            Console.WriteLine("3 -- SELL stock");
            Console.WriteLine("4 -- Do nothing");
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
    
        static int ConvertAssets(){
            bool valid = false;
            int choice = 0;
            int balance = 103;
            do{
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("You must sell an asset to trade");
                Console.ResetColor();
                Console.WriteLine("\nHow big is this item?");
                Console.WriteLine("1 - a about the size of an arm");
                Console.WriteLine("2 - a about the size of a car");
                Console.WriteLine("3 - a about the size of your house");
                choice = ReadInt();
                if(choice > 3){
                    Console.WriteLine("You must make a valid selection");
                }else{
                    valid = true;
                }
            }while(!valid);
            
            switch(choice){
                case 1:
                    SmallAsset asset = new SmallAsset();
                    asset.GetName();
                    balance = asset.GetValue();
                    asset.GetAgreement();
                    Console.WriteLine("\n\nTERMS OF CONTRACT\n  you agree to sell: "+ asset.name + "\n  for the amoun: $"+ balance + "\n  I agree: "+ asset.agreeToSell);
                    return balance;
                case 2:
                    MediumAsset asset1 = new MediumAsset();
                    asset1.GetName();
                    balance = asset1.GetValue();
                    asset1.GetAgreement();
                    Console.WriteLine("\n\nTERMS OF CONTRACT\n  you agree to sell: "+ asset1.name + "\n  for the amount: $"+ balance + "\n  I agree: "+ asset1.agreeToSell);
                    return balance;
                case 3: 
                    LargeAsset asset2 = new LargeAsset();
                    asset2.GetName();
                    balance = asset2.GetValue();
                    asset2.GetAgreement();
                    Console.WriteLine("\n\nTERMS OF CONTRACT\n  you agree to sell: "+ asset2.name + "\n  for the amount: $"+ balance + "\n  I agree: "+ asset2.agreeToSell);
                    return balance;
                default:
                    Console.WriteLine("\n\nI dont know why...or how, but I must give you $100,000.\nHere ya go.");
                    balance = 100000;
                    return balance;
            }
            return balance;
        }
    }
}