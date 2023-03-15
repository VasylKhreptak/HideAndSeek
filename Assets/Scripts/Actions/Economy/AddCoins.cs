using CBA.Actions.Core;
using Economy;
using Providers.Core;
using UnityEngine;
using Zenject;

namespace Actions.Economy
{
    public class AddCoins : Action
    {
        [Header("References")]
        [SerializeField] private IntProvider _intProvider;

        private CoinsBank _coinsBank;

        [Inject]
        private void Construct(CoinsBank coinsBank)
        {
            _coinsBank = coinsBank;
        }

        public override void Do()
        {
            _coinsBank.Add(_intProvider.value);
        }
    }
}
