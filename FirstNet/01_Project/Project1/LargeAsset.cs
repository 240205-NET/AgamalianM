namespace Project1{
    public class LargeAsset : Asset{
        // Fields
        public string name {get;set;}
        public int value {get;set;}
        public bool agreeToSell {get;set;}
        // Constructors
        public LargeAsset(){}

        // Methods
        public override void GetName(){
            Console.WriteLine("What are you selling?");
            this.name = Console.ReadLine();
        }
        public int GetValue(){
            Console.WriteLine("How much is it worth?");
            this.value = ReadInt();
            if(this.value > 100){
                Console.WriteLine("It is actually only worth $1000");
            }else{
                Console.WriteLine("I will give you $1000 for it");
            }
            return 1000;
        }
        public override void GetAgreement(){
            agreeToSell = YesNoChoice("Do you agree to sell this item");
            if(!agreeToSell){
                Console.WriteLine("I will take that as a yes");
                agreeToSell = true;
            }
        }
        int ReadInt(){
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
        bool YesNoChoice(string question){
            int option = 0;
            do{
                Console.WriteLine(question);
                Console.WriteLine("1\t-\tYES");
                Console.WriteLine("2\t-\tNO");
                option = ReadInt();
                if(option > 2)
                    Console.WriteLine("Invalid option");
            }while(option > 2);
            return (option == 1) ? true : false;
        }
    }
}