using CBA.Actions.Core;
using UnityEngine;

namespace Actions.Physics
{
    public class SetActiveRigidbodies : Action
    {
        [Header("References")]
        [SerializeField] private Rigidbody[] _rigidbodies;

        [Header("Preferences")]
        [SerializeField] private bool _isKinematic;

        public override void Do()
        {
            foreach (var rigidbody in _rigidbodies)
            {
                rigidbody.isKinematic = _isKinematic;
            }
        }
    }
}
