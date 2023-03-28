using Economy;
using ScriptableObjects.Scripts;
using Skins;
using TMPro;
using UnityEngine;
using Zenject;

namespace UI.Shop.Texts
{
    public class SkinPriceText : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private TMP_Text _tmp;

        [Header("Preferences")]
        [SerializeField] private Skin _skin;
        [SerializeField] private SkinPrices _skinPrices;
        [SerializeField] private Color _allowedColor = Color.white;
        [SerializeField] private Color _deniedColor = Color.red;

        private CoinsBank _coinsBank;

        [Inject]
        private void Construct(CoinsBank coinsBank)
        {
            _coinsBank = coinsBank;
        }

        #region MonoBehaviour

        private void OnValidate()
        {
            _tmp = GetComponent<TMP_Text>();
        }

        private void Start()
        {
            UpdatePrice();
            UpdateColor();
            _coinsBank.onValueChanged += UpdateColor;
        }

        private void OnDestroy()
        {
            _coinsBank.onValueChanged -= UpdateColor;
        }

        #endregion

        private void UpdatePrice()
        {
            _tmp.text = _skinPrices.Get(_skin).ToString();
        }

        private void UpdateColor(int money) => UpdateColor();

        private void UpdateColor()
        {
            _tmp.color = _coinsBank.CanAfford(_skinPrices.Get(_skin)) ? _allowedColor : _deniedColor;
        }
    }
}
