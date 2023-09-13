using Plugins.Banks.Data.Economy;
using Plugins.Banks.Data.Economy.Core;
using Zenject;

namespace Plugins.Banks.Zenject.ProjectContext
{
    public class BanksInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Data.Economy.Banks banks = new Data.Economy.Banks();

            banks.IntegerBanks.Add(BankType.Coins, new IntegerBank(0));

            Container.BindInstance(banks).AsSingle();
        }
    }
}
