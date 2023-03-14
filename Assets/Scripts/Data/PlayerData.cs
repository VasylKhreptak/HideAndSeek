using System;
using System.Collections.Generic;
using UnityEngine.Serialization;

namespace Data
{
    [Serializable]
    public class PlayerData
    {
        public int coins;
        public int keys;
        public List<LevelData> levels;
    }
}
