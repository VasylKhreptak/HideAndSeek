using UI;
using UnityEngine;

namespace Gameplay.HidePlayer
{
    public class KeyHolder : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private KeySign _keySign;

        private bool _hasKey;

        public bool HasKey => _hasKey;
        
        #region MonoBehaviour

        private void OnValidate()
        {
            _keySign ??= FindObjectOfType<KeySign>();
        }

        #endregion

        public void PlaceKey()
        {
            if (_hasKey == false)
            {
                _hasKey = true;
                _keySign.SetState(true);
            }
        }
    }
}
