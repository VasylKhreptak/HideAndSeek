using CBA.Events.Core;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Events.Screen
{
    public class OnPointerDownMonoEvent : MonoEvent
    {
        [Header("References")]
        [SerializeField] private OnPointerDownEvent _onPointerDownEvent;

        #region MonoBehaviour

        private void OnValidate()
        {
            _onPointerDownEvent ??= GetComponent<OnPointerDownEvent>();
        }

        private void OnEnable()
        {
            _onPointerDownEvent.onPointerDown += Invoke;
        }

        private void OnDisable()
        {
            _onPointerDownEvent.onPointerDown -= Invoke;
        }

        #endregion

        private void Invoke(PointerEventData data) => Invoke();
    }
}
