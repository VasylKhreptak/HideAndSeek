using System;
using UnityEngine;

namespace Economy.Core
{
    public abstract class Bank<T> : MonoBehaviour
    {
        protected T value;

        public T Value => value;

        public Action<T> onValueChanged;
        public Action<T> onValueAdded;
        public Action<T> onValueSpent;

        public abstract void Add(T value);

        public abstract bool TrySpend(T value);
    }
}
