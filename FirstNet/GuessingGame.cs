namespace GuessingGame{
    public class GG{
        static void Main(string[] args){
            Console.WriteLine("Welcome to my simple game!");

                Random rand = new Random();
                bool valid = false;
                int min = 0,
                    max = 20;
            
            do{
                try{
                    Console.WriteLine("\nplease select two numbers to guess between");
                    Console.WriteLine("lowest possible number");
                    min = Int32.Parse(Console.ReadLine());
                    
                    Console.WriteLine("highest possible number");
                    max = Int32.Parse(Console.ReadLine());
                    if(min < max){
                        valid = true;
                    }else{
                        Console.WriteLine("high number has to be bigger than the low number");
                    }
                }
                catch(Exception e){
                    Console.WriteLine(e.Message);
                    Console.WriteLine("start over");
                }
            } while(!valid);

            int target = rand.Next(min, max + 1);

            // Console.WriteLine(target); //DEBUG
            bool hasWon = false;
            int guesses = 0,
                tooHigh = 0,
                tooLow = 0;

            Console.WriteLine("Make a guess between " + min + " and " + max);
            do{                
                try{
                    int guess = Int32.Parse(Console.ReadLine());

                    if(guess >= min && guess <= max){
                        if(guess == target){
                            Console.WriteLine("nice");
                            hasWon = true;
                        } else if(guess > target){
                            Console.WriteLine("too high");
                            tooHigh++;
                        } else{
                            Console.WriteLine("too low,");
                            tooLow++;
                        }
                    } else{
                        Console.WriteLine("Guess is out of range");
                    }
                }
                catch(Exception){
                    Console.WriteLine("Why'd you do that >[");
                }
                guesses++;
            }while(!hasWon);
            
            Console.WriteLine("You guessed the correct number in " + guesses + " guesses!");
            Console.WriteLine("-----Other Stats-----");
            Console.WriteLine("Guesses too high: " + tooHigh);
            Console.WriteLine("Guesses too low: " + tooLow);
        }
    }
}