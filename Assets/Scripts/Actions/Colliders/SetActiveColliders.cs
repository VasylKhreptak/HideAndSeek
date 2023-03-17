using CBA.Actions.Core;
using UnityEngine;

namespace Actions.Colliders
{
    public class SetActiveColliders : Action
    {
        [Header("References")]
        [SerializeField] private Collider[] _colliders;

        [Header("Preferences")]
        [SerializeField] private bool _state;

        public override void Do()
        {
            foreach (var collider in _colliders)
            {
                collider.enabled = _state;
            }
        }
    }
}
