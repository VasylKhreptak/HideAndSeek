using Skins;

namespace UI.Shop.Buttons
{
    public class SeekSelectButton : SelectButton
    {
        protected override void OnSelected(Skin skin)
        {
            _playerDataProvider.Data.skinData.currentSeekSkin.Value = skin;
        }
    }
}
