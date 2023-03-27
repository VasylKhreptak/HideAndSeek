using System;
using System.Collections.Generic;
using Skins;
using UniRx;

namespace Data
{
    [Serializable]
    public class PlayerData
    {
        public int coins;
        public int keys;
        public List<LevelData> levels;
        public ReactiveProperty<HideSkinType> hideSkinType;
        public ReactiveProperty<SeekSkinType> seekSkinType;
        public HideSkinType[] _hideSkins;
        public SeekSkinType[] _seekSkins;
    }
}
