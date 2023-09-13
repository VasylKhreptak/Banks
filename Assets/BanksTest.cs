using Plugins.Banks.Data.Economy;
using Plugins.Banks.Data.Economy.Core;
using UniRx;
using UnityEngine;
using Zenject;

public class BanksTest : MonoBehaviour
{
    private IntegerBank _coinsBank;

    private Banks _banks;

    [Inject]
    private void Constructor(Banks banks)
    {
        _banks = banks;
    }

    private void Awake()
    {
        _banks.IntegerBanks.TryGetValue(BankType.Coins, out _coinsBank);

        _coinsBank.Value.Subscribe(value => Debug.Log($"Coins: {value}")).AddTo(this);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _coinsBank.Add(10);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _coinsBank.Spend(9);
        }
    }
}
