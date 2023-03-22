using UI;
using UniRx;
using UnityEngine;

namespace Gameplay.HidePlayer
{
    public class KeyHolder : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private KeySign _keySign;

        private ReactiveProperty<bool> _hasKeyProperty = new ReactiveProperty<bool>();

        public IReadOnlyReactiveProperty<bool> HasKeyProperty => _hasKeyProperty;

        public bool HasKey => _hasKeyProperty.Value;

        #region MonoBehaviour

        private void OnValidate()
        {
            _keySign ??= FindObjectOfType<KeySign>();
        }

        #endregion

        public void PlaceKey()
        {
            if (_hasKeyProperty.Value == false)
            {
                _hasKeyProperty.Value = true;
                _keySign.SetState(true);
            }
        }
    }
}
