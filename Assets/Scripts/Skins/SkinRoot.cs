using UnityEngine;

namespace Skins
{
    public class SkinRoot : MonoBehaviour
    {
        [Header("Preferences")]
        [SerializeField] private Avatar _avatar;
        [SerializeField] private Skin _skin;

        public Avatar Avatar => _avatar;
        public Skin Skin => _skin;
    }
}
