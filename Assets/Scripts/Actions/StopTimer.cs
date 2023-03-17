using CBA.Actions.Core;
using Zenject;

namespace Actions
{
    public class StopTimer : Action
    {
        private Gameplay.Timer _timer;

        [Inject]
        private void Construct(Gameplay.Timer timer)
        {
            _timer = timer;
        }

        public override void Do()
        {
            _timer.StopTimer();
        }
    }
}
