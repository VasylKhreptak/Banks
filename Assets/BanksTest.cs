using Data.Economy;
using UniRx;
using UnityEngine;
using Zenject;

public class BanksTest : MonoBehaviour
{
    private Bank<int> _coinsBank;

    private Banks _banks;

    [Inject]
    private void Constructor(Banks banks)
    {
        _banks = banks;
    }

    private void Awake()
    {
        _banks.IntegerBanks.TryGetBank(BankType.Coins, out _coinsBank);

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
