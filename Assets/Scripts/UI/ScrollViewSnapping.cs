using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ScrollViewSnapping : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Transform _contentTransform;
        [SerializeField] private Scrollbar _scrollbar;

        [Header("Preferences")]
        [SerializeField, Range(0f, 1f)] private float _snapSpeed;

        private float _scrollbarPosition;

        private float[] _positions;

        private int _childCount;

        #region MonoBehaviour

        private void OnValidate()
        {
            _contentTransform ??= GetComponent<Transform>();
        }

        private void Awake()
        {
            _childCount = _contentTransform.childCount;
        }

        #endregion

        private void Update()
        {
            _positions = new float[_childCount];
            float distance = 1f / (_positions.Length - 1f);

            for (int i = 0; i < _positions.Length; i++)
            {
                _positions[i] = distance * i;
            }

            if (Input.GetMouseButton(0))
            {
                _scrollbarPosition = _scrollbar.value;
            }
            else
            {
                foreach (var position in _positions)
                {
                    float halfDistance = distance / 2f;

                    if (_scrollbarPosition < position + halfDistance && _scrollbarPosition > position - halfDistance)
                    {
                        _scrollbar.value = Mathf.Lerp(_scrollbar.value, position, _snapSpeed);
                    }
                }
            }
        }
    }
}
