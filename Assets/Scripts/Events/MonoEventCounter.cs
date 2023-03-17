using CBA.EventListeners;
using UnityEngine;

namespace Events
{
    public class MonoEventCounter : MonoEventListener
    {
        [Header("Preferences")]
        [SerializeField] private int _count;

        private int _currentCount;

        protected override void OnEventFired()
        {
            _currentCount++;

            if (_currentCount == _count)
            {
                Invoke();
            }
        }

        public void ResetCounter()
        {
            _currentCount = 0;
        }
    }
}
