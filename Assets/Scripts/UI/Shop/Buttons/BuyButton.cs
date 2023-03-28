using System;
using Data;
using Economy;
using ScriptableObjects.Scripts;
using Skins;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Shop.Buttons
{
    public class BuyButton : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Button _button;

        [Header("Preferences")]
        [SerializeField] private SkinPrices _skinPrices;
        [SerializeField] private Skin _skin;

        private PlayerDataProvider _playerDataProvider;
        private CoinsBank _coinsBank;

        private IDisposable _buttonSubscription;

        [Inject]
        private void Construct(PlayerDataProvider playerDataProvider, CoinsBank coinsBank)
        {
            _playerDataProvider = playerDataProvider;
            _coinsBank = coinsBank;
        }

        #region MonoBehaviour

        private void OnValidate()
        {
            _button ??= GetComponent<Button>();
        }

        private void Awake()
        {
            _buttonSubscription = _button.OnClickAsObservable().Subscribe(_ => TryBuySkin());
        }

        private void OnDestroy()
        {
            _buttonSubscription.Dispose();
        }

        #endregion

        private void TryBuySkin()
        {
            if (_coinsBank.TrySpend(_skinPrices.Get(_skin)))
            {
                _playerDataProvider.Data.skinData.boughtSkins.Add(_skin);
            }
        }
    }
}
