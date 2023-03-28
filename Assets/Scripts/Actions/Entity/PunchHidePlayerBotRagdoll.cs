using Physics;
using UnityEngine;

namespace Actions.Entity
{
    public class PunchHidePlayerBotRagdoll : PunchRagdoll
    {
        [Header("References")]
        [SerializeField] private RagdollControl _ragdoll;

        #region MonoBehaviour

        private void OnValidate()
        {
            _ragdoll ??= GetComponent<RagdollControl>();
        }

        #endregion

        protected override Rigidbody[] GetRigidbodies()
        {
            return _ragdoll.GetRigidbodies();
        }
    }
}
