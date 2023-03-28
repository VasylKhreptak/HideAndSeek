using System;
using System.Collections.Generic;
using System.Linq;
using Skins;
using UnityEngine;

namespace ScriptableObjects.Scripts
{
    [CreateAssetMenu(fileName = "SkinPrices", menuName = "ScriptableObjects/SkinPrices")]
    public class SkinPrices : ScriptableObject
    {
        [Header("Preferences")]
        [SerializeField] private List<SkinKVP> _skins;

        private Dictionary<Skin, int> _prices;

        public int Get(Skin skin)
        {
            SkinKVP skinKvp = _skins.First(s => s.skin == skin);
            return skinKvp.price;
        }

        [Serializable]
        private class SkinKVP
        {
            public Skin skin;
            public int price;
        }
    }
}
