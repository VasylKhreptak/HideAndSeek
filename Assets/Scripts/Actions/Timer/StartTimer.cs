using CBA.Actions.Core;
using UnityEngine;
using Zenject;

namespace Actions.Timer
{
    public class StartTimer : Action
    {
        [Header("Preferences")]
        [SerializeField] private int _duration = 5;
        
        private Gameplay.Timer _timer;

        [Inject]
        private void Construct(Gameplay.Timer timer)
        {
            _timer = timer;
        }
        
        public override void Do()
        {
            _timer.StartTimer(_duration);    
        }
    }
}
