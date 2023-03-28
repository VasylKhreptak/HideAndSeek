using CBA.Actions.Core;
using UnityEngine;

namespace Actions.Entity
{
    public abstract class PunchRagdoll : Action
    {
        [Header("References")]
        [SerializeField] private Transform _ragdollRoot;
        [SerializeField] private Transform _seekPlayerTransform;

        [Header("Preferences")]
        [SerializeField] private float _force;
        [SerializeField] private ForceMode _forceMode;

        public override void Do()
        {
            Punch();
        }

        private void Punch()
        {
            Vector3 direction = GetPunchDirection();

            foreach (var rigidbody in GetRigidbodies())
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

        protected abstract Rigidbody[] GetRigidbodies();
    }
}
