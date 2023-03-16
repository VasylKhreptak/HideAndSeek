using System;
using UnityEngine;

namespace Physics
{
    public class RagdollControl : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private UnityEngine.Transform _root;

        [Header("Preferences")]
        [SerializeField] private bool _initialState;
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

        private void Awake()
        {
            SetActive(_initialState);
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
    }
}
