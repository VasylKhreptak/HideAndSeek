using System;
using UnityEngine;

namespace Physics
{
    public class RagdollControl : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private UnityEngine.Transform _root;

        [Header("Preferences")]
        [SerializeField] private Rigidbody[] _rigidbodies;
        [SerializeField] private Collider[] _colliders;

        #region MonoBehaviour

        private void OnValidate()
        {
            _root ??= GetComponent<UnityEngine.Transform>();

            if (_root == null) return;

            _rigidbodies = _root.GetComponentsInChildren<Rigidbody>();
            _colliders = _root.GetComponentsInChildren<Collider>();
        }

        #endregion

        public void SetActive(bool state)
        {
            foreach (var rigidbody in _rigidbodies)
            {
                rigidbody.isKinematic = !state;
            }

            foreach (var collider in _colliders)
            {
                collider.enabled = state;
            }
        }

        public Rigidbody[] GetRigidbodies()
        {
            return (Rigidbody[])_rigidbodies.Clone();
        }
    }
}
