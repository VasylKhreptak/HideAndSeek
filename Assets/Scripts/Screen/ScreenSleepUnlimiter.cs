using UnityEngine;

namespace Screen
{
    public class ScreenSleepUnlimiter : MonoBehaviour
    {
        #region MonoBehaviour

        private void Start()
        {
            UnlimitScreenSleep();
        }

        #endregion

        private void UnlimitScreenSleep()
        {
            UnityEngine.Screen.sleepTimeout = SleepTimeout.NeverSleep;
        }
    }
}
