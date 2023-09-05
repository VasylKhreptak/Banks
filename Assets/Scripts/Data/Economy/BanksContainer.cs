using System.Collections.Generic;
using Data.Economy.Core;

namespace Data.Economy
{
    public class BanksContainer<T>
    {
        private readonly Dictionary<BankType, Bank<T>> _banks;

        public BanksContainer()
        {
            _banks = new Dictionary<BankType, Bank<T>>();
        }

        public void Add(Bank<T> bank)
        {
            _banks.Add(bank.BankType, bank);
        }

        public void Remove(BankType type)
        {
            _banks.Remove(type);
        }

        public bool TryGetBank(BankType type, out Bank<T> bank)
        {
            return _banks.TryGetValue(type, out bank);
        }
    }
}
