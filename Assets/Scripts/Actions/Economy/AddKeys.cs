using CBA.Actions.Core;
using Economy;
using Providers.Core;
using UnityEngine;
using Zenject;

namespace Actions.Economy
{
    public class AddKeys : Action
    {
        [Header("References")]
        [SerializeField] private IntProvider _intProvider;

        private KeysBank _keysBank;

        [Inject]
        private void Construct(KeysBank keysBank)
        {
            _keysBank = keysBank;
        }

        public override void Do()
        {
            _keysBank.Add(_intProvider.value);
        }
    }
}
