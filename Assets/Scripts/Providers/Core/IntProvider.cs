using UnityEngine;

namespace Providers.Core
{
    public abstract class IntProvider : MonoBehaviour
    {
        public abstract int value { get; }
    }
}
