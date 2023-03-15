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
        
        private void Start()
        {
            Add(_playerDataProvider.Data.coins);
        }
        
        public override void Add(int value)
        {
            base.Add(value);
            
            _playerDataProvider.Data.coins = this.value;
        }
    }
}
