using Providers.Core;
using UnityEngine;

namespace Providers
{
    public class ManualIntProvider : IntProvider
    {
        [Header("Preferences")]
        [SerializeField] private int _value;

        public override int value
        {
            get => _value;
        }
    }
}
