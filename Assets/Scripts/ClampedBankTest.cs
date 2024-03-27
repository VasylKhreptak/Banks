using Plugins.Banks;
using Plugins.Banks.Core;
using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;

public class ClampedBankTest : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] private float _amount;
    [SerializeField] private float _maxAmount;
    [SerializeField] private bool _isEmpty;
    [SerializeField] private bool _isFull;
    [SerializeField] private float _fillAmount;

    private IClampedBank<int> _bank;

    private void Awake()
    {
        _bank = new ClampedIntegerBank(100, 70);
        _bank.Amount.Subscribe(amount => _amount = amount).AddTo(this);
        _bank.MaxAmount.Subscribe(maxAmount => _maxAmount = maxAmount).AddTo(this);
        _bank.IsEmpty.Subscribe(isEmpty => _isEmpty = isEmpty).AddTo(this);
        _bank.IsFull.Subscribe(isFull => _isFull = isFull).AddTo(this);
        _bank.FillAmount.Subscribe(fillAmount => _fillAmount = fillAmount).AddTo(this);
    }

    [Button]
    private void Add() => _bank.Add(9);

    [Button]
    private void Spend() => _bank.Spend(9);

    [Button]
    private void SetValue() => _bank.SetValue(9);

    [Button]
    private void SetMaxValue() => _bank.SetMaxValue(9);

    [Button]
    private void Clear() => _bank.Clear();

    [Button]
    private void HasEnough()
    {
        bool hasEnough = _bank.HasEnough(9);
        Debug.Log(hasEnough);
    }
}