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
        [SerializeField] private Vector2 _targetScale = new Vector2(1.1f, 1.1f);
        [SerializeField] private Vector2 _startScale = new Vector2(1f, 1f);

        private GameObject _currentObject;

        private float _scrollbarPosition;
        private float _halfDistance;

        private float[] _positions;

        private int _childCount;

        public GameObject CurrentObject => _currentObject;

        #region MonoBehaviour

        private void OnValidate()
        {
            _contentTransform ??= GetComponent<Transform>();
        }

        private void Awake()
        {
            _childCount = _contentTransform.childCount;
        }

        private void Update()
        {
            _positions = new float[_childCount];
            float distance = 1f / (_positions.Length - 1f);
            _halfDistance = distance / 2f;

            for (int i = 0; i < _positions.Length; i++)
            {
                _positions[i] = distance * i;
            }

            Snap();

            UpdateScale();
        }

        #endregion

        private void Snap()
        {
            if (Input.GetMouseButton(0))
            {
                _scrollbarPosition = _scrollbar.value;
            }
            else
            {
                for (var i = 0; i < _positions.Length; i++)
                {
                    var position = _positions[i];
                    if (_scrollbarPosition < position + _halfDistance && _scrollbarPosition > position - _halfDistance)
                    {
                        _scrollbar.value = Mathf.Lerp(_scrollbar.value, position, _snapSpeed);
                    }
                }
            }
        }
        private void UpdateScale()
        {
            for (var i = 0; i < _positions.Length; i++)
            {
                var position = _positions[i];
                if (_scrollbarPosition < position + _halfDistance && _scrollbarPosition > position - _halfDistance)
                {
                    Transform child = _contentTransform.GetChild(i);
                    child.localScale = Vector2.Lerp(child.localScale, _targetScale, _snapSpeed);

                    _currentObject = child.gameObject;

                    for (int a = 0; a < _positions.Length; a++)
                    {
                        if (a != i)
                        {
                            Transform selectedChild = _contentTransform.GetChild(a);
                            selectedChild.localScale = Vector2.Lerp(selectedChild.localScale, _startScale, _snapSpeed);
                        }
                    }
                }
            }
        }
    }
}
