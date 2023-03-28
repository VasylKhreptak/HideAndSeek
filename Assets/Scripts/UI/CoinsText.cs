using System;
using Economy;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

namespace UI
{
    public class CoinsText : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private TMP_Text _tmp;

        private CoinsBank _coinsBank;

        [Inject]
        private void Construct(CoinsBank coinsBank)
        {
            _coinsBank = coinsBank;
        }

        #region MonoBehaviour

        private void OnValidate()
        {
            _tmp ??= GetComponent<TMP_Text>();
        }

        private void Start()
        {
            UpdateText(_coinsBank.Value);
            _coinsBank.onValueChanged += UpdateText;
        }

        private void OnDestroy()
        {
            _coinsBank.onValueChanged -= UpdateText;
        }

        #endregion

        private void UpdateText(int coins)
        {
            _tmp.text = coins.ToString();
        }
    }
}
