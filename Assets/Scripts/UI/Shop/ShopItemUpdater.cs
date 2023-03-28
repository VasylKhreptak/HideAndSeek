using System;
using Data;
using Skins;
using UniRx;
using UnityEngine;
using Zenject;

namespace UI.Shop
{
    public abstract class ShopItemUpdater : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] protected GameObject _item;

        [Header("Preferences")]
        [SerializeField] protected Skin _skin;

        protected PlayerDataProvider _playerDataProvider;

        protected CompositeDisposable _compositeDisposable = new CompositeDisposable();

        [Inject]
        private void Construct(PlayerDataProvider playerDataProvider)
        {
            _playerDataProvider = playerDataProvider;
        }

        #region MonoBehaviour

        protected virtual void OnDestroy()
        {
            _compositeDisposable.Dispose();
        }

        #endregion
    }
}
