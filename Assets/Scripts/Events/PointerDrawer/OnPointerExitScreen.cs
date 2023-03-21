using CBA.Events.Core;
using Screen.Pointer;
using UnityEngine;

namespace Events.PointerDrawer
{
    public class OnPointerExitScreen : MonoEvent
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
            _pointer.onScreenExit += Invoke;
        }

        private void OnDisable()
        {
            _pointer.onScreenExit -= Invoke;
        }

        #endregion
    }
}
