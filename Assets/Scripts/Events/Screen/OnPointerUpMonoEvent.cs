using CBA.Events.Core;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Events.Screen
{
    public class OnPointerUpMonoEvent : MonoEvent
    {
        [Header("References")]
        [SerializeField] private OnPointerUpEvent _onPointerUpEvent;

        #region MonoBehaviour

        private void OnValidate()
        {
            _onPointerUpEvent ??= GetComponent<OnPointerUpEvent>();
        }

        private void OnEnable()
        {
            _onPointerUpEvent.onPointerUp += Invoke;
        }

        private void OnDisable()
        {
            _onPointerUpEvent.onPointerUp -= Invoke;
        }

        #endregion

        private void Invoke(PointerEventData data) => Invoke();
    }
}
