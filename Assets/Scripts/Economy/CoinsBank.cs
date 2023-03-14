using Data;
using Economy.Core;
using UnityEngine;
using Zenject;

namespace Economy
{
    public class CoinsBank : IntegerBank
    {
        private PlayerDataProvider _playerDataProvider;

        [Inject]
        private void Construct(PlayerDataProvider playerDataProvider)
        {
            _playerDataProvider = playerDataProvider;
        }

        [Inject] private DiContainer _container;

        private void Start()
        {
            Add(_playerDataProvider.Data.coins);
        }
    }
}
