using Data;
using Plugins.AudioPooler;
using UnityEngine;

namespace Zenject.Installers.ProjectContext
{
    public class AudioPoolerInstaller : MonoInstaller
    {
        [Header("References")]
        [SerializeField] private GameObject _audioPoolerPrefab;

        public override void InstallBindings()
        {
            GameObject instance = Instantiate(_audioPoolerPrefab, transform);
            Container.Bind<AudioPooler>().FromComponentOn(instance).AsSingle();
        }
    }
}
