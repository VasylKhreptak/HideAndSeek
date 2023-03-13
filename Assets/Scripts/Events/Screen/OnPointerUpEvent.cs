using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Events.Screen
{
    public class OnPointerUpEvent : MonoBehaviour, IPointerUpHandler
    {
        public event Action<PointerEventData> onPointerUp;

        public void OnPointerUp(PointerEventData eventData)
        {
            onPointerUp?.Invoke(eventData);
        }
    }
}
