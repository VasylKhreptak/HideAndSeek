using Economy;
using UnityEngine;

namespace Zenject.Installers
{
    public class CoinsBankInstaller : MonoInstaller
    {
        [Header("References")]
        [SerializeField] private GameObject _coinBankPrefab;

        public override void InstallBindings()
        {
            GameObject instance = Container.InstantiatePrefab(_coinBankPrefab, transform);
            Container.Bind<CoinsBank>().FromComponentOn(instance).AsSingle();
        }
    }
}