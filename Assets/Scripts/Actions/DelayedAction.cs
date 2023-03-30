using System;
using UniRx;
using UnityEngine;
using Action = CBA.Actions.Core.Action;

namespace Actions
{
    public class DelayedAction : Action
    {
        [Header("References")]
        [SerializeField] private Action _action;

        [Header("Preferences")]
        [SerializeField] private float _delay;

        private IDisposable _disposable;

        public override void Do()
        {
            _disposable?.Dispose();

            _disposable = Observable.Timer(TimeSpan.FromSeconds(_delay)).Subscribe(_ =>
            {
                _action.Do();
            });
        }
    }
}
