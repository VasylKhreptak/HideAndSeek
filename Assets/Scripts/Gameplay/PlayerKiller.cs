using CBA.Events.Physics._3D;
using Interfaces.Entity;
using UnityEngine;

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
            if (_currentPlayer == null) return;

            if (_currentPlayer.TryGetComponent(out IKillable killable))
            {
                killable.Kill();
            }
        }
    }
}
