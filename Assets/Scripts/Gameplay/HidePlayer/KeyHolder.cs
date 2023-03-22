using UI;
using UniRx;
using UnityEngine;

namespace Gameplay.HidePlayer
{
    public class KeyHolder : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private KeySign _keySign;

        private ReactiveProperty<bool> _hasKey;

        public IReadOnlyReactiveProperty<bool> HasKeyProperty => _hasKey;

        public bool HasKey => _hasKey.Value;

        #region MonoBehaviour

        private void OnValidate()
        {
            _keySign ??= FindObjectOfType<KeySign>();
        }

        #endregion

        public void PlaceKey()
        {
            if (_hasKey.Value == false)
            {
                _hasKey.Value = true;
                _keySign.SetState(true);
            }
        }
    }
}
