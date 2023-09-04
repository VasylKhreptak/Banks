namespace Data.Economy
{
    public class Banks
    {
        public readonly BanksContainer<int> IntegerBanks;

        public Banks()
        {
            IntegerBanks = new BanksContainer<int>();
        }
    }
}
