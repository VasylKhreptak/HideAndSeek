using UnityEngine;

namespace Performance
{
    public class TargetFramerateUnlimiter : MonoBehaviour
    {
        #region MonoBehaviour

        private void Start()
        {
            Set(UnityEngine.Screen.currentResolution.refreshRate);
        }

        #endregion

        private void Set(int framerate)
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = framerate;
        }
    }
}
