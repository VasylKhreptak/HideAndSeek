using Skins;
using UnityEngine;

namespace ScriptableObjects.Scripts
{
    [CreateAssetMenu(fileName = "SeekSkins", menuName = "ScriptableObjects/SeekSkins")]
    public class SeekSkins : ScriptableObject
    {
        [Header("Preferences")]
        [SerializeField] private SeekSkin[] _skins;

        public SeekSkin[] Skins => (SeekSkin[])_skins.Clone();
    }
}
