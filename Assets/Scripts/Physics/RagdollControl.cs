using System;
using UnityEngine;

namespace Physics
{
    public class RagdollControl : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Transform _root;

        [Header("Preferences")]
        [SerializeField] private Rigidbody[] _rigidbodies;
        [SerializeField] private Collider[] _colliders;

        private void OnValidate()
        {
            _root ??= GetComponent<Transform>();

            if (_root == null) return;

            _rigidbodies = _root.GetComponentsInChildren<Rigidbody>();
            _colliders = _root.GetComponentsInChildren<Collider>();
        }

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
    }
}
