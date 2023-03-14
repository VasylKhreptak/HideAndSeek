using Data;
using UnityEngine;

namespace Zenject.Installers.ProjectContext
{
    public class PlayerDataProviderInstaller : MonoInstaller
    {
        [Header("References")]
        [SerializeField] private GameObject _playerDataProviderPrefab;

        public override void InstallBindings()
        {
            GameObject instance = Instantiate(_playerDataProviderPrefab, transform);
            Container.Bind<PlayerDataProvider>().FromComponentOn(instance).AsSingle();
        }
    }
}
