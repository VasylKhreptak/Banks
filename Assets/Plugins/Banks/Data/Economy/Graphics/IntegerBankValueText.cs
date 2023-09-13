using System;
using Plugins.Banks.Data.Economy.Core;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

namespace Plugins.Banks.Data.Economy.Graphics
{
    public class IntegerBankValueText : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private TMP_Text _tmp;

        [Header("Preferences")]
        [SerializeField] private BankType _bankType;
        [SerializeField] private string _format = "{0}";

        private IDisposable _subscription;

        private IntegerBank _bank;

        [Inject]
        private void Constructor(Banks banks)
        {
            banks.IntegerBanks.TryGetValue(_bankType, out _bank);
        }

        #region MonoBehaviour

        private void OnValidate()
        {
            _tmp ??= GetComponent<TMP_Text>();
        }

        private void OnEnable()
        {
            StartObserving();
        }

        private void OnDisable()
        {
            StopObserving();
        }

        #endregion

        private void StartObserving()
        {
            StopObserving();

            _subscription = _bank.Value.Subscribe(OnValueChanged);
        }

        private void StopObserving()
        {
            _subscription?.Dispose();
        }

        private void OnValueChanged(int value)
        {
            _tmp.text = string.Format(_format, value);
        }
    }
}
