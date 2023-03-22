using System.Diagnostics;
using CBA.Events.Physics._3D;
using Interfaces.Entity;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Gameplay
{
    public class PlayerKiller : MonoBehaviour
    {
        [Header("Events")]
        [SerializeField] private OnTriggerEnterEvent _triggerEnterEvent;

        private GameObject _currentPlayer;

        #region MonoBehaviour

        private void OnEnable()
        {
            _triggerEnterEvent.onEnter += UpdateCurrentPlayer;
        }

        private void OnDisable()
        {
            _triggerEnterEvent.onEnter -= UpdateCurrentPlayer;
        }

        #endregion

        private void UpdateCurrentPlayer(Collider collider)
        {
            _currentPlayer = collider.gameObject;
        }

        public void KillPlayer()
        {
            //Debug.Log("Current Player == null: " + (_currentPlayer == null));

            if (_currentPlayer == null) return;

            if (_currentPlayer.TryGetComponent(out IKillable killable))
            {
                killable.Kill();

                //Debug.Log("Has Killable Object");
            }
        }
    }
}
