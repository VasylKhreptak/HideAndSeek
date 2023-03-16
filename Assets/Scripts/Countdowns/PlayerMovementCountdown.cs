using System.Collections;
using CBA.Events.Core;
using Gameplay;
using UnityEngine;
using Zenject;
using Action = CBA.Actions.Core.Action;

namespace Countdowns
{
    public class PlayerMovementCountdown : MonoEvent
    {
        [Header("Preferences")]
        [SerializeField] private int _movementDisableTime = 5;

        [Header("Actions")]
        [SerializeField] private Action _disableMovementAction;
        [SerializeField] private Action _enableMovementAction;

        private Timer _timer;

        [Inject]
        private void Construct(Timer timer)
        {
            _timer = timer;
        }

        private IEnumerator Start()
        {
            _timer.StartTimer(_movementDisableTime);
            _disableMovementAction.Do();
            yield return new WaitForSeconds(_movementDisableTime);
            _enableMovementAction.Do();
            Invoke();
        }
    }
}
