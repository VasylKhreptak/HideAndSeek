using UniRx;

namespace Skins.Updater
{
    public class HidePlayerSkinUpdater : SkinUpdater
    {
        #region MonoBehaviour

        private void Start()
        {
            UpdateSkin(_playerDataProvider.Data.skinData.currentHideSkin.Value);
            _disposable = _playerDataProvider.Data.skinData.currentHideSkin.Subscribe(UpdateSkin);
        }

        #endregion
    }
}
