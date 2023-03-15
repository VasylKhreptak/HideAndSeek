using Providers.Core;
using UnityEngine;

namespace Providers
{
    public class RandomIntProvider : IntProvider
    {
        [Header("Preferences")]
        [SerializeField] private int _min;
        [SerializeField] private int _max;

        public override int value
        {
            get => Random.Range(_min, _max + 1);
        }
    }
}
