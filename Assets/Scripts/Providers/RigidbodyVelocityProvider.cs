using Providers.Core;
using UnityEngine;

namespace Providers
{
    public class RigidbodyVelocityProvider : Vector3Provider
    {
        [Header("References")]
        [SerializeField] private Rigidbody _rigidbody;

        #region MonoBehaviour

        private void OnValidate()
        {
            _rigidbody ??= GetComponent<Rigidbody>();
        }

        #endregion

        public override Vector3 vector
        {
            get => _rigidbody.velocity;
        }
    }
}
