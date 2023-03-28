using Skins;
using UniRx;

namespace UI.Shop.Updaters.SelectButton
{
    public class SeekSelectButtonUpdater : ShopItemUpdater
    {
        #region MonoBehaviour

        private void Start()
        {
            UpdateButton(_playerDataProvider.Data.skinData.currentSeekSkin.Value);
            _playerDataProvider.Data.skinData.currentSeekSkin.Subscribe(UpdateButton).AddTo(_compositeDisposable);
            _playerDataProvider.Data.skinData.boughtSkins.added += OnBoughtSkinsUpdated;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            _playerDataProvider.Data.skinData.boughtSkins.added -= OnBoughtSkinsUpdated;
        }

        #endregion

        protected void UpdateButton(Skin skin)
        {
            bool canSelect = _playerDataProvider.Data.skinData.boughtSkins.Contains(_skin) && skin != _skin;

            _item.SetActive(canSelect);
        }

        protected void OnBoughtSkinsUpdated(Skin newAddedSkin) => OnBoughtSkinsUpdated();

        protected virtual void OnBoughtSkinsUpdated()
        {
            bool canSelect = _playerDataProvider.Data.skinData.boughtSkins.Contains(_skin) && _playerDataProvider.Data.skinData.currentSeekSkin.Value != _skin;

            _item.SetActive(canSelect);
        }
    }
}
