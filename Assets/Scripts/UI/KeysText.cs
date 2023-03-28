using System;
using Economy;
using TMPro;
using UnityEngine;
using Zenject;

namespace UI
{
    public class KeysText : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private TMP_Text _tmp;

        private KeysBank _keysBank;

        [Inject]
        private void Construct(KeysBank keysBank)
        {
            _keysBank = keysBank;
        }

        #region MonoBehaviour

        private void OnValidate()
        {
            _tmp ??= GetComponent<TMP_Text>();
        }

        private void Start()
        {
            UpdateText(_keysBank.Value);
            _keysBank.onValueChanged += UpdateText;
        }

        private void OnDestroy()
        {
            _keysBank.onValueChanged -= UpdateText;
        }

        #endregion

        private void UpdateText(int keys)
        {
            _tmp.text = keys.ToString();
        }
    }
}
