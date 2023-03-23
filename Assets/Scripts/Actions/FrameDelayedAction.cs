using System;
using UniRx;
using UnityEngine;
using Action = CBA.Actions.Core.Action;

namespace Actions
{
    public class FrameDelayedAction : Action
    {
        [Header("References")]
        [SerializeField] private Action _action;

        private IDisposable _disposable;

        #region MonoBehaviour

        private void OnValidate()
        {
            _action ??= GetComponent<Action>();
        }

        #endregion

        public override void Do()
        {
            _disposable?.Dispose();

            _disposable = Observable.NextFrame().Subscribe(_ =>
            {
                _action.Do();
            });
        }
    }
}
