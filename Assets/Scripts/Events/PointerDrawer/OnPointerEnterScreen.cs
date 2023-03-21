using CBA.Events.Core;
using Screen.Pointer;
using UnityEngine;

namespace Events.PointerDrawer
{
    public class OnPointerEnterScreen : MonoEvent
    {
        [Header("References")]
        [SerializeField] private Pointer _pointer;

        #region MonoBehaviour

        private void OnValidate()
        {
            _pointer ??= GetComponent<Pointer>();
        }

        private void OnEnable()
        {
            _pointer.onScreenEnter += Invoke;
        }

        private void OnDisable()
        {
            _pointer.onScreenEnter -= Invoke;
        }

        #endregion
    }
}
