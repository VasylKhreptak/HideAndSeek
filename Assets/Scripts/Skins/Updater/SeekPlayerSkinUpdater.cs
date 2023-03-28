using UniRx;

namespace Skins.Updater
{
    public class SeekPlayerSkinUpdater : SkinUpdater
    {
        #region MonoBehaviour

        private void Start()
        {
            UpdateSkin(_playerDataProvider.Data.skinData.currentSeekSkin.Value);
            _disposable = _playerDataProvider.Data.skinData.currentSeekSkin.Subscribe(UpdateSkin);
        }

        #endregion
    }
}
