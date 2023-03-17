using CBA.Adapters.Float.Core;
using Gameplay.Players.Movement;
using UnityEngine;

namespace Adapters
{
    public class AdaptedPlayerMovementForSpeed : FloatAdapter
    {
        [Header("References")]
        [SerializeField] private PlayerMovement _playerMovement;

        #region MonoBehaviour

        private void OnValidate()
        {
            _playerMovement ??= GetComponent<PlayerMovement>();
        }

        #endregion

        public override float value
        {
            get => _playerMovement.Speed;
            set => _playerMovement.SetSpeed(value);
        }
    }
}
