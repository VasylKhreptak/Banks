using System.Collections.Generic;
using Plugins.Banks.Data.Economy.Core;

namespace Plugins.Banks.Data.Economy
{
    public class Banks
    {
        public readonly Dictionary<BankType, IntegerBank> IntegerBanks;

        public Banks()
        {
            IntegerBanks = new Dictionary<BankType, IntegerBank>();
        }
    }
}
