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

        #region MonoBehaviour

        private void OnValidate()
        {
            _botMovement ??= FindObjectOfType<SeekPlayerBotMovement>();
        }

        #endregion

        public override void Do()
        {
            _botMovement.RemoveTarget(_target);
        }
    }
}
