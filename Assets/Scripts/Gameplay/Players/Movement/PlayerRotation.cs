using Events.Screen;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Gameplay.Players.Movement
{
    public class PlayerRotation : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Transform _transform;

        [Header("Preferences")]
        [SerializeField] private float _speed = 5f;

        [Header("Events")]
        [SerializeField] private OnPointerDownEvent _pointerDownEvent;
        [SerializeField] private OnDragEvent _onDragEvent;

        private Vector2 _previousPosition;

        #region MonoBehaviour

        private void OnValidate()
        {
            _transform ??= GetComponent<Transform>();
            _pointerDownEvent ??= FindObjectOfType<OnPointerDownEvent>();
            _onDragEvent ??= FindObjectOfType<OnDragEvent>();
        }

        private void OnEnable()
        {
            _pointerDownEvent.onPointerDown += OnTouch;
            _onDragEvent.onDrag += OnDrag;
        }

        private void OnDisable()
        {
            _pointerDownEvent.onPointerDown -= OnTouch;
            _onDragEvent.onDrag -= OnDrag;
        }

        #endregion

        private void OnTouch(PointerEventData data)
        {
            _previousPosition = data.position;
        }

        private void OnDrag(PointerEventData pointerData)
        {
            Vector2 currentPosition = pointerData.position;
            Vector2 direction = currentPosition - _previousPosition;
            _previousPosition = currentPosition;

            transform.Rotate(Vector3.up, direction.x * _speed * Time.deltaTime);
        }
    }
}
