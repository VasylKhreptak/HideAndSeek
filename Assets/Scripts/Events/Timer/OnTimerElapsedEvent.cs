using CBA.Events.Core;
using Zenject;

namespace Events.Timer
{
    public class OnTimerElapsedEvent : MonoEvent
    {
        private Gameplay.Timer _timer;

        [Inject]
        private void Construct(Gameplay.Timer timer)
        {
            _timer = timer;
        }

        #region MonoBehaviour

        private void OnEnable()
        {
            _timer.onElapsed += Invoke;
        }

        private void OnDisable()
        {
            _timer.onElapsed -= Invoke;
        }

        #endregion
    }
}
