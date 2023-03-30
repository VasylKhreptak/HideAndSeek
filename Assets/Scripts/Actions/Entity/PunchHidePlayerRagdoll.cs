using System;
using Physics;
using UnityEngine;

namespace Actions.Entity
{
    public class PunchHidePlayerRagdoll : PunchRagdoll
    {
        [Header("References")]
        [SerializeField] private HidePlayerRagdollController _ragdoll;

        #region MonoBehaviour

        private void OnValidate()
        {
            _ragdoll ??= GetComponent<HidePlayerRagdollController>();
        }

        #endregion

        protected override Rigidbody[] GetRigidbodies()
        {
            return _ragdoll.GetRigidbodies();
        }
    }
}
