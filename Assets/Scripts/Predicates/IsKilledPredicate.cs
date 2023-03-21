using CBA.Predicates.Core;
using Gameplay.Players;
using UnityEngine;

namespace Predicates
{
    public class IsKilledPredicate : Predicate
    {
        [Header("References")]
        [SerializeField] private KillableObject _killableObject;

        public override bool Result()
        {
            return _killableObject.IsKilled;
        }
    }
}
