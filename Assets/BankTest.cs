using Plugins.Banks;
using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;

public class BankTest : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] private float _value;
    [SerializeField] private float _maxValue;
    [SerializeField] private float _fillAmount;
    [SerializeField] private float _leftToFill;

    private ClampedFloatBank _bank;

    private void Awake()
    {
        _bank = new ClampedFloatBank(_value, _maxValue);

        _bank.Value.Subscribe(value => _value = value);
        _bank.MaxValue.Subscribe(value => _maxValue = value);
        _bank.FillAmount.Subscribe(value => _fillAmount = value);
        _bank.LeftToFill.Subscribe(value => _leftToFill = value);
    }

    [Button]
    private void IncrementValue() => _bank.Add(1.5f);

    [Button]
    private void DecreaseValue() => _bank.Spend(1.5f);

    [Button]
    private void IncrementMaxValue() => _bank.SetMaxValue(_bank.MaxValue.Value + 1.5f);

    [Button]
    private void DecreaseMaxValue() => _bank.SetMaxValue(_bank.MaxValue.Value - 1.5f);
}