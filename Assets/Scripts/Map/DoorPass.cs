using CBA.Events.Core;
using CBA.Events.Physics._3D;
using Gameplay.HidePlayer;
using UnityEngine;

namespace Map
{
    public class DoorPass : MonoEvent
    {
        [Header("References")]
        [SerializeField] private OnTriggerEnterEvent _onPlayerEntered;

        #region MonoBeahaviour

        private void OnValidate()
        {
            _onPlayerEntered ??= GetComponent<OnTriggerEnterEvent>();
        }

        private void OnEnable()
        {
            _onPlayerEntered.onEnter += TryAllowEntry;
        }

        private void OnDisable()
        {
            _onPlayerEntered.onEnter -= TryAllowEntry;
        }

        #endregion

        private void TryAllowEntry(Collider collider)
        {
            if (collider.TryGetComponent(out KeyHolder keyHolder))
            {
                if (keyHolder.HasKey)
                {
                    Invoke();
                }
            }
        }
    }
}
