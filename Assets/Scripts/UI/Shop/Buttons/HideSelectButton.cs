using Skins;

namespace UI.Shop.Buttons
{
    public class HideSelectButton : SelectButton
    {
        protected override void OnSelected(Skin skin)
        {
            _playerDataProvider.Data.skinData.currentHideSkin.Value = skin;
        }
    }
}
