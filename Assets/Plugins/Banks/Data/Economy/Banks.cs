using System.Collections.Generic;
using Plugins.Banks.Data.Economy.Core;

namespace Plugins.Banks.Data.Economy
{
    public class Banks
    {
        public readonly Dictionary<BankType, Bank<int>> IntegerBanks;

        public Banks()
        {
            IntegerBanks = new Dictionary<BankType, Bank<int>>();
        }
    }
}
