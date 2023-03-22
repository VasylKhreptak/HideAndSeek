using CBA.Predicates.Core;
using UnityEngine;

namespace Predicates
{
    public class ColliderEnabledPredicate : Predicate
    {
        [Header("References")]
        [SerializeField] private Collider _collider;

        public override bool Result()
        {
            return _collider.enabled;
        }
    }
}
