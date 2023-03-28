using System;
using Data;
using UnityEngine;
using Zenject;

namespace Skins.Updater
{
    public class SkinUpdater : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private SkinChanger _skinChanger;

        protected PlayerDataProvider _playerDataProvider;

        protected IDisposable _disposable;

        [Inject]
        private void Construct(PlayerDataProvider playerDataProvider)
        {
            _playerDataProvider = playerDataProvider;
        }

        #region MonoBehaviour

        private void OnValidate()
        {
            _skinChanger ??= GetComponent<SkinChanger>();
        }

        private void OnDestroy()
        {
            _disposable.Dispose();
        }

        #endregion

        protected void UpdateSkin(Skin skin)
        {
            _skinChanger.SetSkin(skin);
        }
    }
}
