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

        #region MonoBehaviour

        private void OnValidate()
        {
            _action ??= GetComponent<Action>();
        }

        #endregion

        public override void Do()
        {
            IDisposable disposable = Observable.NextFrame().Subscribe(_ =>
            {
                _action.Do();
            });

            disposable.Dispose();
        }
    }
}
