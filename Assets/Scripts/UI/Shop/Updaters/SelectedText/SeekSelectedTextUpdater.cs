using Skins;
using UniRx;

namespace UI.Shop.Updaters.SelectedText
{
    public class SeekSelectedTextUpdater : ShopItemUpdater
    {
        #region MonoBehaviour

        protected virtual void Start()
        {
            UpdateText(_playerDataProvider.Data.skinData.currentSeekSkin.Value);
            _playerDataProvider.Data.skinData.currentSeekSkin.Subscribe(UpdateText).AddTo(_compositeDisposable);
        }

        #endregion

        protected void UpdateText(Skin skin)
        {
            _item.SetActive(skin == _skin);
        }
    }
}
