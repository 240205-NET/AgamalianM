namespace Banking{
    class Transaction{
        //Fields
        public double amount;
        public  string note;
        public DateTime date;
        public int transactionID;


        private static int transactionIDSeed = 1;
        //Constructors

        public Transaction(double amount, DateTime date, string note = ""){
            this.amount = amount;
            this.date = date;
            this.note = note;
            this.transactionID = transactionIDSeed++;
        }

        

        //methods
    }
}