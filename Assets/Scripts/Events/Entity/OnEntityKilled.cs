using CBA.Events.Core;
using Gameplay.Players;
using UnityEngine;

namespace Events.Entity
{
    public class OnEntityKilled : MonoEvent
    {
        [Header("References")]
        [SerializeField] private KillableObject _killableObject;

        #region MonoBehaviour

        private void OnValidate()
        {
            _killableObject ??= GetComponent<KillableObject>();
        }

        private void OnEnable()
        {
            _killableObject.onKilled += Invoke;
        }

        private void OnDisable()
        {
            _killableObject.onKilled -= Invoke;
        }

        #endregion
    }
}
