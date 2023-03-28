using System;
using Collections;
using Skins;
using UniRx;

namespace Data
{
    [Serializable]
    public class SkinData
    {
        public ObservedList<Skin> boughtSkins = new()
        {
            Skin.DefaultBoy,
            Skin.Clown
        };
        public ReactiveProperty<Skin> currentHideSkin = new(Skin.DefaultBoy);
        public ReactiveProperty<Skin> currentSeekSkin = new(Skin.Clown);
    }
}
