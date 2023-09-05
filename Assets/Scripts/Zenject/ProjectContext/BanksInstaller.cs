using Data.Economy;
using Data.Economy.Core;

namespace Zenject.ProjectContext
{
    public class BanksInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Banks banks = new Banks();

            banks.IntegerBanks.Add(new IntegerBank(BankType.Coins, 0));

            Container.BindInstance(banks).AsSingle();
        }
    }
}
