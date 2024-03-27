using Plugins.Banks;
using Plugins.Banks.Core;
using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;

public class BankTest : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] private float _amount;
    [SerializeField] private bool _isEmpty;

    private IBank<float> _bank;

    private void Awake()
    {
        _bank = new FloatBank(100);
        _bank.Amount.Subscribe(amount => _amount = amount).AddTo(this);
        _bank.IsEmpty.Subscribe(isEmpty => _isEmpty = isEmpty).AddTo(this);
    }

    [Button]
    private void Add() => _bank.Add(9);

    [Button]
    private void Spend() => _bank.Spend(9);

    [Button]
    private void SetValue() => _bank.SetValue(9);

    [Button]
    private void Clear() => _bank.Clear();

    [Button]
    private void HasEnough()
    {
        bool hasEnough = _bank.HasEnough(9);
        Debug.Log(hasEnough);
    }
}