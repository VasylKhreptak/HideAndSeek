using CBA.Actions.Core;
using Gameplay.Players;
using UnityEngine;

namespace Actions.Entity
{
    public class KillEntity : Action
    {
        [Header("References")]
        [SerializeField] private KillableObject _killableObject;

        public override void Do()
        {
            _killableObject.Kill();
            
            Debug.Log("Killed Object");
        }
    }
}
