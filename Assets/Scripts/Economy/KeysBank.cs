using Data;
using Economy.Core;
using Zenject;

namespace Economy
{
    public class KeysBank : IntegerBank
    {
        private PlayerDataProvider _playerDataProvider;

        [Inject]
        private void Construct(PlayerDataProvider playerDataProvider)
        {
            _playerDataProvider = playerDataProvider;
        }

        private void Start()
        {
            Add(_playerDataProvider.Data.keys);
        }

        public override void Add(int value)
        {
            base.Add(value);
            
            _playerDataProvider.Data.keys = this.value;
        }
    }
}
