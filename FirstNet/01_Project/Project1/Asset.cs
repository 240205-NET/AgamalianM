namespace Project1{
    public abstract class Asset{
        // Fields
        string name;
        int value;
        bool agreeToSell;

        // Methods
        public abstract void GetName();
        public abstract void GetAgreement();
    }
}