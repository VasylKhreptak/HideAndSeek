using Skins;
using UnityEngine;

namespace ScriptableObjects.Scripts
{
    [CreateAssetMenu(fileName = "HideSkins", menuName = "ScriptableObjects/HideSkins")]
    public class HideSkins : ScriptableObject
    {
        [Header("Preferences")]
        [SerializeField] private HideSkin[] _skins;

        public HideSkin[] Skins => (HideSkin[])_skins.Clone();
    }
}
