using System.Collections;
using CBA.Events.Core;
using UnityEngine;
using Zenject;
using Timer = Gameplay.Timer;

namespace Countdowns
{
    public class FindPlayersCountdown : MonoEvent
    {
        [Header("Preferences")]
        [SerializeField] private int _allowedTime = 150;

        [Header("Events")]
        [SerializeField] private MonoEvent _startFrom;
        [SerializeField] private MonoEvent _cancelEvent;

        private Coroutine _countdownCoroutine;

        private Timer _timer;

        [Inject]
        private void Construct(Timer timer)
        {
            _timer = timer;
        }

        #region MonoBehaviour

        private void OnEnable()
        {
            _startFrom.onMonoCall += StartCountdown;
            _cancelEvent.onMonoCall += StopCountdown;
        }

        private void OnDisable()
        {
            _startFrom.onMonoCall -= StartCountdown;
            _cancelEvent.onMonoCall -= StopCountdown;
        }

        #endregion

        private void StartCountdown()
        {
            _countdownCoroutine ??= StartCoroutine(CountdownRoutine());
        }

        private void StopCountdown()
        {
            if (_countdownCoroutine != null)
            {
                StopCoroutine(_countdownCoroutine);

                _countdownCoroutine = null;
            }
        }

        private IEnumerator CountdownRoutine()
        {
            _timer.ResetTimer();
            _timer.StartTimer(_allowedTime);
            yield return new WaitForSeconds(_allowedTime);
            Invoke();
        }
    }
}
