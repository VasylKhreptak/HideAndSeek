using System;
using System.Collections.Generic;

namespace Data
{
    [Serializable]
    public class PlayerData
    {
        public int coins;
        public int keys;
        public List<LevelData> levelsData;
    }
}
