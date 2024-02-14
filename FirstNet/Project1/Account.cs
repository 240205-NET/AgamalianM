using System.Text;

namespace Project1{
    class Account{
        // Fields

        public string name{get;set;}
        public int age {get;set;}
        public string address{get;set;}
        public int balance{get;set;} = 0;
        public int tier{get;set;} = 1;
        public List<Stock> stocks{get;set;}
        

        // Constructors
        public Account(string name, int age, string address, int balance, int tier){
            this.name = name;
            this.age = age;
            this.address = address;
            this.balance = balance;
            this.tier = tier;
             this.stocks = new List<Stock>();
        }

        // Methods
        public string ToString(){
            var sb = new StringBuilder();
            sb.Append("Name: " + name);
            sb.Append("\tBalance: $" + balance);
            sb.Append("\tTier: " + tier);
                foreach(Stock s in stocks)
                    sb.AppendLine(s.ToString());
                
            return sb.ToString();
        }
    }

}


// Accounts
    // Owner
        // Name
        // Age
        // Address
    // Funds        --how much in yo bank
        // Assets
        // Checking Account
    // Buy Power    --how much you are risking
        // Low-Buy Power
        // High-Buy Power
        // Unlimited-Buy Power