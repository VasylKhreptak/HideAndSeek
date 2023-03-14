using Economy;
using UnityEngine;

namespace Zenject.Installers
{
    public class KeysBankInstaller : MonoInstaller
    {
        [Header("References")]
        [SerializeField] private GameObject _keyBankPrefab;

        public override void InstallBindings()
        {
            GameObject instance = Container.InstantiatePrefab(_keyBankPrefab, transform);
            Container.Bind<KeysBank>().FromComponentOn(instance).AsSingle();
        }
    }
}
