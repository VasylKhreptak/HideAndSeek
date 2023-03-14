using UnityEngine;

namespace Zenject.Installers
{
    public class JoystickInstaller : MonoInstaller
    {
        [Header("References")]
        [SerializeField] private Joystick _joystick;

        private void OnValidate()
        {
            _joystick ??= FindObjectOfType<Joystick>();
        }

        public override void InstallBindings()
        {
            Container.BindInstance(_joystick).AsSingle();
        }
    }
}
