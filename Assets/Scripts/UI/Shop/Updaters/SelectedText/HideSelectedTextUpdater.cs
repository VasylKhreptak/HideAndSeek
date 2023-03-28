using UniRx;

namespace UI.Shop.Updaters.SelectedText
{
    public class HideSelectedTextUpdater : SeekSelectedTextUpdater
    {
        #region MonoBehaviour

        protected override void Start()
        {
            UpdateText(_playerDataProvider.Data.skinData.currentHideSkin.Value);
            _playerDataProvider.Data.skinData.currentHideSkin.Subscribe(UpdateText).AddTo(_compositeDisposable);
        }

        #endregion
    }
}
