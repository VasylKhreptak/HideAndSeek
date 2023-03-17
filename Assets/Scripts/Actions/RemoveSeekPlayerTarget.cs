using Gameplay.Bots.SeekBot.Movement;
using UnityEngine;
using Action = CBA.Actions.Core.Action;

namespace Actions
{
    public class RemoveSeekPlayerTarget : Action
    {
        [Header("References")]
        [SerializeField] private SeekPlayerBotMovement _botMovement;

        [Header("Preferences")]
        [SerializeField] private Transform _target;

        public override void Do()
        {
            _botMovement.RemoveTarget(_target);
        }
    }
}
