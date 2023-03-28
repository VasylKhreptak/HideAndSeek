using Collections;
using Skins;

namespace UI.Shop.Updaters.BuyButton
{
    public class BuyButtonUpdater : ShopItemUpdater
    {
        #region MonoBehaviour

        private void Start()
        {
            UpdateButton();
            _playerDataProvider.Data.skinData.boughtSkins.updated += UpdateButton;
        }

        #endregion

        private void UpdateButton() => UpdateButton(_playerDataProvider.Data.skinData.boughtSkins);

        private void UpdateButton(ObservedList<Skin> boughtSkins)
        {
            _item.SetActive(!boughtSkins.Contains(_skin));
        }
    }
}
