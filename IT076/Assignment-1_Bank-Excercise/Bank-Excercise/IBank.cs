namespace Bank_Excercise
{
    public interface IBank
    {
        public int deposit(int amt);
        public int withdraw(int amt);
        public int checkBalance();

    }
}