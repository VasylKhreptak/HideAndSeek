using System;
using Adapters.Core;
using UnityEngine;

namespace Adapters
{
    public class AdaptedCharacterControllerForVelocity : Vector3Adapter
    {
        [Header("References")]
        [SerializeField] private CharacterController _characterController;

        #region MonoBehaviour

        private void OnValidate()
        {
            _characterController ??= GetComponent<CharacterController>();
        }

        #endregion

        public override Vector3 value
        {
            get => _characterController.velocity;
            set => throw new NotImplementedException();
        }
    }
}
