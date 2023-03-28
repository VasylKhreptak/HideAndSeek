using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Events.Screen
{
    public class OnPointerMoveEvent : MonoBehaviour, IPointerMoveHandler
    {
        public event Action<PointerEventData> onPointerMoved;

        public void OnPointerMove(PointerEventData eventData)
        {
            onPointerMoved?.Invoke(eventData);
        }
    }
}
