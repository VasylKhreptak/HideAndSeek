using System;
using CBA.Events.Core;
using Gameplay.Players;
using Screen.Pointer;
using UnityEngine;

namespace Gameplay.Screen
{
    public class LastPlayerPointerController : MonoBehaviour
    {
        [Header("Events")]
        [SerializeField] private MonoEvent _onLastPlayerRemainedEvent;

        [Header("Preferences")]
        [SerializeField] private KVPair[] _kvPairs;

        #region MonoBehaviour

        private void OnEnable()
        {
            _onLastPlayerRemainedEvent.onMonoCall += EnablePointer;
        }

        private void OnDisable()
        {
            _onLastPlayerRemainedEvent.onMonoCall -= EnablePointer;
        }

        #endregion

        private void EnablePointer()
        {
            foreach (var kvPair in _kvPairs)
            {
                if (kvPair.killableObject.IsKilled == false)
                {
                    kvPair.pointer.SetActive(true);
                }
            }
        }

        [Serializable]
        private class KVPair
        {
            public KillableObject killableObject;
            public GameObject pointer;
        }
    }
}
