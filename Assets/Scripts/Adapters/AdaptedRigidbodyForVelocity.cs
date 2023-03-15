using Adapters.Core;
using UnityEngine;

namespace Adapters
{
    public class AdaptedRigidbodyForVelocity : Vector3Adapter
    {
        [Header("References")]
        [SerializeField] private Rigidbody _rigidbody;

        #region MonoBehaviour

        private void OnValidate()
        {
            _rigidbody ??= GetComponent<Rigidbody>();
        }

        #endregion

        public override Vector3 value
        {
            get => _rigidbody.velocity;
            set => _rigidbody.velocity = value;
        }
    }
}
