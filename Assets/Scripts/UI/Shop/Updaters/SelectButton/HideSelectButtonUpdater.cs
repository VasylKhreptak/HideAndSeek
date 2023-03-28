using UniRx;

namespace UI.Shop.Updaters.SelectButton
{
    public class HideSelectButtonUpdater : SeekSelectButtonUpdater
    {
        #region MonoBehaviour

        private void Start()
        {
            UpdateButton(_playerDataProvider.Data.skinData.currentHideSkin.Value);
            _playerDataProvider.Data.skinData.currentHideSkin.Subscribe(UpdateButton).AddTo(_compositeDisposable);
            _playerDataProvider.Data.skinData.boughtSkins.added += OnBoughtSkinsUpdated;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            _playerDataProvider.Data.skinData.boughtSkins.added -= OnBoughtSkinsUpdated;
        }

        #endregion
        
        protected override void OnBoughtSkinsUpdated()
        {
            bool canSelect = _playerDataProvider.Data.skinData.boughtSkins.Contains(_skin) 
                && _playerDataProvider.Data.skinData.currentHideSkin.Value != _skin;

            _item.SetActive(canSelect);
        }
    }
}
