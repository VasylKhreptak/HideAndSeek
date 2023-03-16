using Gameplay;
using UnityEngine;

namespace Zenject.Installers
{
    public class TimerInstaller : MonoInstaller
    {
        [Header("References")]
        [SerializeField] private Timer _timer;

        #region MonoBehaviour

        private void OnValidate()
        {
            _timer ??= FindObjectOfType<Timer>();
        }

        #endregion

        public override void InstallBindings()
        {
            Container.BindInstance(_timer).AsSingle();
        }
    }
}
