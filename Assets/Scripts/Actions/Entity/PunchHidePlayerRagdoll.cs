using System;
using UnityEngine;
using Action = CBA.Actions.Core.Action;

namespace Actions.Entity
{
    public class PunchHidePlayerRagdoll : Action
    {
        [Header("References")]
        [SerializeField] private Transform _ragdollRoot;
        [SerializeField] private Transform _seekPlayerTransform;
        [SerializeField] private HidePlayerRagdollController _ragdoll;

        [Header("Preferences")]
        [SerializeField] private float _force;
        [SerializeField] private ForceMode _forceMode;

        #region MonoBehaviour

        private void OnValidate()
        {
            _ragdoll ??= FindObjectOfType<HidePlayerRagdollController>();
        }

        #endregion

        public override void Do()
        {
            Vector3 direction = GetPunchDirection();

            foreach (var rigidbody in _ragdoll.GetRigidbodies())
            {
                rigidbody.AddForce(direction * _force, _forceMode);
            }
        }

        private Vector3 GetPunchDirection()
        {
            Vector3 start = _seekPlayerTransform.position;
            Vector3 end = _ragdollRoot.position;
            end.y = start.y;
            return (end - start).normalized;
        }
    }
}
